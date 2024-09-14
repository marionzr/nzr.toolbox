using System;

namespace Nzr.ToolBox.Core
{
    /// <summary>
    /// Utility and extensions methods for DateTime types.
    /// </summary>
#if SINGLE
    public static partial class ToolBox
#else
    public static class DateTimeUtils
#endif
    {
        private static readonly DateTime EPOC_BASE = new DateTime(1970, 1, 1);

        /// <summary>
        /// Gets the Unix Epoch Time.
        /// </summary>
        /// <param name="value">DateTime to be converted to Epoch Time.</param>
        /// <returns>The Unix Epoch Time.</returns>
        public static long ToEpoch(this DateTime value) => (int)(value - EPOC_BASE).TotalSeconds;

        /// <summary>
        /// Gets the DateTime from Unix Epoch Time.
        /// </summary>
        /// <param name="epochTime">Unix Epoch Time</param>
        /// <returns>The DateTim from Epoch Time.</returns>
        public static DateTime FromEpoch(this long epochTime) => EPOC_BASE.AddSeconds(epochTime);

        /// <summary>
        /// Checks if two dates are on the same day ignoring time.
        /// </summary>
        /// <param name="dateTime1">The left dateTime object.</param>
        /// <param name="dateTime2">The right dateTime object. If null, DateTime.Now is used to compare.</param>
        /// <returns></returns>
        public static bool IsSameDay(this DateTime dateTime1, DateTime? dateTime2 = null)
        {
            var dateTime = dateTime2 ?? DateTime.Now;
            return dateTime1.Year == dateTime.Year && dateTime1.Month == dateTime.Month && dateTime1.Day == dateTime.Day;
        }

        /// <summary>
        /// Checks if the value of this instance is equal to the value of the specified System.DateTime instance.
        /// </summary>
        /// <param name="dateTime1"></param>
        /// <param name="dateTime2"></param>
        /// <param name="toleranceInMs"></param>
        /// <returns></returns>
        public static bool Equals(this DateTime dateTime1, DateTime dateTime2, int toleranceInMs) => Math.Abs((dateTime1 - dateTime2).TotalMilliseconds) <= toleranceInMs;

        /// <summary>
        /// Returns a new System.DateTime that subtracts the specified number of days from the value
        /// of this instance.
        /// </summary>
        /// <param name="dateTime">The DateTime instance.</param>
        /// <param name="value">A number of whole and fractional days. The value parameter can be negative or positive.</param>
        ///
        /// <returns>An object whose value is the sum of the date and time represented by this instance and the number of days represented by value.</returns>
        public static DateTime SubtractDays(this DateTime dateTime, double value) => dateTime.AddDays(value * -1);

        /// <summary>
        /// Returns a new System.DateTime that subtracts the specified number of hours from the
        /// value of this instance.
        /// </summary>
        /// Parameters:
        ///   value:
        /// A number of whole and fractional hours. The value parameter can be negative or
        /// positive.
        ///
        /// <returns>
        /// An object whose value is the sum of the date and time represented by this instance
        /// and the number of hours represented by value.</returns>
        public static DateTime SubtractHours(this DateTime dateTime, double value) => dateTime.AddHours(value * -1);

        /// <summary>
        /// Returns a new System.DateTime that subtracts the specified number of milliseconds
        /// from the value of this instance.
        /// </summary>
        /// Parameters:
        ///   value:
        /// A number of whole and fractional milliseconds. The value parameter can be negative
        /// or positive. Note that this value is rounded to the nearest integer.
        ///
        /// <returns>
        /// An object whose value is the sum of the date and time represented by this instance
        /// and the number of milliseconds represented by value.</returns>
        public static DateTime SubtractMilliseconds(this DateTime dateTime, double value) => dateTime.AddMilliseconds(value * -1);

        /// <summary>
        /// Returns a new System.DateTime that subtracts the specified number of minutes from the
        /// value of this instance.
        /// </summary>
        /// Parameters:
        ///   value:
        /// A number of whole and fractional minutes. The value parameter can be negative
        /// or positive.
        ///
        /// <returns>
        /// An object whose value is the sum of the date and time represented by this instance
        /// and the number of minutes represented by value.</returns>
        public static DateTime SubtractMinutes(this DateTime dateTime, double value) => dateTime.AddMinutes(value * -1);

        /// <summary>
        /// Returns a new System.DateTime that subtracts the specified number of months from the
        /// value of this instance.
        /// </summary>
        /// Parameters:
        ///   value:
        /// A number of months. The months parameter can be negative or positive.
        ///
        /// <returns>
        /// An object whose value is the sum of the date and time represented by this instance
        /// and months.</returns>
        public static DateTime SubtractMonths(this DateTime dateTime, int value) => dateTime.AddMonths(value * -1);

        /// <summary>
        /// Returns a new System.DateTime that subtracts the specified number of seconds from the
        /// value of this instance.
        /// </summary>
        /// Parameters:
        ///   value:
        /// A number of whole and fractional seconds. The value parameter can be negative
        /// or positive.
        ///
        /// <returns>
        /// An object whose value is the sum of the date and time represented by this instance
        /// and the number of seconds represented by value.</returns>
        public static DateTime SubtractSeconds(this DateTime dateTime, double value) => dateTime.AddSeconds(value * -1);

        /// <summary>
        /// Returns a new System.DateTime that subtracts the specified number of years from the
        /// value of this instance.
        /// </summary>
        /// Parameters:
        ///   value:
        /// A number of years. The value parameter can be negative or positive.
        ///
        /// <returns>
        /// An object whose value is the sum of the date and time represented by this instance
        /// and the number of years represented by value.</returns>
        public static DateTime SubtractYears(this DateTime dateTime, int value) => dateTime.AddYears(value * -1);
    }
}
