using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Nzr.ToolBox.Core
{
    /// <summary>
    /// Utility and extensions methods for Reflect types.
    /// </summary>
#if SINGLE
    public static partial class ToolBox
#else
    public static class ReflectionUtils
#endif
    {
        /// <summary>
        /// A container with the Entity, Property and Property value.
        /// </summary>
        public class Reflect
        {
            /// <summary>
            /// The entity that was reflected.
            /// </summary>
            public object Entity { get; }

            /// <summary>
            /// One of entities Property.
            /// </summary>
            public PropertyInfo Property { get; }

            /// <summary>
            /// The property value.
            /// </summary>
            public object Value { get; }

            internal Reflect(object entity, PropertyInfo property, object value)
            {
                Entity = entity;
                Property = property;
                Value = value;
            }
        }

        /// <summary>
        /// Iterate recursively on each property of given entity and invoke the action on each property found.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="action">Action to be performed on each property. It receives an Reflect container with the entity, property info and property value.</param>
        /// <param name="bindingAttr">A bit-mask comprised of one or more System.Reflection.BindingFlags that specify how the search is conducted.
        /// -or- Zero, to return null. (Optional, default BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)</param>
        public static void ExecuteForEachProperty(this object entity, Action<Reflect> action,
            BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
        {
            IList<PropertyInfo> properties = entity.GetType().GetProperties(bindingAttr).ToList();

            foreach (PropertyInfo property in properties)
            {
                object value = property.GetValue(entity, null);
                action.Invoke(new Reflect(entity, property, value));

                if (value == null)
                {
                    continue;
                }

                Type propertyType = property.PropertyType;

                if (propertyType.IsArray || typeof(System.Collections.IEnumerable).IsAssignableFrom(property.PropertyType))
                {
                    System.Collections.IEnumerable e = (System.Collections.IEnumerable)value;

                    foreach (object item in e)
                    {
                        if (item != null && !IsPrimitive(item.GetType()))
                        {
                            ExecuteForEachProperty(item, action, bindingAttr);
                        }
                    }
                }
                else
                {
                    ExecuteForEachProperty(value, action, bindingAttr);
                }
            }
        }

        /// <summary>
        /// Returns a Dictionary with entity name as key and properties names as value.
        /// </summary>
        /// <param name="entity">The entity to be inspected.</param>
        /// <param name="bindingAttr">A bit-mask comprised of one or more System.Reflection.BindingFlags that specify how the search is conducted.
        /// -or- Zero, to return null. (Optional, default BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)</param>
        /// <returns>IDictionary with entity name as key and properties names as value.</returns>
        public static IDictionary<string, IList<string>> GetPropertyNames(this object entity, BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
        {
            IDictionary<string, IList<string>> dictionary = new Dictionary<string, IList<string>>();

            entity.ExecuteForEachProperty(i =>
            {
                Type entityType = i.Entity.GetType();
                string entityName = entityType.Name;

                if (entityType.GenericTypeArguments.Length > 0)
                {
                    string args = string.Join(",", entityType.GenericTypeArguments.Select(a => a.Name).ToList());
                    int indexOfGenericSymbol = entityName.IndexOf("`");
                    entityName = entityName.Substring(0, indexOfGenericSymbol);
                    entityName = $"{entityName}<{args}>";
                }

                if (!dictionary.ContainsKey(entityName))
                {
                    dictionary.Add(entityName, new List<string>());
                }

                IList<string> propertyNames = dictionary[entityName];

                string propertyName = i.Property.Name.Replace("`", string.Empty);

                if (!propertyNames.Contains(propertyName))
                {
                    propertyNames.Add(propertyName);
                }

            }, bindingAttr);

            return dictionary;
        }

        /// <summary>
        /// Gets a value from an object (including nested ones) by using the property path (Ex: A.B.C.Property1).
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="propertyPath">A string representing the property including the nested levels.</param>
        /// <returns></returns>
        public static object GetValue(this object entity, string propertyPath) => GetValue<object>(entity, propertyPath);

        /// <summary>
        /// Gets a value from an object (including nested ones) by using the property path (Ex: A.B.C.Property1).
        /// </summary>
        /// <typeparam name="R">The type of the returned value.</typeparam>
        /// <param name="entity"></param>
        /// <param name="propertyPath">A string representing the property including the nested levels.</param>
        /// <returns></returns>
        public static R GetValue<R>(this object entity, string propertyPath)
        {
            PropertyInfo propertyInfo;

            if (!propertyPath.Contains("."))
            {
                propertyInfo = entity.GetType().GetProperty(propertyPath);
                return (R)propertyInfo.GetValue(entity);
            }

            List<string> properties = propertyPath.Split(".".ToCharArray()).ToList();
            propertyInfo = entity.GetType().GetProperty(properties.First());

            if (propertyInfo.PropertyType.IsArray || typeof(System.Collections.IEnumerable).IsAssignableFrom(propertyInfo.PropertyType))
            {
                throw new NotSupportedException("GetValue doesn't support lists. First, get the list then invoke the GetValue again on each item.");
            }

            properties.RemoveAt(0);

            object value = propertyInfo.GetValue(entity);
            propertyPath = string.Join(".", properties);
            return GetValue<R>(value, propertyPath);
        }

        private static bool IsPrimitive(Type type)
        {
            type = FixType(type);

            return type.IsPrimitive || type == typeof(string) || type.FullName.StartsWith("System.");
        }

        private static Type FixType(Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                type = type.GetGenericArguments()[0];
            }

            return type;
        }
    }
}
