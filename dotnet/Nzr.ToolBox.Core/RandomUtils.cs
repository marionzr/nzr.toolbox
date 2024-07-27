using System;
using System.Text;

namespace Nzr.ToolBox.Core
{
    /// <summary>
    /// Utility methods for Randomized valued.
    /// </summary>
#if SINGLE
    public static partial class ToolBox
#else
    public static class RandomUtils
#endif
    {
        /// <summary>
        /// Returns a random boolean value.
        /// </summary>
        /// <param name="seed">A number used to calculate a starting value for the pseudo-random number sequence. (optional)</param>
        /// <returns>A random boolean value.</returns>
        public static bool RandomBoolean(int? seed = null)
        {
            var random = new Random(seed ?? Guid.NewGuid().GetHashCode());
            return random.Next(int.MinValue, int.MaxValue) % 2 == 0;
        }

        /// <summary>
        /// Returns a byte that is within a specified range.
        /// </summary>
        /// <param name="min">The inclusive lower bound of the random number returned.</param>
        /// <param name="max">The exclusive upper bound of the random number returned. maxValue must be greater.</param>
        /// <param name="seed">A number used to calculate a starting value for the pseudo-random number sequence. (optional)</param>
        /// <returns>A byte greater than or equal to minValue and less than maxValue;
        /// that is, the range of return values includes minValue but not maxValue. If minValue
        /// equals maxValue, minValue is returned</returns>
        public static byte RandomByte(byte min = 0, byte max = byte.MaxValue, int? seed = null)
        {
            var random = new Random(seed ?? Guid.NewGuid().GetHashCode());
            return (byte)random.Next(min, max);
        }

        /// <summary>
        /// Returns a random short that is within a specified range.
        /// </summary>
        /// <param name="min">The inclusive lower bound of the random number returned.</param>
        /// <param name="max">The exclusive upper bound of the random number returned. maxValue must be greater.</param>
        /// <param name="seed">A number used to calculate a starting value for the pseudo-random number sequence. (optional)</param>
        /// <returns>A 16-bit signed short greater than or equal to minValue and less than maxValue;
        /// that is, the range of return values includes minValue but not maxValue. If minValue
        /// equals maxValue, minValue is returned</returns>
        public static short RandomShort(short min = 0, short max = short.MaxValue, int? seed = null)
        {
            var random = new Random(seed ?? DateTime.Now.Millisecond);
            return (short)random.Next(min, max);
        }

        /// <summary>
        /// Returns a random integer that is within a specified range.
        /// </summary>
        /// <param name="min">The inclusive lower bound of the random number returned.</param>
        /// <param name="max">The exclusive upper bound of the random number returned. maxValue must be greater.</param>
        /// <param name="seed">A number used to calculate a starting value for the pseudo-random number sequence. (optional)</param>
        /// <returns>A 32-bit signed integer greater than or equal to minValue and less than maxValue;
        /// that is, the range of return values includes minValue but not maxValue. If minValue
        /// equals maxValue, minValue is returned</returns>
        public static int RandomInt(int min = 0, int max = int.MaxValue, int? seed = null)
        {
            var random = new Random(seed ?? DateTime.Now.Millisecond);
            return random.Next(min, max);
        }

        /// <summary>
        /// Returns a random long that is within a specified range.
        /// </summary>
        /// <param name="min">The inclusive lower bound of the random number returned.</param>
        /// <param name="max">The exclusive upper bound of the random number returned. maxValue must be greater.</param>
        /// <param name="seed">A number used to calculate a starting value for the pseudo-random number sequence. (optional)</param>
        /// <returns>A 64-bit signed long greater than or equal to minValue and less than maxValue;
        /// that is, the range of return values includes minValue but not maxValue. If minValue
        /// equals maxValue, minValue is returned</returns>
        public static long RandomLong(long min = 0, long max = long.MaxValue, int? seed = null)
        {
            var random = new Random(seed ?? DateTime.Now.Millisecond);

            var buf = new byte[8];
            random.NextBytes(buf);
            var value = BitConverter.ToInt64(buf, 0);

            return (Math.Abs(value % (max - min)) + min);
        }

        /// <summary>
        /// Returns a random double number that is greater than or equal to 0.0 and less than 1.0 times multiplier.
        /// </summary>
        /// <param name="multiplier">Used to multiply the result (from 0.0 to 1.0). (Optional, default 1.0).</param>
        /// <param name="seed">A number used to calculate a starting value for the pseudo-random number sequence. (optional)</param>
        /// <returns>A double-precision floating point number that is greater than or equal to 0.0 and less than 1.0 times multiplier.</returns>
        public static double RandomDouble(double multiplier = 1.0, int? seed = null)
        {
            var random = new Random(seed ?? DateTime.Now.Millisecond);
            return random.NextDouble() * multiplier;
        }

        /// <summary>
        /// Returns a random decimal number that is greater than or equal to 0.0 and less than 1.0 times multiplier.
        /// </summary>
        /// <param name="multiplier">Used to multiply the result (from 0.0 to 1.0). (Optional, default 1.0).</param>
        /// <param name="seed">A number used to calculate a starting value for the pseudo-random number sequence. (optional)</param>
        /// <returns>A double-precision floating point number that is greater than or equal to 0.0 and less than 1.0 times multiplier.</returns>
        public static decimal RandomDecimal(decimal multiplier = 1.0M, int? seed = null)
        {
            var random = new Random(seed ?? DateTime.Now.Millisecond);
            return (decimal)random.NextDouble() * multiplier;
        }

        /// <summary>
        /// Returns a random float number that is greater than or equal to 0.0 and less than 1.0 times multiplier.
        /// </summary>
        /// <param name="multiplier">Used to multiply the result (from 0.0 to 1.0). (Optional, default 1.0).</param>
        /// <param name="seed">A number used to calculate a starting value for the pseudo-random number sequence. (optional)</param>
        /// <returns>A double-precision floating point number that is greater than or equal to 0.0 and less than 1.0 times multiplier.</returns>
        public static float RandomFloat(double multiplier = 1.0, int? seed = null)
        {
            var random = new Random(seed ?? DateTime.Now.Millisecond);
            return (float)(random.NextDouble() * multiplier);
        }

        /// <summary>
        /// Returns a random string with the given length;
        /// </summary>
        /// <param name="length">Length of the generated string.</param>
        /// <param name="letters">Group of letters used to generated the random string. Optional</param>
        /// <param name="numbers">Group of numbers used to generated the random string. Optional</param>
        /// <param name="symbols">Group of symbols used to generated the random string. Optional</param>
        /// <returns>A random string.</returns>
        public static string RandomString(uint length, string? letters = RANDOM_LETTERS, string? numbers = RANDOM_NUMBER,
            string? symbols = RANDOM_SYMBOLS)
        {
            var res = new StringBuilder();
            var random = new Random(DateTime.Now.Millisecond);

#if SINGLE
            if (IsAllBlank(letters, numbers, symbols))
#else
            if (StringUtils.IsAllBlank(letters, numbers, symbols))
#endif
            {
                throw new ArgumentException("At least one of the char groups (letter, numbers, symbols) must be provided.");
            }

            var charsLength = (letters?.Length ?? 0) + (numbers?.Length ?? 0) + (symbols?.Length ?? 0);
            var chars = new StringBuilder(charsLength);
            chars.Append(letters).Append(numbers).Append(symbols);

            while (res.Length < length)
            {
                var i = random.Next(0, charsLength);
                res.Append(chars[i]);
            }

            return res.ToString();
        }

        /// <summary>
        /// Letters (the alphabet) used in the Random methods.
        /// </summary>
        public const string RANDOM_LETTERS = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

        /// <summary>
        /// Letters (the numbers) used in the Random methods.
        /// </summary>
        public const string RANDOM_NUMBER = "0123456789";

        /// <summary>
        /// Symbols <![CDATA[(!?,.;:@#$%&*()-_+={[}]^~`´<>)]]> used in the Random methods.
        /// </summary>
        public const string RANDOM_SYMBOLS = "!?,.;:@#$%&*()-_+={[}]^~`´<>";
    }
}
