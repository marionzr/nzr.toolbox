using System.Collections.Generic;
using Xunit;
using static Nzr.ToolBox.Core.ToolBox;

namespace Nzr.ToolBox.Core.Tests
{
    public class EnumUtilsTest
    {
        [Fact]
        public void GetEnumNames_ShouldReturnEnumNamesAsList()
        {
            // Arrange

            // Act

            IList<string> result = GetEnumNames<Fruits>();

            // Assert

            Assert.Equal("Apple", result[0]);
            Assert.Equal("Orage", result[1]);
            Assert.Equal("Lemon", result[2]);
        }

        private enum Fruits
        {
            Apple,
            Orage,
            Lemon
        };
    }
}
