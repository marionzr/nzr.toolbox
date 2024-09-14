using System;
using System.Linq;

namespace Nzr.ToolBox.Core
{
    /// <summary>
    /// Utility and extensions methods for Number (byte, short, int, long, float, double, decimal) types.
    /// </summary>
#if SINGLE
    public static partial class ToolBox
#else
    public static class NumberUtils
#endif
    {
        /// <summary>
        /// Returns the maximum value within the values.
        /// </summary>
        /// <param name="values">Values to be evaluated.</param>
        /// <returns>The maximum value within the values.</returns>
        public static byte Max(params byte[] values) => values.Max();

        /// <summary>
        /// Returns the maximum value within the values.
        /// </summary>
        /// <param name="values">Values to be evaluated.</param>
        /// <returns>The maximum value within the values.</returns>
        public static short Max(params short[] values) => values.Max();

        /// <summary>
        /// Returns the maximum value within the values.
        /// </summary>
        /// <param name="values">Values to be evaluated.</param>
        /// <returns>The maximum value within the values.</returns>
        public static int Max(params int[] values) => values.Max();

        /// <summary>
        /// Returns the maximum value within the values.
        /// </summary>
        /// <param name="values">Values to be evaluated.</param>
        /// <returns>The maximum value within the values.</returns>
        public static long Max(params long[] values) => values.Max();

        /// <summary>
        /// Returns the maximum value within the values.
        /// </summary>
        /// <param name="values">Values to be evaluated.</param>
        /// <returns>The maximum value within the values.</returns>
        public static float Max(params float[] values) => values.Max();

        /// <summary>
        /// Returns the maximum value within the values.
        /// </summary>
        /// <param name="values">Values to be evaluated.</param>
        /// <returns>The maximum value within the values.</returns>
        public static double Max(params double[] values) => values.Max();

        /// <summary>
        /// Returns the maximum value within the values.
        /// </summary>
        /// <param name="values">Values to be evaluated.</param>
        /// <returns>The maximum value within the values.</returns>
        public static decimal Max(params decimal[] values) => values.Max();

        /// <summary>
        /// Returns the minimum value within the values.
        /// </summary>
        /// <param name="values">Values to be evaluated.</param>
        /// <returns>The minimum value within the values.</returns>
        public static byte Min(params byte[] values) => values.Min();

        /// <summary>
        /// Returns the minimum value within the values.
        /// </summary>
        /// <param name="values">Values to be evaluated.</param>
        /// <returns>The minimum value within the values.</returns>
        public static short Min(params short[] values) => values.Min();

        /// <summary>
        /// Returns the minimum value within the values.
        /// </summary>
        /// <param name="values">Values to be evaluated.</param>
        /// <returns>The minimum value within the values.</returns>
        public static int Min(params int[] values) => values.Min();

        /// <summary>
        /// Returns the minimum value within the values.
        /// </summary>
        /// <param name="values">Values to be evaluated.</param>
        /// <returns>The minimum value within the values.</returns>
        public static long Min(params long[] values) => values.Min();

        /// <summary>
        /// Returns the minimum value within the values.
        /// </summary>
        /// <param name="values">Values to be evaluated.</param>
        /// <returns>The minimum value within the values.</returns>
        public static float Min(params float[] values) => values.Min();

        /// <summary>
        /// Returns the minimum value within the values.
        /// </summary>
        /// <param name="values">Values to be evaluated.</param>
        /// <returns>The minimum value within the values.</returns>
        public static double Min(params double[] values) => values.Min();

        /// <summary>
        /// Returns the minimum value within the values.
        /// </summary>
        /// <param name="values">Values to be evaluated.</param>
        /// <returns>The minimum value within the values.</returns>
        public static decimal Min(params decimal[] values) => values.Min();

        /// <summary>
        /// Returns the average of the values.
        /// </summary>
        /// <param name="values">Values to be evaluated.</param>
        /// <returns>The average of the values.</returns>
        public static double Average(params byte[] values)
        {
            var sum = 0;
            values.ForEach(v => sum += v);
            return sum / (double)values.Length;
        }

        /// <summary>
        /// Returns the average of the values.
        /// </summary>
        /// <param name="values">Values to be evaluated.</param>
        /// <returns>The average of the values.</returns>
        public static double Average(params short[] values)
        {
            long sum = 0;
            values.ForEach(v => sum += v);
            return sum / (double)values.Length;
        }

        /// <summary>
        /// Returns the average of the values.
        /// </summary>
        /// <param name="values">Values to be evaluated.</param>
        /// <returns>The average of the values.</returns>
        public static double Average(params int[] values) => values.Average();

        /// <summary>
        /// Returns the average of the values.
        /// </summary>
        /// <param name="values">Values to be evaluated.</param>
        /// <returns>The average of the values.</returns>
        public static double Average(params long[] values) => values.Average();

        /// <summary>
        /// Returns the average of the values.
        /// </summary>
        /// <param name="values">Values to be evaluated.</param>
        /// <returns>The average of the values.</returns>
        public static double Average(params float[] values) => values.Average();

        /// <summary>
        /// Returns the average of the values.
        /// </summary>
        /// <param name="values">Values to be evaluated.</param>
        /// <returns>The average of the values.</returns>
        public static double Average(params double[] values) => values.Average();

        /// <summary>
        /// Returns the average of the values.
        /// </summary>
        /// <param name="values">Values to be evaluated.</param>
        /// <returns>The average of the values.</returns>
        public static double Average(params decimal[] values)
        {
            decimal sum = 0;
            values.ForEach(v => sum += v);
            return (double)(sum / values.Length);
        }

        /// <summary>
        /// Returns the sum of the values.
        /// </summary>
        /// <param name="values">Values to be evaluated.</param>
        /// <returns>The sum of the value.</returns>
        public static int Sum(params byte[] values)
        {
            var sum = 0;
            values.ForEach(v => sum += v);
            return sum;
        }

        /// <summary>
        /// Returns the sum of the values.
        /// </summary>
        /// <param name="values">Values to be evaluated.</param>
        /// <returns>The sum of the value.</returns>
        public static int Sum(params short[] values)
        {
            var sum = 0;
            values.ForEach(v => sum += v);
            return sum;
        }

        /// <summary>
        /// Returns the sum of the values.
        /// </summary>
        /// <param name="values">Values to be evaluated.</param>
        /// <returns>The sum of the value.</returns>
        public static int Sum(params int[] values) => values.Sum();

        /// <summary>
        /// Returns the sum of the values.
        /// </summary>
        /// <param name="values">Values to be evaluated.</param>
        /// <returns>The sum of the value.</returns>
        public static long Sum(params long[] values) => values.Sum();

        /// <summary>
        /// Returns the sum of the values.
        /// </summary>
        /// <param name="values">Values to be evaluated.</param>
        /// <returns>The sum of the value.</returns>
        public static float Sum(params float[] values) => values.Sum();

        /// <summary>
        /// Returns the sum of the values.
        /// </summary>
        /// <param name="values">Values to be evaluated.</param>
        /// <returns>The sum of the value.</returns>
        public static double Sum(params double[] values) => values.Sum();

        /// <summary>
        /// Returns the sum of the values.
        /// </summary>
        /// <param name="values">Values to be evaluated.</param>
        /// <returns>The sum of the value.</returns>
        public static decimal Sum(params decimal[] values) => values.Sum();

        /// <summary>
        /// Returns the absolute value of a number.
        /// </summary>
        /// <returns> A number >= 0</returns>
        public static short Abs(this sbyte value) => Math.Abs(value);

        /// <summary>
        /// Returns the absolute value of a number.
        /// </summary>
        /// <returns> A number >= 0</returns>
        public static short Abs(this short value) => Math.Abs(value);

        /// <summary>
        /// Returns the absolute value of a number.
        /// </summary>
        /// <returns> A number >= 0</returns>
        public static int Abs(this int value) => Math.Abs(value);

        /// <summary>
        /// Returns the absolute value of a number.
        /// </summary>
        /// <returns> A number >= 0</returns>
        public static long Abs(this long value) => Math.Abs(value);

        /// <summary>
        /// Returns the absolute value of a number.
        /// </summary>
        /// <returns> A number >= 0</returns>
        public static float Abs(this float value) => Math.Abs(value);

        /// <summary>
        /// Returns the absolute value of a number.
        /// </summary>
        /// <returns> A number >= 0</returns>
        public static double Abs(this double value) => Math.Abs(value);

        /// <summary>
        /// Returns the absolute value of a number.
        /// </summary>
        /// <returns> A number >= 0</returns>
        public static decimal Abs(this decimal value) => Math.Abs(value);


        /// <summary>
        /// Converts the number value to a binary format.
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <param name="include0b">>Prefix the result with 0b. (Optional, default false)</param>
        /// <returns>Value in binary format.</returns>
        public static string ToBinary(this byte value, bool include0b = false) => ToBinary((long)value, include0b);


        /// <summary>
        /// Converts the number value to a binary format.
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <param name="include0b">>Prefix the result with 0b. (Optional, default false)</param>
        /// <returns>Value in binary format.</returns>
        public static string ToBinary(this short value, bool include0b = false) => ToBinary((long)value, include0b);

        /// <summary>
        /// Converts the number value to a binary format.
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <param name="include0b">>Prefix the result with 0b. (Optional, default false)</param>
        /// <returns>Value in binary format.</returns>
        public static string ToBinary(this int value, bool include0b = false) => ToBinary((long)value, include0b);

        /// <summary>
        /// Converts the number value to a binary format.
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <param name="include0b">>Prefix the result with 0b. (Optional, default false)</param>
        /// <returns>Value in binary format.</returns>
        public static string ToBinary(this long value, bool include0b = false)
        {
            var result = Convert.ToString(value, 2);
            return include0b ? "0b" + result : result;
        }


        /// <summary>
        /// Converts the number value to a hexadecimal format.
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <param name="include0x">Prefix the result with 0x. (Optional, default true)</param>
        /// <returns>Value in hexadecimal format.</returns>
        public static string ToHexadecimal(this byte value, bool include0x = true) => ToHexadecimal((long)value, include0x);

        /// <summary>
        /// Converts the number value to a hexadecimal format.
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <param name="include0x">Prefix the result with 0x. (Optional, default true)</param>
        /// <returns>Value in hexadecimal format.</returns>
        public static string ToHexadecimal(this short value, bool include0x = true) => ToHexadecimal((long)value, include0x);

        /// <summary>
        /// Converts the number value to a hexadecimal format.
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <param name="include0x">Prefix the result with 0x. (Optional, default true)</param>
        /// <returns>Value in hexadecimal format.</returns>
        public static string ToHexadecimal(this int value, bool include0x = true) => ToHexadecimal((long)value, include0x);

        /// <summary>
        /// Converts the number value to a hexadecimal format.
        /// </summary>
        /// <param name="value">Value to be converted.</param>
        /// <param name="include0x">Prefix the result with 0x. (Optional, default true)</param>
        /// <returns>Value in hexadecimal format.</returns>
        public static string ToHexadecimal(this long value, bool include0x = true)
        {
            var result = Convert.ToString(value, 16).ToUpper();
            return include0x ? "0x" + result : result;
        }

        /// <summary>
        /// Returns a string that representing the numeric value, but right-aligned and padded
        /// on the left with the required amount of padding characters as needed to create have a
        /// string with the given maxWidth.
        /// </summary>
        /// <param name="value">The byte instance to be converted to string, then left padded.</param>
        /// <param name="maxWidth">The size of the resulting string including, if needed, any additional padding characters</param>
        /// <param name="padding">The padding character</param>
        /// <returns>A string that representing the numeric value, but right-aligned and padded
        /// on the left with the required amount of padding characters as needed to create have a
        /// string with the given maxWidth</returns>
        public static string PadLeft(this byte value, int maxWidth, char padding) => PadLeft((short)value, maxWidth, padding);

        /// <summary>
        /// Returns a string that representing the numeric value, but right-aligned and padded
        /// on the left with the required amount of padding characters as needed to create have a
        /// string with the given maxWidth.
        /// </summary>
        /// <param name="value">The byte instance to be converted to string, then left padded.</param>
        /// <param name="maxWidth">The size of the resulting string including, if needed, any additional padding characters</param>
        /// <param name="padding">The padding character</param>
        /// <returns>A string that representing the numeric value, but right-aligned and padded
        /// on the left with the required amount of padding characters as needed to create have a
        /// string with the given maxWidth</returns>
        public static string PadLeft(this short value, int maxWidth, char padding) => PadLeft((int)value, maxWidth, padding);

        /// <summary>
        /// Returns a string that representing the numeric value, but right-aligned and padded
        /// on the left with the required amount of padding characters as needed to create have a
        /// string with the given maxWidth.
        /// </summary>
        /// <param name="value">The byte instance to be converted to string, then left padded.</param>
        /// <param name="maxWidth">The size of the resulting string including, if needed, any additional padding characters</param>
        /// <param name="padding">The padding character</param>
        /// <returns>A string that representing the numeric value, but right-aligned and padded
        /// on the left with the required amount of padding characters as needed to create have a
        /// string with the given maxWidth</returns>
        public static string PadLeft(this int value, int maxWidth, char padding) => PadLeft((long)value, maxWidth, padding);

        /// <summary>
        /// Returns a string that representing the numeric value, but right-aligned and padded
        /// on the left with the required amount of padding characters as needed to create have a
        /// string with the given maxWidth.
        /// </summary>
        /// <param name="value">The byte instance to be converted to string, then left padded.</param>
        /// <param name="maxWidth">The size of the resulting string including, if needed, any additional padding characters</param>
        /// <param name="padding">The padding character</param>
        /// <returns>A string that representing the numeric value, but right-aligned and padded
        /// on the left with the required amount of padding characters as needed to create have a
        /// string with the given maxWidth</returns>
        public static string PadLeft(this long value, int maxWidth, char padding) => value.ToString().PadLeft(maxWidth, padding);
    }
}
