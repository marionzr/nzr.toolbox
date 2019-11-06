using Xunit;
using static Nzr.ToolBox.Core.ToolBox;


namespace Nzr.ToolBox.Core.Tests
{
    public class BooleanUtilsTests
    {
        [Theory()]
        [InlineData((byte)0, (short)0, 0, 0L, 0.0F, 0.0D, 0.0)]
        [InlineData((sbyte)-1, (short)-2, -3, -4L, -5.0F, -6.0D, -7.0)]
        public void ToBool_WithZeroOrNegative_ShouldReturnFalse(sbyte b, short s, int i, long l, float f, double d, decimal m)
        {
            // Arrange

            // Act

            bool bREsult = b.ToBool();
            bool sREsult = s.ToBool();
            bool iREsult = i.ToBool();
            bool lREsult = l.ToBool();
            bool fREsult = f.ToBool();
            bool dREsult = d.ToBool();
            bool mREsult = m.ToBool();

            // Assert

            Assert.False(bREsult);
            Assert.False(sREsult);
            Assert.False(iREsult);
            Assert.False(lREsult);
            Assert.False(fREsult);
            Assert.False(dREsult);
            Assert.False(mREsult);
        }

        [Theory()]
        [InlineData(1, 1, 1, 1, 1.0F, 1.0D, 1.0)]
        [InlineData(2, 3, 4, 5, 6.0F, 7.0D, 8.0)]
        public void ToBool_WithPositiveNonZero_ShouldReturnTrue(byte b, short s, int i, long l, float f, double d, decimal m)
        {
            // Arrange

            // Act

            bool bREsult = b.ToBool();
            bool sREsult = s.ToBool();
            bool iREsult = i.ToBool();
            bool lREsult = l.ToBool();
            bool fREsult = f.ToBool();
            bool dREsult = d.ToBool();
            bool mREsult = m.ToBool();

            // Assert

            Assert.True(bREsult);
            Assert.True(sREsult);
            Assert.True(iREsult);
            Assert.True(lREsult);
            Assert.True(fREsult);
            Assert.True(dREsult);
            Assert.True(mREsult);
        }

        [Theory()]
        [InlineData("Y")]
        [InlineData("Yes")]
        [InlineData("S")]
        [InlineData("Sim")]
        [InlineData("Si")]
        [InlineData("Ja")]
        [InlineData("Oui")]
        [InlineData("1")]
        [InlineData("true")]
        public void ToBool_WithPositiveString_ShouldReturnTrue(string value)
        {
            // Arrange

            // Act

            bool result = value.ToBool();

            // Assert

            Assert.True(result);
        }

        [Theory()]
        [InlineData("No")]
        [InlineData("N")]
        [InlineData("Não")]
        [InlineData("X")]
        [InlineData("0")]
        [InlineData("")]
        public void ToBool_WithNonPositiveString_ShouldReturnFalse(string value)
        {
            // Arrange

            // Act

            bool result = value.ToBool();

            // Assert

            Assert.False(result);
        }

        [Theory()]
        [InlineData(null)]
        [InlineData(false)]
        public void IsTrue_WithNullOrFalseValue_ShouldReturnFalse(bool? value)
        {
            // Arrange


            // Act

            bool result = value.IsTrue();

            // Assert

            Assert.False(result);
        }

        [Fact()]
        public void IsTrue_WithTrueValue_ShouldReturnTrue()
        {
            // Arrange

            bool? b = true;

            // Act

            bool result = b.IsTrue();

            // Assert

            Assert.True(result);
        }

        [Theory()]
        [InlineData(null)]
        [InlineData(false)]
        public void IsFalse_WithNullOrFalseValue_ShouldReturnTrue(bool? value)
        {
            // Arrange


            // Act

            bool result = value.IsFalse();

            // Assert

            Assert.True(result);
        }

        [Fact()]
        public void IsFalse_WithTrueValue_ShouldReturnFalse()
        {
            // Arrange

            bool? b = true;

            // Act

            bool result = b.IsFalse();

            // Assert

            Assert.False(result);
        }

        [Fact()]
        public void Describe_WihTrueValueAndWithDefaultYesString_ShouldReturnYes()
        {
            // Arrange

            bool? value1 = true;
            bool value2 = true;

            // Act

            string result1 = value1.Describe();
            string result2 = value2.Describe();

            // Assert

            Assert.Equal("yes", result1);
            Assert.Equal("yes", result2);
        }

        [Fact()]
        public void Describe_WihTrueValueAndWitCustomYesString_ShouldReturnCustomString()
        {
            // Arrange

            bool? value1 = true;
            bool value2 = true;

            // Act

            string result1 = value1.Describe("sim", "não");
            string result2 = value2.Describe("si", "no");

            // Assert

            Assert.Equal("sim", result1);
            Assert.Equal("si", result2);
        }

        [Fact()]
        public void Describe_WihFalseValueAndWithDefaultFlaseString_ShouldReturnYes()
        {
            // Arrange

            bool? value1 = false;
            bool value2 = false;

            // Act

            string result1 = value1.Describe();
            string result2 = value2.Describe();

            // Assert

            Assert.Equal("no", result1);
            Assert.Equal("no", result2);
        }

        [Fact()]
        public void Describe_WihFalseValueAndWitCustomFalseString_ShouldReturnCustomString()
        {
            // Arrange

            bool? value1 = false;
            bool value2 = false;

            // Act

            string result1 = value1.Describe("sim", "não");
            string result2 = value2.Describe("si", "no");

            // Assert

            Assert.Equal("não", result1);
            Assert.Equal("no", result2);
        }

        [Fact()]
        public void Describe_WihNullValueAndWithDefaultNullString_ShouldReturnYes()
        {
            // Arrange

            bool? value1 = null;

            // Act

            string result1 = value1.Describe();

            // Assert

            Assert.Equal("null", result1);
        }

        [Fact()]
        public void Describe_WihNullValueAndWitCustomNullString_ShouldReturnCustomString()
        {
            // Arrange

            bool? value1 = null;

            // Act

            string result1 = value1.Describe("sim", "não", "nulo");

            // Assert

            Assert.Equal("nulo", result1);
        }

        [Fact()]
        public void IsAllTrue_WithAllTrueValues_ShouldReturnTrue()
        {
            // Arrange

            bool a = true;
            bool b = true;
            bool c = true;

            // Act

            bool result = IsAllTrue(a, b, c);

            // Assert

            Assert.True(result);
        }

        [Fact()]
        public void IsAllTrue_WithOneFalseValue_ShouldReturnFalse()
        {
            // Arrange

            bool a = true;
            bool b = true;
            bool c = false;

            // Act

            bool result = IsAllTrue(a, b, c);

            // Assert

            Assert.False(result);
        }

        [Fact()]
        public void IsAnyTrue_WithOneTrueValue_ShouldReturnTrue()
        {
            // Arrange

            bool a = true;
            bool b = false;
            bool c = false;

            // Act

            bool result = IsAnyTrue(a, b, c);

            // Assert

            Assert.True(result);
        }

        [Fact()]
        public void IsAnyTrue_WithAllFalseValues_ShouldReturnFalse()
        {
            // Arrange

            bool a = false;
            bool b = false;
            bool c = false;

            // Act

            bool result = IsAnyTrue(a, b, c);

            // Assert

            Assert.False(result);
        }

        [Fact()]
        public void IsAnyFalse_WithOneFalseValue_ShouldReturnTrue()
        {
            // Arrange

            bool a = true;
            bool b = false;
            bool c = false;

            // Act

            bool result = IsAnyFalse(a, b, c);

            // Assert

            Assert.True(result);
        }

        [Fact()]
        public void IsAnyFalse_WithAllTrueValues_ShouldReturnFalse()
        {
            // Arrange

            bool a = true;
            bool b = true;
            bool c = true;

            // Act

            bool result = IsAnyFalse(a, b, c);

            // Assert

            Assert.False(result);
        }

        [Fact()]
        public void IsAllFalse_WithAllFalseValues_ShouldReturnTrue()
        {
            // Arrange

            bool a = false;
            bool b = false;
            bool c = false;

            // Act

            bool result = IsAllFalse(a, b, c);

            // Assert

            Assert.True(result);
        }

        [Fact()]
        public void IsAllFalse_WithOneTrueValue_ShouldReturnFalse()
        {
            // Arrange

            bool a = false;
            bool b = true;
            bool c = false;

            // Act

            bool result = IsAllFalse(a, b, c);

            // Assert

            Assert.False(result);
        }
    }
}