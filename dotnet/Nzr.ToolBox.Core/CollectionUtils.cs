using System;
using System.Collections.Generic;
using System.Linq;

namespace Nzr.ToolBox.Core
{
    /// <summary>
    /// Utility and extensions methods for Collection types.
    /// </summary>
#if SINGLE
    public static partial class ToolBox
#else
    public static class CollectionUtils
#endif
    {
        /// <summary>
        /// Performs the given action for each element of the IEnumerable.
        /// </summary>
        /// <typeparam name="T">Type of elements.</typeparam>
        /// <param name="enumerable">IEnumerable instance.</param>
        /// <param name="action">Action to be executed for each element.</param>
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            if (enumerable == null)
            {
                return;
            }

            foreach (T item in enumerable)
            {
                action.Invoke(item);
            }
        }

        /// <summary>
        /// Performs the given action for each element of the IEnumerable.
        /// </summary>
        /// <param name="enumerable">IEnumerable instance.</param>
        /// <param name="action">Action to be executed for each element.</param>
        public static void ForEach(this System.Collections.IEnumerable enumerable, Action<object> action)
        {
            if (enumerable == null)
            {
                return;
            }

            foreach (object item in enumerable)
            {
                action.Invoke(item);
            }
        }

        /// <summary>
        /// Performs the given function for each element of the IEnumerable.
        /// </summary>
        /// <typeparam name="T">Type of elements.</typeparam>
        /// <param name="enumerable">IEnumerable instance.</param>
        /// <param name="function">Function to be executed for each element.</param>
        public static void ForEach<T>(this IEnumerable<T> enumerable, Func<T, bool> function)
        {
            if (enumerable == null)
            {
                return;
            }

            foreach (T item in enumerable)
            {
                if (!function.Invoke(item))
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Performs the given function for each element of the IEnumerable.
        /// </summary>
        /// <param name="enumerable">IEnumerable instance.</param>
        /// <param name="function">Function to be executed for each element.</param>
        public static void ForEach(this System.Collections.IEnumerable enumerable, Func<object, bool> function)
        {
            if (enumerable == null)
            {
                return;
            }

            foreach (object item in enumerable)
            {
                if (!function.Invoke(item))
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Adds the items to the given ICollection.
        /// </summary>
        /// <typeparam name="T">Type of elements.</typeparam>
        /// <param name="collection">The collection to add items.</param>
        /// <param name="items">Items to be added (Except nulls).</param>
        public static void AddElements<T>(this ICollection<T> collection, params T[] items)
        {
            if (collection == null)
            {
                return;
            }

            foreach (T item in items)
            {
                collection.Add(item);
            }
        }

        /// <summary>
        /// Adds the items from given enumerable to the given ICollection.
        /// </summary>
        /// <typeparam name="T">Type of elements</typeparam>
        /// <param name="collection">The collection to add items.</param>
        /// <param name="enumerable">IEnumerable with items to be added.</param>
        public static void AddEnumerable<T>(this ICollection<T> collection, IEnumerable<T> enumerable)
        {
            if (collection == null)
            {
                return;
            }

            foreach (T item in enumerable)
            {
                collection.Add(item);
            }
        }

        /// <summary>
        /// Checks if all elements in IEnumerable another are also in the IEnumerable enumerable.
        /// </summary>
        /// <param name="enumerable">The IEnumerable reference.</param>
        /// <param name="another">IEnumerable with elements expected to be in the IEnumerable reference.</param>
        /// <returns>True if all elements in IEnumerable another are also in the IEnumerable enumerable.</returns>
        public static bool ContainsAll(this System.Collections.IEnumerable enumerable, System.Collections.IEnumerable another)
        {
            if (enumerable == null && another == null)
            {
                return true;
            }
            else if (enumerable == null || another == null)
            {
                return false;
            }

            bool found = true;

            another.ForEach(e1 =>
            {
                found = false;

                enumerable.ForEach(e0 =>
                {
                    if (e0 == e1 || (e0 != null && e0.Equals(e1)))
                    {
                        found = true;
                        return false; // break
                    }

                    return true;
                });

                return found; // break on first miss.
            });

            return found;
        }

        /// <summary>
        /// Checks if all elements in IEnumerable another are also in the IEnumerable enumerable.
        /// </summary>
        /// <param name="enumerable">The IEnumerable reference.</param>
        /// <param name="another">IEnumerable with elements expected to be in the IEnumerable reference.</param>
        /// <returns>True if all elements in IEnumerable another are also in the IEnumerable enumerable.</returns>
        public static bool ContainsAll<T>(this IEnumerable<T> enumerable, IEnumerable<T> another)
        {
            if (enumerable == null && another == null)
            {
                return true;
            }
            else if (enumerable == null || another == null)
            {
                return false;
            }
            else if (enumerable.Count() < another.Count())
            {
                return false;
            }

            T itemNotFound = another.FirstOrDefault(e1 => !enumerable.Contains(e1));

            return itemNotFound == null;
        }

        /// <summary>
        /// Checks if at least one element in IEnumerable another are also in the IEnumerable enumerable.
        /// </summary>
        /// <param name="enumerable">The IEnumerable reference.</param>
        /// <param name="another">IEnumerable with elements expected to be in the IEnumerable reference.</param>
        /// <returns>True if at least one element in IEnumerable another is also in the IEnumerable enumerable.</returns>
        public static bool ContainsAny(this System.Collections.IEnumerable enumerable, System.Collections.IEnumerable another)
        {
            if (enumerable == null || another == null)
            {
                return false;
            }

            bool found = false;

            another.ForEach(e1 =>
            {
                enumerable.ForEach(e0 =>
                {
                    if (e0 == e1 || (e0 != null && e0.Equals(e1)))
                    {
                        found = true;
                        return false; // break the loop
                    }

                    return true; // continue the loop.
                });

                return !found; // if not found, keep looking.
            });

            return found;
        }

        /// <summary>
        /// Checks if at least one element in IEnumerable another are also in the IEnumerable enumerable.
        /// </summary>
        /// <param name="enumerable">The IEnumerable reference.</param>
        /// <param name="another">IEnumerable with elements expected to be in the IEnumerable reference.</param>
        /// <returns>True if at least one element in IEnumerable another is also in the IEnumerable enumerable.</returns>
        public static bool ContainsAny<T>(this IEnumerable<T> enumerable, IEnumerable<T> another)
        {
            if (enumerable == null || another == null)
            {
                return false;
            }

            T itemNotFound = another.FirstOrDefault(e1 => enumerable.Contains(e1));

            return itemNotFound != null;
        }

        /// <summary>
        /// Returns an empty IEnumerable if the given IEnumerable is null, otherwise returns the given IEnumerable.
        /// </summary>
        /// <param name="enumerable">IEnumerable to be checked.</param>
        /// <returns>A non null IEnumerable.</returns>
        public static System.Collections.IEnumerable EmptyIfNull(this System.Collections.IEnumerable enumerable) => enumerable ?? EmptyIfNull<object>((IEnumerable<object>)null);

        /// <summary>
        /// Returns an empty IEnumerable if the given IEnumerable is null, otherwise returns the given IEnumerable.
        /// </summary>
        /// <param name="enumerable">IEnumerable to be checked.</param>
        /// <returns>A non null IEnumerable.</returns>
        public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> enumerable) => enumerable ?? EmptyIfNull<T>((ICollection<T>)null);

        /// <summary>
        /// Returns an empty ICollection if the given ICollection is null, otherwise returns the given ICollection.
        /// </summary>
        /// <param name="collection">ICollection to be checked.</param>
        /// <returns>A non null ICollection.</returns>
        public static System.Collections.ICollection EmptyIfNull(this System.Collections.ICollection collection) => collection ??
            (System.Collections.ICollection)EmptyIfNull((ICollection<object>)null);

        /// <summary>
        /// Returns an empty ICollection if the given ICollection is null, otherwise returns the given ICollection.
        /// </summary>
        /// <param name="collection">ICollection to be checked.</param>
        /// <returns>A non null ICollection.</returns>
        public static ICollection<T> EmptyIfNull<T>(this ICollection<T> collection) => collection ?? EmptyIfNull<T>(null);

        /// <summary>
        /// Returns an empty IList if the given IList is null, otherwise returns the given IList.
        /// </summary>
        /// <param name="list">IList to be checked.</param>
        /// <returns>A non null IList.</returns>
        public static System.Collections.IList EmptyIfNull(this System.Collections.IList list) => list ?? (System.Collections.IList)EmptyIfNull((IList<object>)null);

        /// <summary>
        /// Returns an empty IList if the given IList is null, otherwise returns the given IList.
        /// </summary>
        /// <param name="list">IList to be checked.</param>
        /// <returns>A non null IList.</returns>
        public static IList<T> EmptyIfNull<T>(this IList<T> list) => list ?? new List<T>();


        /// <summary>
        /// Returns the element in the IEnumerable at index position, throwing IndexOutOfRangeException if no element is found at that position.
        /// </summary>
        /// <param name="enumerable">IEnumerable to be checked.</param>
        /// <param name="index">The index of the element.</param>
        /// <returns>The element at index</returns>
        public static T Get<T>(this IEnumerable<T> enumerable, int index) => enumerable.AsEnumerable<T>().ElementAt<T>(index);

        /// <summary>
        /// Returns the element in the IEnumerable at index position, throwing IndexOutOfRangeException if no element is found at that position.
        /// </summary>
        /// <param name="enumerable">IEnumerable to be checked.</param>
        /// <param name="index">The index of the element.</param>
        /// <returns>The element at index</returns>
        public static object Get(this System.Collections.IEnumerable enumerable, int index)
        {
            if (enumerable == null)
            {
                return null;
            }

            int count = 0;
            object itemFound = null;

            enumerable.ForEach(e0 =>
            {
                if (count == index)
                {
                    itemFound = e0;
                    return false;
                }

                count++;
                return true;
            });

            return itemFound;
        }

        /// <summary>
        /// Checks if the enumerable is null or empty.
        /// </summary>
        /// <param name="enumerable">IEnumerable to be checked.</param>
        /// <returns>True if the enumerable is null or empty.</returns>
        public static bool IsEmpty(this System.Collections.IEnumerable enumerable)
        {
            if (enumerable == null)
            {
                return true;
            }

            foreach (object item in enumerable)
            {
#pragma warning disable S1751 // Loops with at most one iteration should be refactored
                return false;
#pragma warning restore S1751 // Loops with at most one iteration should be refactored
            }

            return true;
        }

        /// <summary>
        /// Checks if the enumerable is not null and not empty.
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns>True if the enumerable is not null and not empty.</returns>
        public static bool IsNotEmpty(this System.Collections.IEnumerable enumerable) => !enumerable.IsEmpty();

        /// <summary>
        /// Searches for the specified object and returns the index of its first occurrence
        /// in a one-dimensional array.
        /// </summary>
        /// <param name="array">The one-dimensional array to search.</param>
        /// <param name="value">The item to locate in array.</param>
        /// <param name="start">The starting index of the search. 0 (zero) is valid in an empty array.</param>
        /// <returns>The index of the first occurrence of value in array, if found; otherwise, the
        /// lower bound of the array minus 1</returns>
        public static int IndexOf(this byte[] array, byte value, int start = 0) => IndexOf<byte>(array, value, start);

        /// <summary>
        /// Searches for the specified object and returns the index of its first occurrence
        /// in a one-dimensional array.
        /// </summary>
        /// <param name="array">The one-dimensional array to search.</param>
        /// <param name="value">The item to locate in array.</param>
        /// <param name="start">The starting index of the search. 0 (zero) is valid in an empty array.</param>
        /// <returns>The index of the first occurrence of value in array, if found; otherwise, the
        /// lower bound of the array minus 1</returns>
        public static int IndexOf(this short[] array, short value, int start = 0) => IndexOf<short>(array, value, start);

        /// <summary>
        /// Searches for the specified object and returns the index of its first occurrence
        /// in a one-dimensional array.
        /// </summary>
        /// <param name="array">The one-dimensional array to search.</param>
        /// <param name="value">The item to locate in array.</param>
        /// <param name="start">The starting index of the search. 0 (zero) is valid in an empty array.</param>
        /// <returns>The index of the first occurrence of value in array, if found; otherwise, the
        /// lower bound of the array minus 1</returns>
        public static int IndexOf(this int[] array, int value, int start = 0) => IndexOf<int>(array, value, start);

        /// <summary>
        /// Searches for the specified object and returns the index of its first occurrence
        /// in a one-dimensional array.
        /// </summary>
        /// <param name="array">The one-dimensional array to search.</param>
        /// <param name="value">The item to locate in array.</param>
        /// <param name="start">The starting index of the search. 0 (zero) is valid in an empty array.</param>
        /// <returns>The index of the first occurrence of value in array, if found; otherwise, the
        /// lower bound of the array minus 1</returns>
        public static int IndexOf(this long[] array, long value, int start = 0) => IndexOf<long>(array, value, start);

        /// <summary>
        /// Searches for the specified object and returns the index of its first occurrence
        /// in a one-dimensional array.
        /// </summary>
        /// <param name="array">The one-dimensional array to search.</param>
        /// <param name="value">The item to locate in array.</param>
        /// <param name="start">The starting index of the search. 0 (zero) is valid in an empty array.</param>
        /// <returns>The index of the first occurrence of value in array, if found; otherwise, the
        /// lower bound of the array minus 1</returns>
        public static int IndexOf(this float[] array, float value, int start = 0) => IndexOf<float>(array, value, start);

        /// <summary>
        /// Searches for the specified object and returns the index of its first occurrence
        /// in a one-dimensional array.
        /// </summary>
        /// <param name="array">The one-dimensional array to search.</param>
        /// <param name="value">The item to locate in array.</param>
        /// <param name="start">The starting index of the search. 0 (zero) is valid in an empty array.</param>
        /// <returns>The index of the first occurrence of value in array, if found; otherwise, the
        /// lower bound of the array minus 1</returns>
        public static int IndexOf(this double[] array, double value, int start = 0) => IndexOf<double>(array, value, start);

        /// <summary>
        /// Searches for the specified object and returns the index of its first occurrence
        /// in a one-dimensional array.
        /// </summary>
        /// <param name="array">The one-dimensional array to search.</param>
        /// <param name="value">The item to locate in array.</param>
        /// <param name="start">The starting index of the search. 0 (zero) is valid in an empty array.</param>
        /// <returns>The index of the first occurrence of value in array, if found; otherwise, the
        /// lower bound of the array minus 1</returns>
        public static int IndexOf(this decimal[] array, decimal value, int start = 0) => IndexOf<decimal>(array, value, start);

        /// <summary>
        /// Searches for the specified object and returns the index of its first occurrence
        /// in a one-dimensional array.
        /// </summary>
        /// <param name="array">The one-dimensional array to search.</param>
        /// <param name="value">The item to locate in array.</param>
        /// <param name="start">The starting index of the search. 0 (zero) is valid in an empty array.</param>
        /// <returns>The index of the first occurrence of value in array, if found; otherwise, the
        /// lower bound of the array minus 1</returns>
        public static int IndexOf(this string[] array, string value, int start = 0) => IndexOf<string>(array, value, start);

        /// <summary>
        /// Searches for the specified object and returns the index of its first occurrence
        /// in a one-dimensional array.
        /// </summary>
        /// <param name="array">The one-dimensional array to search.</param>
        /// <param name="value">The item to locate in array.</param>
        /// <param name="start">The starting index of the search. 0 (zero) is valid in an empty array.</param>
        /// <returns>The index of the first occurrence of value in array, if found; otherwise, the
        /// lower bound of the array minus 1</returns>
        public static int IndexOf<T>(this T[] array, T value, int start = 0) => array != null ? Array.IndexOf(array, value, start) : -1;

        /// <summary>
        /// Gets the Dictionary Key by value.
        /// Note that only the first key is returned.
        /// </summary>
        /// <typeparam name="K">Type of the Key.</typeparam>
        /// <typeparam name="V">Type of the value.</typeparam>
        /// <param name="dictionary">Dictionary instance.</param>
        /// <param name="value">Value used to find the key.</param>
        /// <returns>The key, if found.</returns>
        public static K GetKey<K, V>(this IDictionary<K, V> dictionary, V value)
        {
            if (dictionary == null)
            {
                return default;
            }

            object key = null;

            dictionary.ForEach(kvp =>
            {
                if (value == null && kvp.Value == null)
                {
                    key = kvp.Key;
                }
                else if (kvp.Value != null && kvp.Value.Equals(value))
                {
                    key = kvp.Key;
                }

                return key == null;
            });

            return (K)key;
        }
    }
}
