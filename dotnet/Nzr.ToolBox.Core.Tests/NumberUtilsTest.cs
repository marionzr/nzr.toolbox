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

            byte maxByte = Max((byte)10, (byte)20, (byte)30);
            short maxShort = Max((short)10, (short)20, (short)30);
            int maxInt = Max(10, 20, 30);
            long maxLong = Max(10L, 20L, 30L);
            float maxFloat = Max(10F, 20F, 30F);
            double maxDouble = Max(10D, 20D, 30D);
            decimal maxDecimal = Max(10, 20, (decimal)30);

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

            byte minByte = Min((byte)10, (byte)20, (byte)30);
            short minShort = Min((short)10, (short)20, (short)30);
            int minInt = Min(10, 20, 30);
            long minLong = Min(10L, 20L, 30L);
            float minFloat = Min(10F, 20F, 30F);
            double minDouble = Min(10D, 20D, 30D);
            decimal minDecimal = Min(10, 20, (decimal)30);

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

            double avgByte = Average((byte)10, (byte)20, (byte)30);
            double avgShort = Average((short)10, (short)20, (short)30);
            double avgInt = Average(10, 20, 30);
            double avgLong = Average(10L, 20L, 30L);
            double avgFloat = Average(10F, 20F, 30F);
            double avgDouble = Average(10D, 20D, 30D);
            double avgDecimal = Average(10, 20, (decimal)30);

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

            int sumByte = Sum((byte)10, (byte)20, (byte)30);
            int sumShort = Sum((short)10, (short)20, (short)30);
            int sumInt = Sum(10, 20, 30);
            long sumLong = Sum(10L, 20L, 30L);
            double sumFloat = Sum(10F, 20F, 30F);
            double sumDouble = Sum(10D, 20D, 30D);
            decimal sumDecimal = Sum(10, 20, (decimal)30);

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
            int aInt = -30;
            long aLong = -40;
            float aFloat = -50.0F;
            double aDouble = -60.0;
            decimal aDecimal = (decimal)-70.0;


            // Act

            short absByte = aByte.Abs();
            short absShort = aShort.Abs();
            int absInt = aInt.Abs();
            long absLong = aLong.Abs();
            float absFloat = aFloat.Abs();
            double absDouble = aDouble.Abs();
            decimal absDecimal = aDecimal.Abs();

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
            int aInt = 99;
            long aLong = 99;

            // Act

            string byteBinary = aByte.ToBinary();
            string shortBinary = aShort.ToBinary();
            string intBinary = aInt.ToBinary();
            string longBinary = aLong.ToBinary();

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
            int aInt = 99;
            long aLong = 99;

            // Act

            string byteBinary = aByte.ToBinary(true);
            string shortBinary = aShort.ToBinary(true);
            string intBinary = aInt.ToBinary(true);
            string longBinary = aLong.ToBinary(true);

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
            int aInt = 99;
            long aLong = 99;

            // Act

            string byteHexadecimal = aByte.ToHexadecimal(false);
            string shortHexadecimal = aShort.ToHexadecimal(false);
            string intHexadecimal = aInt.ToHexadecimal(false);
            string longHexadecimal = aLong.ToHexadecimal(false);

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
            int aInt = 99;
            long aLong = 99;

            // Act

            string byteHexadecimal = aByte.ToHexadecimal(true);
            string shortHexadecimal = aShort.ToHexadecimal(true);
            string intHexadecimal = aInt.ToHexadecimal(true);
            string longHexadecimal = aLong.ToHexadecimal(true);

            // Arrange

            Assert.Equal("0x63", byteHexadecimal);
            Assert.Equal("0x63", shortHexadecimal);
            Assert.Equal("0x63", intHexadecimal);
            Assert.Equal("0x63", longHexadecimal);
        }
    }
}
