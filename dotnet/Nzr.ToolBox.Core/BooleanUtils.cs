using System.Linq;
namespace Nzr.ToolBox.Core
{
    /// <summary>
    /// Utility and extensions methods for Boolean types.
    /// </summary>
#if SINGLE
    public static partial class ToolBox
#else
    public static class BooleanUtils
#endif
    {
        /// <summary>
        /// Returns true the value is greater than 0.
        /// </summary>
        /// <param name="value">Value to be converted to boolean.</param>
        /// <returns>True the value is greater than 0, otherwise false.</returns>
        public static bool ToBool(this byte value) => value > 0;

        /// <summary>
        /// Returns true the value is greater than 0.
        /// </summary>
        /// <param name="value">Value to be converted to boolean.</param>
        /// <returns>True the value is greater than 0, otherwise false.</returns>
        public static bool ToBool(this sbyte value) => value > 0;

        /// <summary>
        /// Returns true the value is greater than 0.
        /// </summary>
        /// <param name="value">Value to be converted to boolean.</param>
        /// <returns>True the value is greater than 0, otherwise false.</returns>
        public static bool ToBool(this short value) => value > 0;

        /// <summary>
        /// Returns true the value is greater than 0.
        /// </summary>
        /// <param name="value">Value to be converted to boolean.</param>
        /// <returns>True the value is greater than 0, otherwise false.</returns>
        public static bool ToBool(this int value) => value > 0;

        /// <summary>
        /// Returns true the value is greater than 0.
        /// </summary>
        /// <param name="value">Value to be converted to boolean.</param>
        /// <returns>True the value is greater than 0, otherwise false.</returns>
        public static bool ToBool(this long value) => value > 0;

        /// <summary>
        /// Returns true the value is greater than 0.
        /// </summary>
        /// <param name="value">Value to be converted to boolean.</param>
        /// <returns>True the value is greater than 0, otherwise false.</returns>
        public static bool ToBool(this float value) => value > 0;

        /// <summary>
        /// Returns true the value is greater than 0.
        /// </summary>
        /// <param name="value">Value to be converted to boolean.</param>
        /// <returns>True the value is greater than 0, otherwise false.</returns>
        public static bool ToBool(this double value) => value > 0;

        /// <summary>
        /// Returns true the value is greater than 0.
        /// </summary>
        /// <param name="value">Value to be converted to boolean.</param>
        /// <returns>True the value is greater than 0, otherwise false.</returns>
        public static bool ToBool(this decimal value) => value > 0;

        /// <summary>
        /// Returns true the value is (Y, Yes, S, Sim, Si, Ja, Oui), otherwise false.
        /// </summary>
        /// <param name="value">Value to be converted to boolean.</param>
        /// <returns>True the string value is yes (or variations).</returns>
        public static bool ToBool(this string value) =>
#if SINGLE
            YES.Any(y => y.Equals(value, System.StringComparison.OrdinalIgnoreCase));
#else
            Constants.YES.Any(y => y.Equals(value, System.StringComparison.OrdinalIgnoreCase));
#endif

        /// <summary>
        /// Safe checks if the value is not null and true.
        /// </summary>
        /// <param name="value">Value to be checked.</param>
        /// <returns>True if the value is not null and true.</returns>
        public static bool IsTrue(this bool? value) => value.HasValue && value.Value;

        /// <summary>
        /// Safe checks if the value is not null and false.
        /// </summary>
        /// <param name="value">Value to be checked.</param>
        /// <returns>True if the value is not null and false.</returns>
        public static bool IsFalse(this bool? value) => !value.HasValue || !value.Value;

        /// <summary>
        /// Returns yes or no based on the boolean value.
        /// The string values are optional (default yes, no) and can be replaced.
        /// </summary>
        /// <param name="value">Value to be checked.</param>
        /// <param name="yes">String to be returned in case of value is true.</param>
        /// <param name="no">String to be returned in case of value is false.</param>
        /// <returns>Yes or no, based on the boolean value.</returns>
        public static string Describe(this bool value, string yes = "yes", string no = "no") => value ? yes : no;


        /// <summary>
        /// Returns yes or no based on the boolean value.
        /// The string values are optional (default yes, no) and can be replaced.
        /// </summary>
        /// <param name="value">Value to be checked.</param>
        /// <param name="yes">String to be returned in case of value is true.</param>
        /// <param name="no">String to be returned in case of value is false.</param>
        /// <param name="null">String to be returned int case of the value is null</param>
        /// <returns>Yes or no, based on the boolean value.</returns>
        public static string Describe(this bool? value, string yes = "yes", string no = "no", string @null = "null")
        {
#pragma warning disable IDE0046 // Convert to conditional expression
            if (value.HasValue)
#pragma warning restore IDE0046 // Convert to conditional expression
            {
                return value.Value ? yes : no;
            }
            else
            {
                return @null;
            }
        }

        /// <summary>
        /// Checks if all values are true.
        /// </summary>
        /// <param name="values">Values to be checked.</param>
        /// <returns>True if all values are true, otherwise false.</returns>
        public static bool IsAllTrue(params bool[] values) => !values.Any(b => !b);

        /// <summary>
        /// Checks if any value is true.
        /// </summary>
        /// <param name="values">Values to be checked.</param>
        /// <returns>True if any value is true, otherwise false.</returns>
        public static bool IsAnyTrue(params bool[] values) => values.Any(b => b);

        /// <summary>
        /// Checks if all values are true.
        /// </summary>
        /// <param name="values">Values to be checked.</param>
        /// <returns>True if all values are true, otherwise false.</returns>
        public static bool IsAllFalse(params bool[] values) => !values.Any(b => b);

        /// <summary>
        /// Checks if any value is false.
        /// </summary>
        /// <param name="values">Values to be checked.</param>
        /// <returns>True if any value is false, otherwise false.</returns>
        public static bool IsAnyFalse(params bool[] values) => values.Any(b => !b);
    }
}
