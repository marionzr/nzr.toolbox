using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;

namespace Nzr.ToolBox.Core
{
    /// <summary>
    /// Utility and extensions methods for Object types.
    /// </summary>
#if SINGLE
    public static partial class ToolBox
#else
    public static class ObjectUtils
#endif
    {
        /// <summary>
        /// If a value is not null, performs the action with the value, otherwise does nothing.
        /// </summary>
        /// <typeparam name="T?">Type of the value.</typeparam>
        /// <param name="value">The value to be checked.</param>
        /// <param name="action">Action to be executed in case the value is not null.</param>
        /// <param name="ifNullAction">Action to be executed in case the value is null (optional).</param>
        /// <returns>Null (internal class).</returns>
        public static Null? IfNotNull<T>(this T? value, Action<T> action, Action? ifNullAction = null)
        {
            if (value is not null)
            {
                action.Invoke(value);
                return null;
            }
            else
            {
                ifNullAction?.Invoke();
            }

            return new Null();
        }

        /// <summary>
        /// If a value is null, performs the action with the value, otherwise does nothing.
        /// </summary>
        /// <typeparam name="T">Type of the value.</typeparam>
        /// <param name="value">The value to be checked.</param>
        /// <param name="action">Action to be executed in case the value is null.</param>
        /// <param name="ifNotNullAction">Action to be executed in case the value is not null (optional)</param>
        /// <returns>Null (internal class).</returns>
        public static NotNull<T>? IfNull<T>(this T? value, Action action, Action<T>? ifNotNullAction = null)
        {
            if (value is null)
            {
                action.Invoke();
                return null;
            }
            else
            {
                ifNotNullAction?.Invoke(value);
            }

            return new NotNull<T>(value);
        }

        /// <summary>
        /// To be used with IfNotNull. This method is invoked in case the value checked by IsNotNull actually is null.
        /// </summary>
        /// <param name="null">InternalUse</param>
        /// <param name="action">Action to be executed in case the value is null.</param>
        public static void Else(this Null? @null, Action action)
        {
            if (@null != null)
            {
                action.Invoke();
            }
        }

        /// <summary>
        /// To be used with IfNull. This method is invoked in case the value checked by IsNull actually is not null.
        /// </summary>
        /// <param name="notnull">Internal use.</param>
        /// <param name="action">Action to be executed in case the value is null.</param>
        public static void Else<T>(this NotNull<T>? notnull, Action<T> action)
        {
            if (notnull != null)
            {
                action.Invoke(notnull.Value);
            }
        }


        /// <summary>
        /// To be used with IfNotNull.
        /// This method is invoked in case the value checked by IsNotNull actually is null and
        /// throws a new ArgumentNullException.
        /// </summary>
        /// <param name="null">Internal use.</param>
        /// <param name="exceptionMessage">Action to be executed in case the value is null.</param>
        public static void ElseThrow(this Null? @null, string? exceptionMessage = null)
        {
            if (@null != null)
            {
                if (exceptionMessage != null)
                {
                    throw new ArgumentException(exceptionMessage);
                }
                else
                {
                    throw new ArgumentException("Value cannot be null.");
                }
            }
        }

        /// <summary>
        /// Internal use.
        /// </summary>
        public sealed class Null
        {
            /// <summary>
            /// For internal use.
            /// </summary>
            public Null() { }
        }

        /// <summary>
        /// Internal use.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <remarks>
        /// For internal use.
        /// </remarks>
        /// <param name="value"></param>
        public class NotNull<T>(T value)
        {
            internal T Value { get; } = value;
        }

        /// <summary>
        /// Checks if all values are not nulls.
        /// </summary>
        /// <param name="values">Values to be checked.</param>
        /// <returns>True is all values are not null.</returns>
        public static bool IsAllNonNull(params object?[] values) => !Array.Exists(values, o => o == null);

        /// <summary>
        /// Checks if all values are not nulls.
        /// </summary>
        /// <param name="values">Values to be checked.</param>
        /// <returns>True is all values are not null.</returns>
        public static bool IsAllNull(params object?[] values) => !Array.Exists(values, o => o != null);

        /// <summary>
        /// Checks if any value is null.
        /// </summary>
        /// <param name="values">Values to be checked.</param>
        /// <returns>True is at least one value is null.</returns>
        public static bool IsAnyNull(params object?[] values) => Array.Exists(values, o => o == null);

        /// <summary>
        /// Checks if any value is not null.
        /// </summary>
        /// <param name="values">Values to be checked.</param>
        /// <returns>True is at least one value is not null.</returns>
        public static bool IsAnyNonNull(params object?[] values) => Array.Exists(values, o => o != null);

        /// <summary>
        /// Returns the first value which is not null.
        /// </summary>
        /// <typeparam name="T">Type of the values</typeparam>
        /// <param name="values">Values to be checked.</param>
        /// <returns>First value not null, if found, otherwise null</returns>
        public static T? FirstNonNull<T>(params T?[] values) => values != null ? Array.Find(values, v => v is not null) : default;

        /// <summary>
        /// Returns the last value which is not null.
        /// </summary>
        /// <typeparam name="T">Type of the values</typeparam>
        /// <param name="values">Values to be checked.</param>
        /// <returns>Last value not null, if found, otherwise null</returns>
        public static T? LastNonNull<T>(params T?[] values) => values.Reverse().FirstOrDefault(v => v is not null);

        /// <summary>
        /// Checks that the value is not null.
        /// </summary>
        /// <param name="value">Value to be checked.</param>
        /// <param name="exceptionMessage">A message used in the ArgumentNullException, in case of null value. (Optional)</param>
        public static void RequireNonNull(this object? value, string? exceptionMessage = null)
        {
            if (value == null)
            {
                if (exceptionMessage != null)
                {
                    throw new ArgumentException(exceptionMessage);
                }
                else
                {
                    throw new ArgumentException("Value cannot be null.");
                }
            }
        }

        /// <summary>
        /// Converts the object value as  Dynamic ExpandoObject.
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <returns>Dynamic ExpandoObject.</returns>
        public static dynamic? ToDynamic(this object value)
        {
            IDictionary<string, object?> expando = new ExpandoObject();

            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(value.GetType()))
            {
                expando.Add(property.Name, property.GetValue(value));
            }

            return expando as ExpandoObject;
        }
    }
}
