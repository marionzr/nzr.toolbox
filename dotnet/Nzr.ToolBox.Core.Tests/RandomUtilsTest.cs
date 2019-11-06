using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using static Nzr.ToolBox.Core.ToolBox;

namespace Nzr.ToolBox.Core.Tests
{
    public class RandomUtilsTest
    {
        [Fact]
        public void RandomString_WithDefaultOptions_ShouldReturnString()
        {
            // Arrange

            // Act

            string random = RandomString(10);

            // Assert

            Assert.Equal(10, random.Length);
        }

        [Fact]
        public void RandomString_WithLetterOnly_ShouldReturnAlphaString()
        {
            // Arrange

            // Act

            string random = RandomString(20, numbers: null, symbols: null);

            // Assert

            Assert.Equal(20, random.Length);
            Assert.False(random.Any(c => RANDOM_NUMBER.Contains(c)));
            Assert.False(random.Any(c => RANDOM_SYMBOLS.Contains(c)));
        }

        [Fact]
        public void RandomString_WithNumbersOnly_ShouldReturnNumericString()
        {
            // Arrange

            // Act

            string random = RandomString(30, letters: null, symbols: null);

            // Assert

            Assert.Equal(30, random.Length);
            Assert.False(random.Any(c => RANDOM_LETTERS.Contains(c)));
            Assert.False(random.Any(c => RANDOM_SYMBOLS.Contains(c)));
        }

        [Fact]
        public void RandomString_WithSymbolsOnly_ShouldReturnSymbolOnlyString()
        {
            // Arrange

            // Act

            string random = RandomString(40, letters: null, numbers: null);

            // Assert

            Assert.Equal(40, random.Length);
            Assert.False(random.Any(c => RANDOM_LETTERS.Contains(c)));
            Assert.False(random.Any(c => RANDOM_NUMBER.Contains(c)));
        }

        [Fact]
        public void RandomString_WithSpecificChars_ShouldReturnSpecificString()
        {
            // Arrange

            // Act

            string random = RandomString(50000, letters: "AB", numbers: "12", symbols: "!?");

            // Assert

            Assert.Equal(50000, random.Length);
            Assert.False(random.Any(c => RANDOM_LETTERS.Replace("AB", string.Empty).Contains(c)));
            Assert.False(random.Any(c => RANDOM_NUMBER.Replace("12", string.Empty).Contains(c)));
            Assert.False(random.Any(c => RANDOM_SYMBOLS.Replace("!?", string.Empty).Contains(c)));
        }

        [Fact]
        public void RandomString_WithoutAnyChar_ShouldThrowException()
        {
            // Arrange

            // Act

            ArgumentException ex = Assert.Throws<ArgumentException>(
                () => RandomString(40, letters: null, numbers: null, symbols: null));

            // Assert

            Assert.NotNull(ex);
        }

        [Theory]
        [InlineData(255, null)]
        [InlineData(255, 1)]
        public void RandomByte_ShouldReturnUniqueValues(int iterations, int? seed = null)
        {
            // Arrange

            IList<byte> results = new List<byte>();

            // Act

            for (int i = 0; i < iterations; i++)
            {
                seed = seed == null ? (int?)null : Guid.NewGuid().GetHashCode();
                byte result = RandomByte(seed: seed);
                results.Add(result);
            }

            // Assert

            Assert.True(results.GroupBy(b => b).Count() > 2);
        }

        [Theory]
        [InlineData(10000)]
        [InlineData(10000, 1)]
        public void RandomShort_ShouldReturnUniqueValues(int iterations, int? seed = null)
        {
            // Arrange

            IList<short> results = new List<short>();

            // Act

            for (int i = 0; i < iterations; i++)
            {
                seed = seed == null ? (int?)null : Guid.NewGuid().GetHashCode();
                short result = RandomShort(seed: seed);
                results.Add(result);
            }

            // Assert

            Assert.True(results.GroupBy(b => b).Count() > 2);
        }

        [Theory]
        [InlineData(10000)]
        [InlineData(10000, 1)]
        public void RandomInt_ShouldReturnUniqueValues(int iterations, int? seed = null)
        {
            // Arrange

            IList<int> results = new List<int>();

            // Act

            for (int i = 0; i < iterations; i++)
            {
                seed = seed == null ? (int?)null : Guid.NewGuid().GetHashCode();
                int result = RandomInt(seed: seed);
                results.Add(result);
            }

            // Assert

            Assert.True(results.GroupBy(b => b).Count() > 2);
        }

        [Theory]
        [InlineData(10000)]
        [InlineData(10000, 1)]
        public void RandomLong_ShouldReturnUniqueValues(int iterations, int? seed = null)
        {
            // Arrange

            IList<long> results = new List<long>();

            // Act

            for (int i = 0; i < iterations; i++)
            {
                seed = seed == null ? (int?)null : Guid.NewGuid().GetHashCode();
                long result = RandomLong(seed: seed);
                results.Add(result);
            }

            // Assert

            Assert.True(results.GroupBy(b => b).Count() > 2);
        }

        [Theory]
        [InlineData(10000)]
        [InlineData(10000, 1)]
        public void RandomFloat_ShouldReturnUniqueValues(int iterations, int? seed = null)
        {
            // Arrange

            IList<float> results = new List<float>();

            // Act

            for (int i = 0; i < iterations; i++)
            {
                seed = seed == null ? (int?)null : Guid.NewGuid().GetHashCode();
                float result = RandomFloat(seed: seed);
                results.Add(result);
            }

            // Assert

            Assert.True(results.GroupBy(b => b).Count() > 2);
        }

        [Theory]
        [InlineData(10000)]
        [InlineData(10000, 1)]
        public void RandomDouble_ShouldReturnUniqueValues(int iterations, int? seed = null)
        {
            // Arrange

            IList<double> results = new List<double>();

            // Act

            for (int i = 0; i < iterations; i++)
            {
                seed = seed == null ? (int?)null : Guid.NewGuid().GetHashCode();
                double result = RandomDouble(seed: seed);
                results.Add(result);
            }

            // Assert

            Assert.True(results.GroupBy(b => b).Count() > 2);
        }

        [Theory]
        [InlineData(10000)]
        [InlineData(10000, 1)]
        public void RandomDecimal_ShouldReturnUniqueValues(int iterations, int? seed = null)
        {
            // Arrange

            IList<decimal> results = new List<decimal>();

            // Act

            for (int i = 0; i < iterations; i++)
            {
                seed = seed == null ? (int?)null : Guid.NewGuid().GetHashCode();
                decimal result = RandomDecimal(seed: seed);
                results.Add(result);
            }

            // Assert

            Assert.True(results.GroupBy(b => b).Count() > 2);
        }

        [Theory]
        [InlineData(10000)]
        [InlineData(10000, 1)]
        public void RandomBoolean_ShouldReturnUniqueValues(int iterations, int? seed = null)
        {
            // Arrange

            IList<bool> results = new List<bool>();

            // Act

            for (int i = 0; i < iterations; i++)
            {
                seed = seed == null ? (int?)null : Guid.NewGuid().GetHashCode();
                bool result = RandomBoolean(seed: seed);
                results.Add(result);
            }

            // Assert

            Assert.True(results.GroupBy(b => b).Count() == 2);
        }
    }
}
