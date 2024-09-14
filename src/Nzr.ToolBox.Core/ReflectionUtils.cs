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
            public object? Value { get; }

            internal Reflect(object entity, PropertyInfo property, object? value)
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
#pragma warning disable S3011 // Reflection should not be used to increase accessibility of classes, methods, or fields
            BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
#pragma warning restore S3011 // Reflection should not be used to increase accessibility of classes, methods, or fields
        {
            entity.RequireNonNull();

            IList<PropertyInfo> properties = [.. entity.GetType().GetProperties(bindingAttr)];

            foreach (var property in properties)
            {
                var value = property.GetValue(entity, null);
                action.Invoke(new Reflect(entity, property, value));

                if (value == null || IsPrimitive(value.GetType()))
                {
                    continue;
                }

                if (IsCollection(property.PropertyType))
                {
                    var e = (System.Collections.IEnumerable)value;

                    foreach (var item in e)
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
        public static IDictionary<string, IList<string>> GetPropertyNames(this object entity, BindingFlags bindingAttr = BindingFlags.Instance | BindingFlags.Public |
#pragma warning disable S3011 // Reflection should not be used to increase accessibility of classes, methods, or fields
            BindingFlags.NonPublic)
#pragma warning restore S3011 // Reflection should not be used to increase accessibility of classes, methods, or fields
        {
            entity.RequireNonNull();

            var dictionary = new Dictionary<string, IList<string>>();

            entity.ExecuteForEachProperty(i =>
            {
                var entityType = i.Entity.GetType();
                var entityName = entityType.Name;

                if (entityType.GenericTypeArguments.Length > 0)
                {
                    var args = string.Join(",", entityType.GenericTypeArguments.Select(a => a.Name).ToList());
                    var indexOfGenericSymbol = entityName.IndexOf('`');
                    entityName = entityName[..indexOfGenericSymbol];
                    entityName = $"{entityName}<{args}>";
                }

                if (!dictionary.TryGetValue(entityName, out var value))
                {
                    value = ([]);
                    dictionary.Add(entityName, value);
                }

                var propertyNames = value;

                var propertyName = i.Property.Name.Replace("`", string.Empty);

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
        public static object? GetValue(this object entity, string propertyPath) => GetValue<object>(entity, propertyPath);

        /// <summary>
        /// Gets a value from an object (including nested ones) by using the property path (Ex: A.B.C.Property1).
        /// </summary>
        /// <typeparam name="R">The type of the returned value.</typeparam>
        /// <param name="entity"></param>
        /// <param name="propertyPath">A string representing the property including the nested levels.</param>
        /// <returns></returns>
        public static R? GetValue<R>(this object? entity, string propertyPath)
        {
            entity.RequireNonNull();

            PropertyInfo? propertyInfo;

            if (!propertyPath.Contains('.'))
            {
                propertyInfo = entity!.GetType()?.GetProperty(propertyPath);
                return (R?)propertyInfo?.GetValue(entity);
            }

            var properties = propertyPath.Split(".".ToCharArray()).ToList();
            propertyInfo = entity!.GetType().GetProperty(properties[0])!;

            if (IsCollection(propertyInfo.PropertyType))
            {
                throw new NotSupportedException("GetValue doesn't support lists. First, get the list then invoke the GetValue again on each item.");
            }

            properties.RemoveAt(0);

            var value = propertyInfo.GetValue(entity);
            propertyPath = string.Join(".", properties);
            return GetValue<R>(value, propertyPath);
        }

        private static bool IsPrimitive(Type type)
        {
            type = FixType(type);

            return type.IsPrimitive || type == typeof(string) || (type.FullName!.StartsWith("System.") && !IsCollection(type));
        }

        private static Type FixType(Type type)
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
            {
                type = type.GetGenericArguments()[0];
            }

            return type;
        }

        private static bool IsCollection(Type type) => type.IsArray || typeof(System.Collections.IEnumerable).IsAssignableFrom(type);
    }
}
