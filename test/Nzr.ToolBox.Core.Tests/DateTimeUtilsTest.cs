using System;
using Xunit;

namespace Nzr.ToolBox.Core.Tests
{
    public class DateTimeUtilsTest
    {
        [Fact]
        public void ToEpoch_WithDateTime_ShouldReturnEpochTime()
        {
            // Arrange

            // Act

            var epoch = new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc).ToEpoch();

            // Assert

            Assert.Equal(1577836800, epoch);
        }

        [Fact]
        public void FromEpoch_WithEpoch_ShouldReturnDateTime()
        {
            // Arrange

            // Act

            var dateTime = 1200000000L.FromEpoch();

            // Assert

            Assert.Equal(new DateTime(2008, 1, 10, 21, 20, 0, DateTimeKind.Local), dateTime);
        }

        [Fact]
        public void IsSameDay_WithCurrentDayAndNull_ShouldReturnTrue()
        {
            // Arrange

            var dateTime = new DateTime(DateTime.Now.Ticks, DateTimeKind.Local);

            // Act

            var result = dateTime.IsSameDay();

            // Assert

            Assert.True(result);
        }

        [Fact]
        public void IsSameDay_WithDatesWithSameDay_ShouldReturnTrue()
        {
            // Arrange

            var dateTime1 = new DateTime(2019, 11, 12, 23, 59, 0, DateTimeKind.Local);
            var dateTime2 = new DateTime(2019, 11, 12, 14, 35, 1, DateTimeKind.Local);

            // Act

            var result = dateTime1.IsSameDay(dateTime2);

            // Assert

            Assert.True(result);
        }

        [Fact]
        public void IsSameDay_WithDatesWithoutSameDay_ShouldReturnFalse()
        {
            // Arrange

            var dateTime1 = new DateTime(2019, 11, 12, 23, 59, 0, DateTimeKind.Local);
            var dateTime2 = new DateTime(2019, 10, 11, 23, 59, 0, DateTimeKind.Local);
            var dateTime3 = new DateTime(2019, 09, 10, 23, 59, 0, DateTimeKind.Local);
            var dateTime4 = new DateTime(2018, 08, 09, 23, 59, 0, DateTimeKind.Local);

            // Act

            var result1 = dateTime1.IsSameDay(dateTime2);
            var result2 = dateTime2.IsSameDay(dateTime3);
            var result3 = dateTime3.IsSameDay(dateTime4);

            // Assert

            Assert.False(result1);
            Assert.False(result2);
            Assert.False(result3);
        }

        [Fact]
        public void Equals_WithMillisOfDiffAndNoTolerance_ShouldReturnFalse()
        {
            // Arrange

            var dateTime1 = new DateTime(2019, 11, 12, 23, 59, 0, 1, DateTimeKind.Local);
            var dateTime2 = new DateTime(2019, 11, 12, 23, 59, 0, 2, DateTimeKind.Local);

            // Act

            var result = dateTime1.Equals(dateTime2, 0);

            // Assert

            Assert.False(result);
        }

        [Fact]
        public void Equals_WithMillisOfDiffAndWithTolerance_ShouldReturnTrue()
        {
            // Arrange

            var dateTime1 = new DateTime(2019, 11, 12, 23, 59, 0, 1, DateTimeKind.Local);
            var dateTime2 = new DateTime(2019, 11, 12, 23, 59, 0, 2, DateTimeKind.Local);

            // Act

            var result = dateTime1.Equals(dateTime2, 2);

            // Assert

            Assert.True(result);
        }

        [Fact]
        public void Subtract_WithOneYear_ShouldReturnLastYear()
        {
            // Arrange

            var now = DateTime.Now;

            // Act

            var dateTime = now.SubtractYears(1);

            // Assert

            Assert.Equal(dateTime.Year, now.Year - 1);
        }

        [Fact]
        public void Subtract_WithOneMonth_ShouldReturnLastMonth()
        {
            // Arrange

            var now = DateTime.Now;

            // Act

            var dateTime = now.SubtractMonths(1);

            // Assert

            Assert.True((now - dateTime).TotalDays >= 28);
        }

        [Fact]
        public void Subtract_WithOneDay_ShouldReturnYesterday()
        {
            // Arrange

            var now = DateTime.Now;

            // Act

            var dateTime = now.SubtractDays(1);

            // Assert

            Assert.Equal(1, (now - dateTime).TotalDays);
        }

        [Fact]
        public void Subtract_WithOneHour_ShouldReturnPastHour()
        {
            // Arrange

            var now = DateTime.Now;

            // Act

            var dateTime = now.SubtractHours(1);

            // Assert

            Assert.Equal(1, (now - dateTime).TotalHours);
        }

        [Fact]
        public void Subtract_WithOneMinute_ShouldReturnPastMinute()
        {
            // Arrange

            var now = DateTime.Now;

            // Act

            var dateTime = now.SubtractMinutes(1);

            // Assert

            Assert.Equal(1, (now - dateTime).TotalMinutes);
        }

        [Fact]
        public void Subtract_WithOneSecond_ShouldReturnPastSecond()
        {
            // Arrange

            var now = DateTime.Now;

            // Act

            var dateTime = now.SubtractSeconds(1);

            // Assert

            Assert.Equal(1, (now - dateTime).TotalSeconds);
        }

        [Fact]
        public void Subtract_WithOneMilis_ShouldReturnPastMilis()
        {
            // Arrange

            var now = DateTime.Now;

            // Act

            var dateTime = now.SubtractMilliseconds(1);

            // Assert

            Assert.Equal(1, (now - dateTime).TotalMilliseconds);
        }

    }
}
