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
            DateTime dateTime = dateTime2 ?? DateTime.Now;
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
    }
}
