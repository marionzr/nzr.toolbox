using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Nzr.ToolBox.Core.Tests
{
    public class ReflectionUtilsTest
    {
        private readonly A a;

        public ReflectionUtilsTest()
        {
            a = new A()
            {
                P3 = ["a"],
                P4 =
                [
                    new B<C>()
                    {
                        P5 = [],
                        P6 = new C()
                        {
                            X10 = DateTime.Now,
                        }
                    }
                ]
            };

            a.P4.Add(null);
        }

        [Fact]
        public void ExecuteForEachProperty_ShouldExecuteAction()
        {
            // Arrange

            a.P2 = "nzr";
            a.P4![0]!.P6!.P7 = 100;
            a.P4![0]!.P6!.P9 = [1, 2, 3];
            var propertyValues = new List<Tuple<string, object?>>();

            // Act

            a.ExecuteForEachProperty(r => propertyValues.Add(new Tuple<string, object?>(r.Property.Name, r.Value)));

            // Assert

            Assert.Equal(10, propertyValues.Count);
            Assert.Equal("P1", propertyValues.OrderBy(i => i.Item1).First().Item1);
            Assert.Equal("X10", propertyValues.OrderBy(i => i.Item1).Last().Item1);
        }

        [Fact]
        public void GetPropertyNames_WithEntity_ShouldReturnPropertyNames()
        {
            // Arrange

            // Act

            var propertyNames = a.GetPropertyNames();

            // Assert

            Assert.Equal(3, propertyNames.Count);
            Assert.Equal(4, propertyNames["A"].Count);
            Assert.Equal(2, propertyNames["B<C>"].Count);
            Assert.Equal(4, propertyNames["C"].Count);
        }

        [Fact]
        public void GetValue_WithPropertyPath_ShouldReturnNestedValues()
        {
            // Arrange
            a.P2 = "nzr";
            a.P4![0]!.P6!.P7 = 100;
            a.P4[0]!.P6!.P9 = [1, 2, 3];

            // Act

            var aP2 = (string)a.GetValue("P2")!;
            var aP4 = a.GetValue<IList<B<C>>>("P4")!;
            var bP2P1 = aP4[0].GetValue<int>("P6.P7");
            var arr = aP4[0].GetValue<int?[]>("P6.P9");

            // Assert

            Assert.Equal("nzr", aP2);
            Assert.Equal(2, aP4.Count);
            Assert.Equal(100, bP2P1);
            Assert.Equal([1, 2, 3], arr);
        }

        [Fact]
        public void GetValue_WithPropertyPathToList_ShouldThrowException()
        {
            // Arrange


            // Act

            var ex = Assert.Throws<NotSupportedException>(() => a.GetValue<string>("P2.P4.P6"));

            // Assert

            Assert.NotNull(ex);
        }


        public class A
        {
            public int P1 { get; set; }
            public string? P2 { get; set; }
            public List<string>? P3 { get; set; }
            public List<B<C>?>? P4 { get; set; }
        }

        public class B<T>
        {
            public List<B<T>>? P5 { get; set; }
            public T? P6 { get; set; }
        }

        public class C
        {
            public int? P7 { get; set; }
            public int P8 { get; set; }
            public int?[]? P9 { get; set; }
            public DateTime X10 { get; set; }
        }
    }
}
