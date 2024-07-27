using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Nzr.ToolBox.Core
{
    /// <summary>
    /// Utility and extensions methods for String types.
    /// </summary>
#if SINGLE
    public static partial class ToolBox
#else
    public static partial class StringUtils
#endif
    {
        /// <summary>
        /// Appends the suffix to the string if the string is not null.
        /// If the string is null the return will be a new string with the suffix.
        /// </summary>
        /// <param name="value">The string to be suffixed.</param>
        /// <param name="suffix">The suffix string.</param>
        /// <param name="onlyIfNotExisits">Appends the suffix only if the string does not already ends with the suffix. (Default true)</param>
        /// <param name="stringComparison">One of the StringComparison values that specifies the rules for the search.(Default OrdinalIgnoreCase)</param>
        /// <returns>A string with suffix.</returns>
        public static string Suffix(this string? value, string suffix, bool onlyIfNotExisits = true,
            StringComparison stringComparison = StringComparison.OrdinalIgnoreCase)
        {
            if (value == null)
            {
                return suffix;
            }

            var appendSuffix = !value.EndsWith(suffix, stringComparison) || !onlyIfNotExisits;

            return appendSuffix ? value + suffix : value;
        }

        /// <summary>
        /// Appends the prefix to the string if the string is not null.
        /// If the string is null the return will be a new string with the prefix.
        /// </summary>
        /// <param name="value">The string to be suffixed.</param>
        /// <param name="prefix">The prefix string.</param>
        /// <param name="onlyIfNotExisits">Appends the prefix only if the string does not already starts with the prefix. (Default true)</param>
        /// <param name="stringComparison">One of the StringComparison values that specifies the rules for the search.(Default OrdinalIgnoreCase)</param>
        /// <returns>A string with prefix.</returns>
        public static string Prefix(this string? value, string prefix, bool onlyIfNotExisits = true,
            StringComparison stringComparison = StringComparison.OrdinalIgnoreCase)
        {
            if (value == null)
            {
                return prefix;
            }

            var insertPrefix = !value.StartsWith(prefix, stringComparison) || !onlyIfNotExisits;

            return insertPrefix ? prefix + value : value;
        }

        /// <summary>
        /// Converts the value of a Unicode character to its uppercase equivalent.
        /// </summary>
        /// <param name="c">The Unicode character to convert.</param>
        /// <returns>The uppercase equivalent of c, or the unchanged value of c if c is already uppercase,
        /// has no uppercase equivalent, or is not alphabetic</returns>
        public static char ToUpper(this char c) => char.ToUpper(c);

        /// <summary>
        /// Converts the value of a Unicode character to its lowercase equivalent.
        /// </summary>
        /// <param name="c">The Unicode character to convert.</param>
        /// <returns>The lowercase equivalent of c, or the unchanged value of c if c is already lowercase,
        /// has no lowercase equivalent, or is not alphabetic</returns>
        public static char ToLower(this char c) => char.ToLower(c);

        /// <summary>
        /// Indicates whether the specified Unicode character is categorized as an uppercase letter.
        /// </summary>
        /// <param name="c">The Unicode character to check.</param>
        /// <returns>True if c is an uppercase letter, otherwise, false.</returns>
        public static bool IsUpper(this char c) => char.IsUpper(c);

        /// <summary>
        /// Capitalizes a string changing the first character to title case.
        /// </summary>
        /// <param name="value">The string to be capitalized.</param>
        /// <returns>A capitalized string.</returns>
        public static string? Capitalize(this string? value)
        {
            if (value == null)
            {
                return null;
            }

            var capitalized = new StringBuilder(value);

            for (var i = 0; i < value.Length; i++)
            {
                if (!value[i].IsUpper() && (i == 0 || (value[i - 1] != '\'' && !char.IsLetter(value[i - 1]))))
                {
                    capitalized[i] = value[i].ToUpper();
                }
            }

            return capitalized.ToString();
        }

        /// <summary>
        /// Removes the substrings at the end of string (if exists, using OrdinalIgnoreCase).
        /// Null strings will return null.
        /// </summary>
        /// <param name="value">The string value.</param>
        /// <param name="substrings">The list of substrings to be removed.</param>
        /// <returns>A new string without the given substrings at the end.</returns>
        public static string? RemoveEnd(this string? value, params string[] substrings) => value?.RemoveEnd(StringComparison.OrdinalIgnoreCase, substrings);

        /// <summary>
        /// Removes the substrings at the end of string (if exists).
        /// Null strings will return null.
        /// </summary>
        /// <param name="value">The string value.</param>
        /// <param name="stringComparison">One of the StringComparison values that specifies the rules for the search.(Default OrdinalIgnoreCase)</param>
        /// <param name="substrings">The list of substrings to be removed.</param>
        /// <returns>A new string without the given substrings at the end.</returns>
        public static string? RemoveEnd(this string? value, StringComparison stringComparison, params string[] substrings)
        {
            if (value == null)
            {
                return null;
            }

            var newValue = new StringBuilder(value);

            foreach (var substring in substrings)
            {
                var index = value.LastIndexOf(substring, stringComparison);

                if (index > -1)
                {
                    newValue.Replace(substring, string.Empty, index, substring.Length);
                    value = newValue.ToString();
                }
            }

            return newValue.ToString();
        }

        /// <summary>
        /// Removes the substrings at the beginning of string (if exists, using OrdinalIgnoreCase).
        /// Null strings will return null.
        /// </summary>
        /// <param name="value">The string value.</param>
        /// <param name="substrings">The list of substrings to be removed.</param>
        /// <returns>A new string without the given substrings at the beginning.</returns>
        public static string? RemoveStart(this string? value, params string[] substrings) =>
            value.RemoveStart(StringComparison.OrdinalIgnoreCase, substrings);

        /// <summary>
        /// Removes the substrings at the beginning of string (if exists).
        /// Null strings will return null.
        /// </summary>
        /// <param name="value">The string value.</param>
        /// <param name="stringComparison">One of the StringComparison values that specifies the rules for the search.(Default OrdinalIgnoreCase)</param>
        /// <param name="substrings">The list of substrings to be removed.</param>
        /// <returns>A new string without the given substrings at the beginning.</returns>
        public static string? RemoveStart(this string? value, StringComparison stringComparison, params string[] substrings)
        {
            if (value == null)
            {
                return null;
            }

            var newValue = new StringBuilder(value);

            foreach (var substring in substrings)
            {
                var index = value.IndexOf(substring, stringComparison);

                if (index > -1)
                {
                    newValue.Remove(index, substring.Length);
                    value = newValue.ToString();
                }
            }

            return newValue.ToString();
        }

        /// <summary>
        /// Checks if a string is null or length == 0.
        /// Invoking <c>StringUtils.IsEmpty("")</c> returns true.
        /// Invoking <c>StringUtils.IsEmpty(null)</c> returns true.
        /// Invoking <c>StringUtils.IsEmpty(" ")</c> returns false.
        /// </summary>
        /// <param name="value">A <c>string</c> to be checked.</param>
        /// <returns>True if the string is null or has length == 0.</returns>
        public static bool IsEmpty(this string? value) => value == null || value.Length == 0;

        /// <summary>
        /// Checks if a string is not null and length > 0.
        /// Invoking <c>StringUtils.IsEmpty("")</c> returns false.
        /// Invoking <c>StringUtils.IsEmpty(null)</c> returns false.
        /// Invoking <c>StringUtils.IsEmpty(" ")</c> returns true.
        /// </summary>
        /// <param name="value">A <c>string</c> to be checked.</param>
        /// <returns>True if the string is not null and length > 0.</returns>
        public static bool IsNotEmpty(this string? value) => !IsEmpty(value);

        /// <summary>
        /// Checks if a string is null or length (After trim) == 0.
        /// Invoking <c>StringUtils.IsEmpty("")</c> returns true.
        /// Invoking <c>StringUtils.IsEmpty(null)</c> returns true.
        /// Invoking <c>StringUtils.IsEmpty(" ")</c> returns true.
        /// </summary>
        /// <param name="value">A <c>string</c> to be checked.</param>
        /// <returns>True if the string is null or length (After trim) == 0</returns>
        public static bool IsBlank(this string? value) => value == null || value.Trim().Length == 0;

        /// <summary>
        /// Checks if a string is not null and length (After trim) > 0.
        /// Invoking <c>StringUtils.IsEmpty("")</c> returns false.
        /// Invoking <c>StringUtils.IsEmpty(null)</c> returns false.
        /// Invoking <c>StringUtils.IsEmpty(" ")</c> returns false.
        /// </summary>
        /// <param name="value">A <c>string</c> to be checked.</param>
        /// <returns>string is not null and length (After trim) > 0.</returns>
        public static bool IsNotBlank(this string? value) => !IsBlank(value);

        /// <summary>
        /// Checks if the string value is null before call the Replace method.
        /// If the value is null, returns the default value (if provided).
        /// </summary>
        /// <param name="value">The string value.</param>
        /// <param name="oldValue">The string to be replaced.</param>
        /// <param name="newValue">The string to replace all occurrences of oldValue.</param>
        /// <param name="defaultValue">The default value returned in case the value is null.</param>
        /// <returns>
        /// If the string is null the defaultValue is returned, otherwise a string that is equivalent to the current
        /// string except that all instances of oldValue are replaced with newValue. If oldValue is not found in the current
        /// instance, the method returns the current instance unchanged.
        /// </returns>
        public static string Replace(this string? value, string oldValue, string newValue, string defaultValue = null!) =>
            value != null ? value.Replace(oldValue, newValue) : defaultValue!;

        /// <summary>
        /// Returns a value indicating whether one of the specified substrings occurs within this string (OrdinalIgnoreCase).
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <param name="substrings">The substrings to seek.</param>
        /// <returns>True if one of substrings occurs within this string, or if value is the null and one of substrings is null as well.</returns>
        public static bool ContainsAny(this string value, params string[] substrings) =>
            value.ContainsAny(StringComparison.OrdinalIgnoreCase, substrings);

        /// <summary>
        /// Returns a value indicating whether one of the specified substrings occurs within this string.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <param name="stringComparison">One of the StringComparison enumeration values that specifies the rules for the search.</param>
        /// <param name="substrings">The substrings to seek.</param>
        /// <returns>True if one of substrings occurs within this string, or if value is the null and one of substrings is null as well.</returns>
        public static bool ContainsAny(this string? value, StringComparison stringComparison, params string?[] substrings) =>
            value == null ? Array.Exists(substrings, s => s == null) : Array.Exists(substrings, s => value.Contains(s!, stringComparison));

        /// <summary>
        /// Returns a value indicating whether none of the specified substrings occurs within this string.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <param name="stringComparison">One of the StringComparison enumeration values that specifies the rules for the search.</param>
        /// <param name="substrings">The substrings to seek.</param>
        /// <returns>True if none of substrings occurs within this string, or if value is the null and none of substrings is null as well.</returns>
        public static bool ContainsNone(this string value, StringComparison stringComparison, params string[] substrings) =>
            !value.ContainsAny(stringComparison, substrings);

        /// <summary>
        /// Returns a value indicating whether none of the specified substrings occurs within this string.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <param name="substrings">The substrings to seek.</param>
        /// <returns>True if none of substrings occurs within this string, or if value is the null and none of substrings is null as well.</returns>
        public static bool ContainsNone(this string? value, params string?[] substrings) =>
            value == null || !value.ContainsAny(StringComparison.OrdinalIgnoreCase, substrings);

        /// <summary>
        /// Returns a value indicating whether all specified substrings occurs within this string (OrdinalIgnoreCase).
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <param name="substrings">The substrings to seek.</param>
        /// <returns>True if all substrings occurs within this string, or if value is the null and all substrings is null as well.</returns>
        public static bool ContainsAll(this string? value, params string?[] substrings) =>
            value != null ? value.ContainsAll(StringComparison.OrdinalIgnoreCase, substrings) : substrings.IsEmpty() || Array.TrueForAll(substrings, e => e == null);

        /// <summary>
        /// Returns a value indicating whether all specified substrings occurs within this string.
        /// </summary>
        /// <param name="value">The string to seek.</param>
        /// <param name="stringComparison">One of the StringComparison enumeration values that specifies the rules for the search.</param>
        /// <param name="substrings">The substrings to seek.</param>
        /// <returns>True if all substrings occurs within this string, or if value is the null and all substrings is null as well.</returns>
        public static bool ContainsAll(this string value, StringComparison stringComparison, params string?[] substrings) =>
            value == null ? !Array.Exists(substrings, s => s != null) : !Array.Exists(substrings, s => !value.Contains(s!, stringComparison));

        /// <summary>
        /// Returns either the defaultValue if the given string value is empty (null or length == 0), otherwise return the string value.
        /// </summary>
        /// <param name="value">The string to check</param>
        /// <param name="defaultValue">The defaultValue to be returned if the given string value is empty.</param>
        /// <returns></returns>
        public static string DefaultIfEmpty(this string? value, string defaultValue) => value.IsEmpty() ? defaultValue : value!;

        /// <summary>
        /// Returns either the defaultValue if the given string value is blank (null or length (After trim) == 0), otherwise return the string value.
        /// </summary>
        /// <param name="value">The string to check</param>
        /// <param name="defaultValue">The defaultValue to be returned if the given string value is Blank.</param>
        /// <returns></returns>
        public static string DefaultIfBlank(this string? value, string defaultValue) => value.IsBlank() ? defaultValue : value!;

        /// <summary>
        /// Returns the first string in the given array which is not empty (not null and length > 0).
        /// </summary>
        /// <param name="values">The string values to seek.</param>
        /// <returns>The first string in the given array which is not empty, or null if none is empty.</returns>
        public static string? GetFirstNonEmpty(params string?[] values) => Array.Find(values, v => v.IsNotEmpty());

        /// <summary>
        /// Returns the first string in the given array which is not blank (not null and length (After trim) > 0).
        /// </summary>
        /// <param name="values">The string values to seek.</param>
        /// <returns>The first string in the given array which is not empty, or null if none is empty.</returns>
        public static string? GetFirstNonBlank(params string?[] values) => Array.Find(values, v => v.IsNotBlank());

        /// <summary>
        /// Checks the given strings are empty (null or length == 0)
        /// </summary>
        /// <param name="values">String values to check.</param>
        /// <returns>True if all given strings are empty.</returns>
        public static bool IsAllEmpty(params string?[] values) => !Array.Exists(values, v => !v.IsEmpty());

        /// <summary>
        /// Checks the given strings are blank (null or length (After trim) == 0)
        /// </summary>
        /// <param name="values">String values to check.</param>
        /// <returns>True if all given strings are blank.</returns>
        public static bool IsAllBlank(params string?[] values) => !Array.Exists(values, v => !v.IsBlank());

        /// <summary>
        /// Checks if one of the given strings is empty (null or length == 0)
        /// </summary>
        /// <param name="values">String values to check.</param>
        /// <returns>True if all given strings are empty.</returns>
        public static bool IsAnyEmpty(params string?[] values) => Array.Exists(values, v => v.IsEmpty());

        /// <summary>
        /// Checks if one of the given strings is blank (null or length (After trim) == 0)
        /// </summary>
        /// <param name="values">String values to check.</param>
        /// <returns>True if all given strings are blank.</returns>
        public static bool IsAnyBlank(params string?[] values) => Array.Exists(values, v => v.IsBlank());

        /// <summary>
        /// Removes all occurrences of the substring from the string.
        /// </summary>
        /// <param name="value">string value to seek.</param>
        /// <param name="substring">Substring to be removed from string.</param>
        /// <returns></returns>
        public static string? Remove(this string? value, string substring) => value?.Replace(substring, string.Empty);

        /// <summary>
        /// Repeats the given string n times.
        /// </summary>
        /// <param name="value">The string to repeat.</param>
        /// <param name="times">Times to repeat the string.</param>
        /// <returns></returns>
        public static string? Repeat(this string? value, int times)
        {
            if (value == null)
            {
                return null;
            }

            var repeated = new StringBuilder();

            for (var i = 0; i < times; i++)
            {
                repeated.Append(value);
            }

            return repeated.ToString();
        }

        /// <summary>
        /// Returns the given string value in the reverse order.
        /// </summary>
        /// <param name="value">The string value to invert.</param>
        /// <returns>An inverted string.</returns>
        public static string? Reverse(this string? value)
        {
            if (value == null)
            {
                return null;
            }

            var normal = value.ToCharArray();
            var reverse = new char[normal.Length];

            for (var i = 0; i < normal.Length; i++)
            {
                reverse[i] = normal[normal.Length - 1 - i];
            }

            return new string(reverse);
        }

        private static readonly IDictionary<char, char[]> map = new Dictionary<char, char[]>()
        {
            {'a', new char[] { 'á', 'à', 'â', 'ã', 'ä' } },
            {'e', new char[] { 'é', 'è', 'ê', 'ë' } },
            {'i', new char[] { 'í', 'ì', 'î', 'ï' } },
            {'o', new char[] { 'ó', 'ò', 'ô', 'õ', 'ö'} },
            {'u', new char[] { 'ú', 'ù', 'û', 'ü' } },
            {'c', new char[] { 'ç' } },
            {'A', new char[] { 'Á', 'À', 'Â', 'Ã', 'Ä' } },
            {'E', new char[] { 'É', 'È', 'Ê', 'Ë' } },
            {'I', new char[] { 'Í', 'Ì', 'Î', 'Ï' } },
            {'O', new char[] { 'Ó', 'Ò', 'Ô', 'Õ', 'Ö'} },
            {'U', new char[] { 'Ú', 'Ù', 'Û', 'Ü' } },
            {'C', new char[] { 'Ç' } }
        };

        /// <summary>
        /// Removes diacritics from the given string value.
        /// </summary>
        /// <param name="value">String value to remove diacritics.</param>
        /// <returns>String value without diacritics.</returns>
        public static string? RemoveDiacritics(this string? value)
        {
            if (value.IsBlank())
            {
                return value;
            }

            var sb = new StringBuilder(value);

            foreach (var kvp in map)
            {
                kvp.Value.ForEach(v => sb.Replace(v, kvp.Key));
            }

            value = sb.ToString();
            return value;
        }

        /// <summary>
        /// Retrieves a substring from this instance. The substring starts at 0 and has a specified length.
        /// </summary>
        /// <param name="value">String value to be truncated.</param>
        /// <param name="length">The number of characters in the substring up to the length.</param>
        /// <returns></returns>
        public static string? Truncate(this string? value, int length)
        {
            if (value != null)
            {
                value = value.Length > length ? value[..length] : value;
            }

            return value;
        }

        /// <summary>
        /// Replaces all non-numeric chars in the string.
        /// </summary>
        /// <param name="value">Numeric string to be 'cleaned'.</param>
        /// <param name="replace">String value used to replace non-numeric chars. (Default "")</param>
        /// <returns></returns>
        public static string? ReplaceNonNumeric(this string? value, string replace = "") => value == null ? null : NumericDigitsRegex().Replace(value, replace);

        /// <summary>
        /// Checks if the string value is a number.
        /// </summary>
        /// <param name="value">String to be checked.</param>
        /// <returns>True if the string value is a number, otherwise false.</returns>
        public static bool IsNumber(this string? value) => double.TryParse(value, out _);

        /// <summary>
        /// Checks if the string value is not a number.
        /// </summary>
        /// <param name="value">String to be checked.</param>
        /// <returns>True if the string value is not a number, otherwise false.</returns>
        public static bool IsNotNumber(this string? value) => !double.TryParse(value, out _);

        /// <summary>
        /// Returns a string if the value is null, empty or blank.
        /// is null => (null)
        /// is empty => (empty)
        /// is blank => (blank)
        /// </summary>
        /// <param name="value">string value to be checked.</param>
        /// <returns>A description for the string if null, empty or blank, otherwise return the vlaue.</returns>
        public static string DescribeIfNone(this string? value)
        {
            if (value == null)
            {
                return "(null)";
            }
            else if (value == "")
            {
                return "(empty)";
            }
            else if (value.Trim() == "")
            {
                return "(blank)";
            }

            return value;
        }

        /// <summary>
        /// Replaces the format arg placeholders in the value string with the string representations of corresponding args.
        /// A parameter supplies culture-specific formatting information.
        /// </summary>
        /// <param name="value">A composite format string</param>
        /// <param name="args">An object array that contains zero or more args to format.</param>
        /// <returns>A formatted string in which the format args placeholder have been replaced by the args values.</returns>
        public static string? Format(this string? value, params object[] args)
        {
            if (value == null)
            {
                return null;
            }

            return string.Format(value, args);
        }

        /// <summary>
        /// Replaces the format arg placeholders in the value string with the string representations of corresponding args.
        /// A parameter supplies culture-specific formatting information.
        /// </summary>
        /// <param name="value">A composite format string</param>
        /// <param name="provider">An object that supplies culture-specific formatting information</param>
        /// <param name="args">An object array that contains zero or more args to format.</param>
        /// <returns>A formatted string in which the format args placeholder have been replaced by the args values.</returns>
        public static string? Format(this string? value, IFormatProvider provider, params object[] args)
        {
            if (value == null)
            {
                return null;
            }

            return string.Format(provider, value, args);
        }

        /// <summary>
        /// Creates a new string with the original value appended by the give args.
        /// </summary>
        /// <param name="value">The original string value.</param>
        /// <param name="args">The string arguments to be appended</param>
        /// <returns>A new string with the original value appended by the give args or null, of the value is null.</returns>
        public static string? Append(this string? value, params string[] args)
        {
            if (value == null)
            {
                return null;
            }

            var sb = new StringBuilder(value);
            args.ForEach(arg => sb.Append(arg));

            return sb.ToString();
        }

        /// <summary>
        /// Determines whether this string and a specified System.String object have the
        /// same value. A parameter specifies the culture, case, and sort rules used in the
        /// comparison.
        ///
        /// </summary>
        /// <param name="value">The source instance string to compare.</param>
        /// <param name="other">The string to compare to this instance.</param>
        /// <param name="ignoreDiacritics">If true, will remove the diacritics from strings before compare them.</param>
        /// <param name="stringComparison">comparisonType is not a System.StringComparison value.</param>
        /// <returns>True if the value of the value parameter is the same as this string; otherwise, false</returns>
        public static bool Equals(this string? value, string? other, bool ignoreDiacritics, StringComparison stringComparison = StringComparison.Ordinal)
        {
            if ((value == null && other != null) || (value != null && other == null))
            {
                return false;
            }
            else if (value == null)
            {
                return true; //both are null.
            }
            else if (ignoreDiacritics)
            {
                return value.RemoveDiacritics()?.Equals(other.RemoveDiacritics(), stringComparison) == true;
            }

            return value.Equals(other, stringComparison);
        }

        [GeneratedRegex("[^0-9]")]
        private static partial Regex NumericDigitsRegex();
    }
}

