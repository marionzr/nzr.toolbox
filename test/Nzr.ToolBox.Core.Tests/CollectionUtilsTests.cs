using System.Collections.Generic;
using Xunit;

namespace Nzr.ToolBox.Core.Tests
{
    public class CollectionUtilsTests
    {
        [Fact()]
        public void ForEach_WithGenericList_ShouldExecuteAction()
        {
            // Arrange

            IList<string> list = ["A", "B", "C"];
            IList<char> actionResult = [];

            // Act

            list.ForEach<string>(e => actionResult.Add(e[0].ToLower()));

            // Assert

            Assert.Equal('a', actionResult[0]);
            Assert.Equal('b', actionResult[1]);
            Assert.Equal('c', actionResult[2]);
        }

        [Fact()]
        public void ForEach_WithNull_ShouldNotExecuteAction()
        {
            // Arrange

            IList<string>? list = null;
            IList<char> actionResult = [];

            // Act

            list.ForEach(e => actionResult.Add(e[0].ToLower()));

            // Assert

            Assert.Empty(actionResult);
        }

        [Fact()]
        public void ForEach_WithList_ShouldExecuteAction()
        {
            // Arrange

            System.Collections.IEnumerable list = new List<string>() { "A", "B", "C" };
            IList<char> actionResult = [];

            // Act

            list.ForEach(e => actionResult.Add(e.ToString()![0].ToLower()));

            // Assert

            Assert.Equal('a', actionResult[0]);
            Assert.Equal('b', actionResult[1]);
            Assert.Equal('c', actionResult[2]);
        }

        [Fact()]
        public void ForEach_WithNullList_ShouldNotExecuteAction()
        {
            // Arrange

            System.Collections.IEnumerable? list = null;
            IList<char> actionResult = [];

            // Act

            list.ForEach(e => actionResult.Add(e.ToString()![0].ToLower()));

            // Assert

            Assert.Empty(actionResult);
        }

        [Fact()]
        public void ForEach_WithGenericList_ShouldExecuteFunction()
        {
            // Arrange

            var list = new List<string>() { "A", "B", "C" };
            var functionResult = new List<char>();

            // Act

            list.ForEach<string>(e =>
            {
                functionResult.Add(e[0]);
                return e != "B";
            });


            // Assert

            Assert.Equal(2, functionResult.Count);
        }

        [Fact()]
        public void ForEach_WithNull_ShouldNotExecuteFunction()
        {
            IList<string>? list = null;
            IList<char> functionResult = [];

            // Act

            list.ForEach<string>(e =>
            {
                functionResult.Add(e[0]);
                return e != "B";
            });


            // Assert

            Assert.Empty(functionResult);
        }

        [Fact()]
        public void ForEach_WithEnumerable_ShouldExecuteFunction()
        {
            // Arrange

            System.Collections.IEnumerable list = new List<string>() { "A", "B", "C" };
            var functionResult = new List<char>();

            // Act

            list.ForEach(e =>
            {
                var s = e.ToString()!;
                functionResult.Add(s[0]);
                return s != "B";
            });


            // Assert

            Assert.Equal(2, functionResult.Count);
        }

        [Fact()]
        public void Add_ShouldAddAllElements()
        {
            // Arrange

            string? a = null;
            var b = "";
            var c = "x";
            ICollection<string?> list = [];

            // Act

            list.AddElements(a, b, c);

            // Assert

            Assert.Equal(3, list.Count);
            Assert.Null(list.Get(0));
            Assert.Equal("", list.Get(1));
            Assert.Equal("x", list.Get(2));
        }

        [Fact()]
        public void Add_WithListAsArgument_ShouldAddAllElements()
        {
            // Arrange

            string? a = null;
            var b = "";
            var c = "x";

            ICollection<string?> another =
            [
                 a, b, c
            ];

            ICollection<string?> list = [];

            // Act

            list.AddEnumerable(another);

            // Assert

            Assert.Equal(3, list.Count);
            Assert.Null(list.Get(0));
            Assert.Equal("", list.Get(1));
            Assert.Equal("x", list.Get(2));
        }

        [Fact()]
        public void Add_WithNullCollectionSourceAndListAsArgument_ShouldNotAddAllElements()
        {
            // Arrange

            string? a = null;
            var b = "";
            var c = "x";

            ICollection<string?> another =
            [
                 a, b, c
            ];

            ICollection<string?>? list = null;

            // Act

            list.AddEnumerable(another);

            // Assert

            Assert.Null(list);
        }

        [Fact()]
        public void ContainsAll_WithEnumerableAndSameElements_ShouldReturnTrue()
        {
            // Arrange

            System.Collections.IEnumerable list1 = new List<string>() { "a", "b", "c" };
            System.Collections.IEnumerable list2 = new List<string>() { "a", "b", "c" };

            // Act

            var result = list1.ContainsAll(list2);

            // Assert

            Assert.True(result);
        }

        [Fact()]
        public void ContainsAll_WithNullEnumerables_ShouldReturnTrue()
        {
            // Arrange

            System.Collections.IEnumerable? list1 = null;
            System.Collections.IEnumerable? list2 = null;

            // Act

            var result = list1.ContainsAll(list2);

            // Assert

            Assert.True(result);
        }

        [Fact()]
        public void ContainsAll_WithNullSourceEnumerable_ShouldReturnFalse()
        {
            // Arrange

            System.Collections.IEnumerable? list1 = null;
            System.Collections.IEnumerable list2 = new List<string>() { "a", "b", "c" };

            // Act

            var result = list1.ContainsAll(list2);

            // Assert

            Assert.False(result);
        }

        [Fact()]
        public void ContainsAll_WithNullRefEnumerable_ShouldReturnFalse()
        {
            // Arrange

            System.Collections.IEnumerable list1 = new List<string>() { "a", "b", "c" };
            System.Collections.IEnumerable? list2 = null;

            // Act

            var result = list1.ContainsAll(list2);

            // Assert

            Assert.False(result);
        }

        [Fact()]
        public void ContainsAll_WithGenericEnumerableAndDiffElements_ShouldReturnFalse()
        {
            // Arrange

            IList<string> list1 = ["a", "b", "c"];
            IList<string> list2 = ["a", "b", "C"];

            // Act

            var result = list1.ContainsAll(list2);

            // Assert

            Assert.False(result);
        }

        [Fact()]
        public void ContainsAll_WithGenericEnumerableAndDiffSize_ShouldReturnFalse()
        {
            // Arrange

            IList<string> list1 = ["a", "b",];
            IList<string> list2 = ["a", "b", "c"];

            // Act

            var result = list1.ContainsAll(list2);

            // Assert

            Assert.False(result);
        }

        [Fact()]
        public void ContainsAll_WithNullSourceAndRefGenericEnumerable_ShouldReturnTrue()
        {
            // Arrange

            IList<string>? list1 = null;
            IList<string>? list2 = null;

            // Act

            var result = list1.ContainsAll(list2);

            // Assert

            Assert.True(result);
        }

        [Fact()]
        public void ContainsAll_WithNullSourceEnumerable_ShouldReturnTrue()
        {
            // Arrange

            IList<string>? list1 = null;
            IList<string> list2 = ["a", "b", "c"];

            // Act

            var result = list1.ContainsAll(list2);

            // Assert

            Assert.False(result);
        }

        [Fact()]
        public void ContainsAll_WithNullRefEnumerable_ShouldReturnTrue()
        {
            // Arrange

            IList<string> list1 = ["a", "b", "c"];
            IList<string>? list2 = null;
            // Act

            var result = list1.ContainsAll(list2);

            // Assert

            Assert.False(result);
        }

        [Fact()]
        public void ContainsAny_WithEnumerableAndSomeOfOtherElements_ShouldReturnTrue()
        {
            // Arrange

            System.Collections.IEnumerable list1 = new List<string>() { "a", "b", "c" };
            System.Collections.IEnumerable list2 = new List<string>() { "x", "y", "c" };

            // Act

            var result = list1.ContainsAny(list2);

            // Assert

            Assert.True(result);
        }

        [Fact()]
        public void ContainsAny_WithNullSourceEnumerable_ShouldReturnFalse()
        {
            // Arrange

            System.Collections.IEnumerable? list1 = null;
            System.Collections.IEnumerable list2 = new List<string>() { "x", "y", "c" };

            // Act

            var result = list1.ContainsAny(list2);

            // Assert

            Assert.False(result);
        }

        [Fact()]
        public void ContainsAny_WithNullRefEnumerable_ShouldReturnFalse()
        {
            // Arrange

            System.Collections.IEnumerable list1 = new List<string>() { "x", "y", "c" };
            System.Collections.IEnumerable? list2 = null;

            // Act

            var result = list1.ContainsAny(list2);

            // Assert

            Assert.False(result);
        }

        [Fact()]
        public void ContainsAny_WithEnumerableAndNonOfOtherElements_ShouldReturnFalse()
        {
            // Arrange

            IList<string> list1 = ["a", "b", "c"];
            IList<string> list2 = ["A", "B", "C"];

            // Act

            var result = list1.ContainsAny(list2);

            // Assert

            Assert.False(result);
        }

        [Fact()]
        public void ContainsAny_WithEnumerableAndDiffSize_ShouldReturnFalse()
        {
            // Arrange

            IList<string> list1 = ["a", "b", "c"];
            IList<string> list2 = ["A", "B"];

            // Act

            var result = list1.ContainsAny(list2);

            // Assert

            Assert.False(result);
        }

        [Fact()]
        public void ContainsAny_WithNullSourceGenericEnumerable_ShouldReturnFalse()
        {
            // Arrange

            IList<string>? list1 = null;
            IList<string> list2 = ["A", "B"];

            // Act

            var result = list1.ContainsAny(list2);

            // Assert

            Assert.False(result);
        }

        [Fact()]
        public void ContainsAny_WithNullRefGenericEnumerable_ShouldReturnFalse()
        {
            // Arrange

            IList<string> list1 = ["A", "B"];
            IList<string>? list2 = null;

            // Act

            var result = list1.ContainsAny(list2);

            // Assert

            Assert.False(result);
        }

        [Fact()]
        public void EmptyIfNull_WithNullEnumerable_ShouldNewEnumerable()
        {
            // Arrange

            System.Collections.IEnumerable? enumerable = null;
            System.Collections.ICollection? collection = null;
            System.Collections.IList? list = null;


            // Act

            var result1 = enumerable.EmptyIfNull();
            var result2 = collection.EmptyIfNull();
            var result3 = list.EmptyIfNull();

            // Assert

            Assert.True(result1.IsEmpty());
            Assert.True(result2.IsEmpty());
            Assert.True(result3.IsEmpty());
        }

        [Fact()]
        public void EmptyIfNull_WithNonNullEnumerable_ShouldTheEnumerable()
        {
            // Arrange

            System.Collections.IEnumerable enumerable = new List<string>() { string.Empty };

            // Act

            var result = enumerable.EmptyIfNull();

            // Assert

            Assert.Equal(result, enumerable);
        }

        [Fact()]
        public void EmptyIfNull_WithNullGenericEnumerable_ShouldNewEnumerable()
        {
            // Arrange

            IEnumerable<string>? enumerable = null;

            // Act

            var result = enumerable.EmptyIfNull();

            // Assert

            Assert.NotNull(result);
            Assert.True(result.IsEmpty());
        }

        [Fact()]
        public void EmptyIfNull_WithNonNullGenericEnumerable_ShouldTheEnumerable()
        {
            // Arrange

            IEnumerable<string> enumerable = [string.Empty];

            // Act

            var result = enumerable.EmptyIfNull();

            // Assert

            Assert.Equal(result, enumerable);
        }

        [Fact]
        public void Get_WithEnumerableWithExistingIndex_ShouldReturnValue()
        {
            // Arrange

            System.Collections.IEnumerable enumerable = new List<string>() { "a", "b", "c" };

            // Act

            var result = enumerable.Get(1);

            // Assert

            Assert.Equal("b", result);
        }

        [Fact]
        public void Get_WithNullEnumerabl_ShouldReturnNull()
        {
            // Arrange

            System.Collections.IEnumerable? enumerable = null;

            // Act

            var result = enumerable.Get(1);

            // Assert

            Assert.Null(result);
        }

        [Fact]
        public void Get_WithGenericEnumerableWithExistingIndex_ShouldReturnValue()
        {
            // Arrange

            IEnumerable<string> enumerable = ["a", "b", "c"];

            // Act

            object? result = enumerable.Get(1);

            // Assert

            Assert.Equal("b", result);
        }

        [Fact()]
        public void IsEmpty_WithNull_ShouldReturnTrue()
        {
            // Arrange

            System.Collections.IList? list = null;

            // Act

            var result = list.IsEmpty();

            // Assert

            Assert.True(result);
        }

        [Fact()]
        public void IsEmpty_WithEmpty_ShouldReturnTrue()
        {
            // Arrange

            System.Collections.IList list = new List<string>();

            // Act

            var result = list.IsEmpty();

            // Assert

            Assert.True(result);
        }

        [Fact()]
        public void IsEmpty_WithNonEmpty_ShouldReturnFalse()
        {
            // Arrange

            System.Collections.IList list = new List<string>() { "a" };

            // Act

            var result = list.IsEmpty();

            // Assert

            Assert.False(result);
        }


        [Fact()]
        public void IsNotEmpty_WithNull_ShouldReturnFalse()
        {
            // Arrange

            IList<string>? list = null;

            // Act

            var result = list.IsNotEmpty();

            // Assert

            Assert.False(result);
        }

        [Fact()]
        public void IsNotEmpty_WithEmpty_ShouldReturnFalse()
        {
            // Arrange

            IList<string> list = [];

            // Act

            var result = list.IsNotEmpty();

            // Assert

            Assert.False(result);
        }

        [Fact()]
        public void IsNotEmpty_WithNonEmpty_ShouldReturnTrue()
        {
            // Arrange

            IList<string> list = ["a"];

            // Act

            var result = list.IsNotEmpty();

            // Assert

            Assert.True(result);
        }

        [Fact]
        public void IndexOf_WithExistingItem_ShouldReturnIndex()
        {
            // Arrange

            var b = new byte[] { 1, 2, 3 };
            var s = new short[] { 1, 2, 3 };
            var i = new int[] { 1, 2, 3 };
            var l = new long[] { 1, 2, 3 };
            var f = new float[] { 1.0F, 2.0F, 3.0F };
            var d = new double[] { 1.0D, 2.0D, 3.0D };
            var m = new decimal[] { 1.0M, 2.0M, 3.0M };
            var str = new string[] { "1", "2", "3" };

            // Act

            var bResult = b.IndexOf(2);
            var sResult = s.IndexOf(2);
            var iResult = i.IndexOf(2);
            var lResult = l.IndexOf(2);
            var fResult = f.IndexOf(2.0F);
            var dResult = d.IndexOf(2.0D);
            var mResult = m.IndexOf(2.0M);
            var strResult = str.IndexOf("2");
            var tStrResult = str.IndexOf<string>("2");

            // Assert

            Assert.Equal(1, bResult);
            Assert.Equal(1, sResult);
            Assert.Equal(1, iResult);
            Assert.Equal(1, lResult);
            Assert.Equal(1, fResult);
            Assert.Equal(1, dResult);
            Assert.Equal(1, mResult);
            Assert.Equal(1, strResult);
            Assert.Equal(1, tStrResult);
        }

        [Fact]
        public void Contains_WithExistingItem_ShouldReturnTrue()
        {
            // Arrange

            var b = new byte[] { 1, 2, 3 };
            var s = new short[] { 1, 2, 3 };
            var i = new int[] { 1, 2, 3 };
            var l = new long[] { 1, 2, 3 };
            var f = new float[] { 1.0F, 2.0F, 3.0F };
            var d = new double[] { 1.0D, 2.0D, 3.0D };
            var m = new decimal[] { 1.0M, 2.0M, 3.0M };
            var str = new string[] { "1", "2", "3" };

            // Act

            var bResult = b.Contains(2);
            var sResult = s.Contains(2);
            var iResult = i.Contains(2);
            var lResult = l.Contains(2);
            var fResult = f.Contains(2.0F);
            var dResult = d.Contains(2.0D);
            var mResult = m.Contains(2.0M);
            var strResult = str.Contains("2");
            var tStrResult = str.Contains<string>("2");

            // Assert

            Assert.True(bResult);
            Assert.True(sResult);
            Assert.True(iResult);
            Assert.True(lResult);
            Assert.True(fResult);
            Assert.True(dResult);
            Assert.True(mResult);
            Assert.True(strResult);
            Assert.True(tStrResult);
        }

        [Fact]
        public void IndexOf_WithNullArray_ShouldReturnMinusOne()
        {
            // Arrange

            byte[]? b = null;

            // Act

            var bResult = b.IndexOf(2);

            // Assert

            Assert.Equal(-1, bResult);
        }

        [Fact]
        public void Contains_WithNullArray_ShouldReturnFalse()
        {
            // Arrange

            byte[]? b = null;

            // Act

            var bResult = b.Contains(2);

            // Assert

            Assert.False(bResult);
        }

        [Fact]
        public void IndexOf_WithNonExistingItem_ShouldReturnMinusOne()
        {
            // Arrange

            var b = new byte[] { 1, 2, 3 };
            var s = new short[] { 1, 2, 3 };
            var i = new int[] { 1, 2, 3 };
            var l = new long[] { 1, 2, 3 };
            var f = new float[] { 1.0F, 2.0F, 3.0F };
            var d = new double[] { 1.0D, 2.0D, 3.0D };
            var m = new decimal[] { 1.0M, 2.0M, 3.0M };
            var str = new string[] { "1", "2", "3" };

            // Act

            var bResult = b.IndexOf(4);
            var sResult = s.IndexOf(4);
            var iResult = i.IndexOf(4);
            var lResult = l.IndexOf(4);
            var fResult = f.IndexOf(4.0F);
            var dResult = d.IndexOf(4.0D);
            var mResult = m.IndexOf(4.0M);
            var strResult = str.IndexOf("4");
            var tStrResult = str.IndexOf<string>("4");

            // Assert

            Assert.Equal(-1, bResult);
            Assert.Equal(-1, sResult);
            Assert.Equal(-1, iResult);
            Assert.Equal(-1, lResult);
            Assert.Equal(-1, fResult);
            Assert.Equal(-1, dResult);
            Assert.Equal(-1, mResult);
            Assert.Equal(-1, strResult);
            Assert.Equal(-1, tStrResult);
        }

        [Fact]
        public void Contains_WithNonExistingItem_ShouldReturnFalse()
        {
            // Arrange

            var b = new byte[] { 1, 2, 3 };
            var s = new short[] { 1, 2, 3 };
            var i = new int[] { 1, 2, 3 };
            var l = new long[] { 1, 2, 3 };
            var f = new float[] { 1.0F, 2.0F, 3.0F };
            var d = new double[] { 1.0D, 2.0D, 3.0D };
            var m = new decimal[] { 1.0M, 2.0M, 3.0M };
            var str = new string[] { "1", "2", "3" };

            // Act

            var bResult = b.Contains(4);
            var sResult = s.Contains(4);
            var iResult = i.Contains(4);
            var lResult = l.Contains(4);
            var fResult = f.Contains(4.0F);
            var dResult = d.Contains(4.0D);
            var mResult = m.Contains(4.0M);
            var strResult = str.Contains("4");
            var tStrResult = str.Contains<string>("4");

            // Assert

            Assert.False(bResult);
            Assert.False(sResult);
            Assert.False(iResult);
            Assert.False(lResult);
            Assert.False(fResult);
            Assert.False(dResult);
            Assert.False(mResult);
            Assert.False(strResult);
            Assert.False(tStrResult);
        }

        [Fact]
        public void GetKey_WithNullValueForKvpAndInput_ShouldReturnKey()
        {
            // Arrange

            IDictionary<string, string?> dictionary = new Dictionary<string, string?>() { { "a", "b" }, { "c", null } };

            // Act

            var result = dictionary.GetKey(null);

            // Assert

            Assert.Equal("c", result);
        }

        [Fact]
        public void GetKey_WithNullInput_ShouldReturnNull()
        {
            // Arrange

            IDictionary<string, string> dictionary = new Dictionary<string, string>() { { "a", "b" }, { "c", "d" } };

            // Act

            var result = dictionary.GetKey<string, string>(null);

            // Assert

            Assert.Null(result);
        }

        [Fact]
        public void GetKey_WithNotMappedInput_ShouldReturnNull()
        {
            // Arrange

            IDictionary<string, string> dictionary = new Dictionary<string, string>() { { "a", "b" }, { "c", "d" } };

            // Act

            var result = dictionary.GetKey<string, string>("x");

            // Assert

            Assert.Null(result);
        }

        [Fact]
        public void GetKey_WithMappedInput_ShouldReturnKey()
        {
            // Arrange

            IDictionary<string, string> dictionary = new Dictionary<string, string>() { { "a", "b" }, { "c", "d" } };

            // Act

            var result = dictionary.GetKey<string, string>("d");

            // Assert

            Assert.Equal("c", result);
        }

        [Fact]
        public void GetKey_WithNullDictionary_ShouldReturnDefault()
        {
            // Arrange

            IDictionary<string, string>? dictionary = null;

            // Act

            var result = dictionary.GetKey("d");

            // Assert

            Assert.Null(result);
        }
    }
}