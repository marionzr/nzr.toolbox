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

            var random = RandomString(10);

            // Assert

            Assert.Equal(10, random.Length);
        }

        [Fact]
        public void RandomString_WithLetterOnly_ShouldReturnAlphaString()
        {
            // Arrange

            // Act

            var random = RandomString(20, numbers: null, symbols: null);

            // Assert

            Assert.Equal(20, random.Length);
            Assert.DoesNotContain(random, c => RANDOM_NUMBER.Contains(c));
            Assert.DoesNotContain(random, c => RANDOM_SYMBOLS.Contains(c));
        }

        [Fact]
        public void RandomString_WithNumbersOnly_ShouldReturnNumericString()
        {
            // Arrange

            // Act

            var random = RandomString(30, letters: null, symbols: null);

            // Assert

            Assert.Equal(30, random.Length);
            Assert.DoesNotContain(random, c => RANDOM_LETTERS.Contains(c));
            Assert.DoesNotContain(random, c => RANDOM_SYMBOLS.Contains(c));
        }

        [Fact]
        public void RandomString_WithSymbolsOnly_ShouldReturnSymbolOnlyString()
        {
            // Arrange

            // Act

            var random = RandomString(40, letters: null, numbers: null);

            // Assert

            Assert.Equal(40, random.Length);
            Assert.DoesNotContain(random, c => RANDOM_LETTERS.Contains(c));
            Assert.DoesNotContain(random, c => RANDOM_NUMBER.Contains(c));
        }

        [Fact]
        public void RandomString_WithSpecificChars_ShouldReturnSpecificString()
        {
            // Arrange

            // Act

            var random = RandomString(50000, letters: "AB", numbers: "12", symbols: "!?");

            // Assert

            Assert.Equal(50000, random.Length);
            Assert.DoesNotContain(random, c => RANDOM_LETTERS.Replace("AB", string.Empty).Contains(c));
            Assert.DoesNotContain(random, c => RANDOM_NUMBER.Replace("12", string.Empty).Contains(c));
            Assert.DoesNotContain(random, c => RANDOM_SYMBOLS.Replace("!?", string.Empty).Contains(c));
        }

        [Fact]
        public void RandomString_WithoutAnyChar_ShouldThrowException()
        {
            // Arrange

            // Act

            var ex = Assert.Throws<ArgumentException>(
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

            var results = new List<byte>();

            // Act

            for (var i = 0; i < iterations; i++)
            {
                seed = seed == null ? (int?)null : Guid.NewGuid().GetHashCode();
                var result = RandomByte(seed: seed);
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

            List<short> results = [];

            // Act

            for (var i = 0; i < iterations; i++)
            {
                seed = seed == null ? (int?)null : Guid.NewGuid().GetHashCode();
                var result = RandomShort(seed: seed);
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

            var results = new List<int>();

            // Act

            for (var i = 0; i < iterations; i++)
            {
                seed = seed == null ? (int?)null : Guid.NewGuid().GetHashCode();
                var result = RandomInt(seed: seed);
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

            var results = new List<long>();

            // Act

            for (var i = 0; i < iterations; i++)
            {
                seed = seed == null ? (int?)null : Guid.NewGuid().GetHashCode();
                var result = RandomLong(seed: seed);
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

            var results = new List<float>();

            // Act

            for (var i = 0; i < iterations; i++)
            {
                seed = seed == null ? (int?)null : Guid.NewGuid().GetHashCode();
                var result = RandomFloat(seed: seed);
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

            var results = new List<double>();

            // Act

            for (var i = 0; i < iterations; i++)
            {
                seed = seed == null ? (int?)null : Guid.NewGuid().GetHashCode();
                var result = RandomDouble(seed: seed);
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

            var results = new List<decimal>();

            // Act

            for (var i = 0; i < iterations; i++)
            {
                seed = seed == null ? (int?)null : Guid.NewGuid().GetHashCode();
                var result = RandomDecimal(seed: seed);
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

            var results = new List<bool>();

            // Act

            for (var i = 0; i < iterations; i++)
            {
                seed = seed == null ? (int?)null : Guid.NewGuid().GetHashCode();
                var result = RandomBoolean(seed: seed);
                results.Add(result);
            }

            // Assert

            Assert.Equal(2, results.GroupBy(b => b).Count());
        }
    }
}
