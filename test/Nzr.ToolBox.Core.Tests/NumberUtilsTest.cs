using Xunit;
using static Nzr.ToolBox.Core.ToolBox;

namespace Nzr.ToolBox.Core.Tests
{
    public class NumberUtilsTest
    {
        [Fact]
        public void Max_ShouldReturnMaxValues()
        {
            // Arrange

            // Act

            var maxByte = Max((byte)10, (byte)20, (byte)30);
            var maxShort = Max((short)10, (short)20, (short)30);
            var maxInt = Max(10, 20, 30);
            var maxLong = Max(10L, 20L, 30L);
            var maxFloat = Max(10F, 20F, 30F);
            var maxDouble = Max(10D, 20D, 30D);
            var maxDecimal = Max(10, 20, (decimal)30);

            // Assert
            Assert.Equal(30, maxByte);
            Assert.Equal(30, maxShort);
            Assert.Equal(30, maxInt);
            Assert.Equal(30, maxLong);
            Assert.Equal(30F, maxFloat);
            Assert.Equal(30D, maxDouble);
            Assert.Equal(30, maxDecimal);
        }

        [Fact]
        public void Min_ShouldReturnMinValues()
        {
            // Arrange

            // Act

            var minByte = Min((byte)10, (byte)20, (byte)30);
            var minShort = Min((short)10, (short)20, (short)30);
            var minInt = Min(10, 20, 30);
            var minLong = Min(10L, 20L, 30L);
            var minFloat = Min(10F, 20F, 30F);
            var minDouble = Min(10D, 20D, 30D);
            var minDecimal = Min(10, 20, (decimal)30);

            // Assert
            Assert.Equal(10, minByte);
            Assert.Equal(10, minShort);
            Assert.Equal(10, minInt);
            Assert.Equal(10, minLong);
            Assert.Equal(10F, minFloat);
            Assert.Equal(10D, minDouble);
            Assert.Equal(10, minDecimal);
        }

        [Fact]
        public void Average_ShouldReturnAverageValues()
        {
            // Arrange

            // Act

            var avgByte = Average((byte)10, (byte)20, (byte)30);
            var avgShort = Average((short)10, (short)20, (short)30);
            var avgInt = Average(10, 20, 30);
            var avgLong = Average(10L, 20L, 30L);
            var avgFloat = Average(10F, 20F, 30F);
            var avgDouble = Average(10D, 20D, 30D);
            var avgDecimal = Average(10, 20, (decimal)30);

            // Assert
            Assert.Equal(20D, avgByte);
            Assert.Equal(20D, avgShort);
            Assert.Equal(20D, avgInt);
            Assert.Equal(20D, avgLong);
            Assert.Equal(20D, avgFloat);
            Assert.Equal(20D, avgDouble);
            Assert.Equal(20D, avgDecimal);
        }

        [Fact]
        public void Sum_ShouldReturnSummedValues()
        {
            // Arrange

            // Act

            var sumByte = Sum((byte)10, (byte)20, (byte)30);
            var sumShort = Sum((short)10, (short)20, (short)30);
            var sumInt = Sum(10, 20, 30);
            var sumLong = Sum(10L, 20L, 30L);
            double sumFloat = Sum(10F, 20F, 30F);
            var sumDouble = Sum(10D, 20D, 30D);
            var sumDecimal = Sum(10, 20, (decimal)30);

            // Assert
            Assert.Equal(60, sumByte);
            Assert.Equal(60, sumShort);
            Assert.Equal(60, sumInt);
            Assert.Equal(60, sumLong);
            Assert.Equal(60, sumFloat);
            Assert.Equal(60, sumDouble);
            Assert.Equal(60, sumDecimal);
        }

        [Fact]
        public void Abst_ShouldReturnAbsoluteValues()
        {
            // Arrange
            sbyte aByte = -10;
            short aShort = -20;
            var aInt = -30;
            long aLong = -40;
            var aFloat = -50.0F;
            var aDouble = -60.0;
            var aDecimal = (decimal)-70.0;


            // Act

            var absByte = aByte.Abs();
            var absShort = aShort.Abs();
            var absInt = aInt.Abs();
            var absLong = aLong.Abs();
            var absFloat = aFloat.Abs();
            var absDouble = aDouble.Abs();
            var absDecimal = aDecimal.Abs();

            // Assert
            Assert.Equal(10, absByte);
            Assert.Equal(20, absShort);
            Assert.Equal(30, absInt);
            Assert.Equal(40, absLong);
            Assert.Equal(50, absFloat);
            Assert.Equal(60, absDouble);
            Assert.Equal(70, absDecimal);
        }

        [Fact]
        public void ToBinary_WithDecimalWithoutPrefix_ShouldReturnBinaryNumbersOnly()
        {
            // Arrange

            byte aByte = 99;
            short aShort = 99;
            var aInt = 99;
            long aLong = 99;

            // Act

            var byteBinary = aByte.ToBinary();
            var shortBinary = aShort.ToBinary();
            var intBinary = aInt.ToBinary();
            var longBinary = aLong.ToBinary();

            // Arrange

            Assert.Equal("1100011", byteBinary);
            Assert.Equal("1100011", shortBinary);
            Assert.Equal("1100011", intBinary);
            Assert.Equal("1100011", longBinary);
        }

        [Fact]
        public void ToBinary_WithNumberWithPrefix_ShouldReturnBinaryWithPrefix()
        {
            // Arrange

            byte aByte = 99;
            short aShort = 99;
            var aInt = 99;
            long aLong = 99;

            // Act

            var byteBinary = aByte.ToBinary(true);
            var shortBinary = aShort.ToBinary(true);
            var intBinary = aInt.ToBinary(true);
            var longBinary = aLong.ToBinary(true);

            // Arrange

            Assert.Equal("0b1100011", byteBinary);
            Assert.Equal("0b1100011", shortBinary);
            Assert.Equal("0b1100011", intBinary);
            Assert.Equal("0b1100011", longBinary);
        }

        [Fact]
        public void ToHexadecimal_WithNumberWithoutPrefix_ShouldReturnBinaryNumbersOnly()
        {
            // Arrange

            byte aByte = 99;
            short aShort = 99;
            var aInt = 99;
            long aLong = 99;

            // Act

            var byteHexadecimal = aByte.ToHexadecimal(false);
            var shortHexadecimal = aShort.ToHexadecimal(false);
            var intHexadecimal = aInt.ToHexadecimal(false);
            var longHexadecimal = aLong.ToHexadecimal(false);

            // Arrange

            Assert.Equal("63", byteHexadecimal);
            Assert.Equal("63", shortHexadecimal);
            Assert.Equal("63", intHexadecimal);
            Assert.Equal("63", longHexadecimal);
        }

        [Fact]
        public void ToHexadecimal_WithNumberWithPrefix_ShouldReturnBinaryWithPrefix()
        {
            // Arrange

            byte aByte = 99;
            short aShort = 99;
            var aInt = 99;
            long aLong = 99;

            // Act

            var byteHexadecimal = aByte.ToHexadecimal(true);
            var shortHexadecimal = aShort.ToHexadecimal(true);
            var intHexadecimal = aInt.ToHexadecimal(true);
            var longHexadecimal = aLong.ToHexadecimal(true);

            // Arrange

            Assert.Equal("0x63", byteHexadecimal);
            Assert.Equal("0x63", shortHexadecimal);
            Assert.Equal("0x63", intHexadecimal);
            Assert.Equal("0x63", longHexadecimal);
        }

        [Fact]
        public void PadLeft_WithNumersOfSameSize_ShouldNotAppendChars()
        {
            // Arrange

            byte b1 = 101;

            // Act

            var result1 = b1.PadLeft(3, '_');

            // Asssert

            Assert.Equal("101", result1);
        }

        [Fact]
        public void PadLeft_WithNumersOFLowerLength_ShouldAppendChars()
        {
            // Arrange

            byte b1 = 101;

            // Act

            var result1 = b1.PadLeft(5, '_');

            // Assert

            Assert.Equal("__101", result1);
        }
    }
}
