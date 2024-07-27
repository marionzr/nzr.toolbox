using System;
using System.Globalization;
using System.Threading;
using Xunit;
using static Nzr.ToolBox.Core.ToolBox;

namespace Nzr.ToolBox.Core.Tests
{
    public class StringUtilsTest
    {
        [Fact()]
        public void Suffix_WithNullString_ShouldReturnSuffix()
        {
            // Arrange

            string? s = null;

            // Act

            var withSuffix = s.Suffix("nzr");

            // Assert

            Assert.Equal("nzr", withSuffix);
        }

        [Fact()]
        public void Suffix_WithNonExistingSuffix_ShouldAddSuffix()
        {
            // Arrange

            var s = "owner";

            // Act

            var withSuffix = s.Suffix(".nzr");

            // Assert

            Assert.Equal("owner.nzr", withSuffix);
        }

        [Fact()]
        public void Suffix_WithExistingSuffix_ShouldNotAddSuffix()
        {
            // Arrange

            var s = "owner.nzr";

            // Act

            var withSuffix = s.Suffix(".nzr");

            // Assert

            Assert.Equal("owner.nzr", withSuffix);
        }

        [Fact()]
        public void Suffix_WithExistingSuffixAndOverride_ShouldAddSuffix()
        {
            // Arrange

            var s = "owner.nzr";

            // Act

            var withSuffix = s.Suffix(".nzr", false);

            // Assert

            Assert.Equal("owner.nzr.nzr", withSuffix);
        }

        [Fact()]
        public void Prefix_WithNullString_ShouldReturnPrefix()
        {
            // Arrange

            string? s = null;

            // Act

            var withSuffix = s.Prefix("owner");

            // Assert

            Assert.Equal("owner", withSuffix);
        }

        [Fact()]
        public void Prefix_WithNonExistingPrefix_ShouldAddPrefix()
        {
            // Arrange

            var s = "nzr";

            // Act

            var result = s.Prefix("owner.");

            // Assert

            Assert.Equal("owner.nzr", result);
        }

        [Fact()]
        public void Prefix_WithExistingPrefix_ShouldNotAddPrefix()
        {
            // Arrange

            var s = "owner.nzr";

            // Act

            var result = s.Prefix("owner.");

            // Assert

            Assert.Equal("owner.nzr", result);
        }

        [Fact()]
        public void Prefix_WithExistingPrefixAndOverride_ShouldAddPrefix()
        {
            // Arrange

            var s = "owner.nzr";

            // Act

            var result = s.Prefix("owner.", false);

            // Assert

            Assert.Equal("owner.owner.nzr", result);
        }

        [Fact()]
        public void Capitalize_WithNull_ShouldReturnNull()
        {
            // Arrange

            string? phrase = null;

            // Act

            var result = phrase.Capitalize();

            // Assert

            Assert.Null(result);
        }

        [Fact()]
        public void Capitalize_WithNonCapitalized_ShouldReturnCapitalized()
        {
            // Arrange

            var phrase = "the placid shores of the Ipiranga heard, the resounding shout of a heroic folk. " +
                "And the sun of Liberty in shining beams, shone in the homeland's sky at that instant";

            // Act

            var result = phrase.Capitalize();

            // Assert

            Assert.Equal("The Placid Shores Of The Ipiranga Heard, The Resounding Shout Of A Heroic Folk. " +
                "And The Sun Of Liberty In Shining Beams, Shone In The Homeland's Sky At That Instant", result);
        }

        [Fact()]
        public void RemoveEnd_WithNull_ShouldReturnNull()
        {
            // Arrange

            string? word = null;

            // Act

            var result = word.RemoveEnd("Orm.", "Attribute");

            // Assert

            Assert.Null(result);
        }

        [Fact()]
        public void RemoveEnd_WithExistingStrings_ShouldReturnCleanedString()
        {
            // Arrange

            var word = "Nzr.Orm.Attribute.Attribute";

            // Act

            var result = word.RemoveEnd("Orm.", "Attribute", "another");

            // Assert

            Assert.Equal("Nzr.Attribute.", result);
        }


        [Fact()]
        public void RemoveEnd_WithExistingStringsUsingOrdinalCase_ShouldNotRemoveEnds()
        {
            // Arrange

            var word = "Nzr.Orm.Attribute";

            // Act

            var result = word.RemoveEnd(StringComparison.Ordinal, "orm.", "attribute", "another");

            // Assert

            Assert.Equal("Nzr.Orm.Attribute", result);
        }

        [Fact()]
        public void RemoveStart_WithNull_ShouldReturnNull()
        {
            // Arrange

            string? word = null;

            // Act

            var result = word.RemoveStart("Nzr.", "Attribute");

            // Assert

            Assert.Null(result);
        }

        [Fact()]
        public void RemoveStart_WithExistingStrings_ShouldReturnCleanedString()
        {
            // Arrange

            var word = "Nzr.Nzr.Orm.Attribute";

            // Act

            var result = word.RemoveStart("Nzr.", "Attribute", "another");

            // Assert

            Assert.Equal("Nzr.Orm.", result);
        }


        [Fact()]
        public void RemoveStart_WithExistingStringsUsingOrdinalCase_ShouldNotRemoveStarts()
        {
            // Arrange

            var word = "Nzr.Nzr.Orm.Attribute";

            // Act

            var result = word.RemoveStart(StringComparison.Ordinal, "nzr.", "orm.", "another");

            // Assert

            Assert.Equal("Nzr.Nzr.Orm.Attribute", result);
        }

        [Fact()]
        public void IsEmpty_WithNullString_ShouldReturnTrue()
        {
            // Arrange

            string? s = null;

            // Act

            var result = s.IsEmpty();

            // Assert

            Assert.True(result);
        }

        [Fact()]
        public void IsEmpty_WithEmptyString_ShouldReturnTrue()
        {
            // Arrange

            var s = string.Empty;

            // Act

            var result = s.IsEmpty();

            // Assert

            Assert.True(result);
        }

        [Fact()]
        public void IsEmpty_WithBlankString_ShouldReturnFalse()
        {
            // Arrange

            var s = " ";

            // Act

            var result = s.IsEmpty();

            // Assert

            Assert.False(result);
        }


        [Fact()]
        public void IsNotEmpty_WithNullString_ShouldReturnFalse()
        {
            // Arrange

            string? s = null;

            // Act

            var result = s.IsNotEmpty();

            // Assert

            Assert.False(result);
        }

        [Fact()]
        public void IsNotEmpty_WithEmptyString_ShouldReturnFalse()
        {
            // Arrange

            var s = string.Empty;

            // Act

            var result = s.IsNotEmpty();

            // Assert

            Assert.False(result);
        }

        [Fact()]
        public void IsNotEmpty_WithBlankString_ShouldReturnTrue()
        {
            // Arrange

            var s = " ";

            // Act

            var result = s.IsNotEmpty();

            // Assert

            Assert.True(result);
        }

        [Fact()]
        public void IsBlank_WithNullString_ShouldReturnTrue()
        {
            // Arrange

            string? s = null;

            // Act

            var result = s.IsBlank();

            // Assert

            Assert.True(result);
        }

        [Fact()]
        public void IsBlank_WithEmptyString_ShouldReturnTrue()
        {
            // Arrange

            var s = string.Empty;

            // Act

            var result = s.IsBlank();

            // Assert

            Assert.True(result);
        }

        [Fact()]
        public void IsIsBlank_WithBlankString_ShouldReturnTrue()
        {
            // Arrange

            var s = " ";

            // Act

            var result = s.IsBlank();

            // Assert

            Assert.True(result);
        }

        [Fact()]
        public void IsIsBlank_WithNonBlankString_ShouldReturnTrue()
        {
            // Arrange

            var s = ".";

            // Act

            var result = s.IsBlank();

            // Assert

            Assert.False(result);
        }

        [Fact()]
        public void IsNotBlank_WithNullString_ShouldReturnFalse()
        {
            // Arrange

            string? s = null;

            // Act

            var result = s.IsNotBlank();

            // Assert

            Assert.False(result);
        }

        [Fact()]
        public void IsNotBlank_WithEmptyString_ShouldReturnFalse()
        {
            // Arrange

            var s = string.Empty;

            // Act

            var result = s.IsNotBlank();

            // Assert

            Assert.False(result);
        }

        [Fact()]
        public void IsNotBlank_WithBlankString_ShouldReturnFalse()
        {
            // Arrange

            var s = " ";

            // Act

            var result = s.IsNotBlank();

            // Assert

            Assert.False(result);
        }


        [Fact()]
        public void IsNotBlank_WithBlankString_ShouldReturnTrue()
        {
            // Arrange

            var s = ".";

            // Act

            var result = s.IsNotBlank();

            // Assert

            Assert.True(result);
        }

        [Fact()]
        public void Replace_WithNullString_ShouldReturnDefault()
        {
            // Arrange

            string? a = null;

            // Act

            var result = a.Replace("a", "b", "(null)");

            // Assert

            Assert.Equal("(null)", result);
        }

        [Fact()]
        public void Replace_WithNonNullString_ShouldReplaceOldValueWithNewOne()
        {
            // Arrange

            var a = "aabc";

            // Act

            var result = a.Replace("a", "b", "(null)");

            // Assert

            Assert.Equal("bbbc", result);
        }

        [Fact()]
        public void ContainsAny_WithStringContainingOneOfSubstring_ShouldReturnTrue()
        {
            // Arrange

            var a = "abcd";

            // Act

            var result = a.ContainsAny("a", "c", "z");

            // Assert

            Assert.True(result);
        }

        [Fact()]
        public void ContainsAny_WithStringNotContainingOneOfSubstring_ShouldReturnFalse()
        {
            // Arrange

            var a = "abcd";

            // Act

            var result = a.ContainsAny("x", "y", "z");

            // Assert

            Assert.False(result);
        }

        [Fact()]
        public void ContainsAny_WithOrdinalIgnoreCaseStringContainingOneOfSubstring_ShouldReturnTrue()
        {
            // Arrange

            var a = "abcd";

            // Act

            var result = a.ContainsAny("A", "C", "z");

            // Assert

            Assert.True(result);
        }

        [Fact()]
        public void ContainsAny_WithOrdinalIgnoreCaseStringNotContainingOneOfSubstring_ShouldReturnFalse()
        {
            // Arrange

            var a = "abcd";

            // Act

            var result = a.ContainsAny(StringComparison.OrdinalIgnoreCase, "x", "y", "z");

            // Assert

            Assert.False(result);
        }

        [Fact()]
        public void ContainsAny_WithOrdinalIgnoreCaseNullString_ShouldReturnFalse()
        {
            // Arrange

            string? a = null;

            // Act

            var result = a.ContainsAny(StringComparison.OrdinalIgnoreCase, "x", "y", "z");

            // Assert

            Assert.False(result);
        }

        [Fact()]
        public void ContainsAny_WithOrdinalIgnoreCaseNullStringWithNullAsSubstrings_ShouldReturnTrue()
        {
            // Arrange

            string? a = null;

            // Act

            var result = a.ContainsAny(StringComparison.OrdinalIgnoreCase, null, null);

            // Assert

            Assert.True(result);
        }

        [Fact()]
        public void ContainsNone_WithStringContainingOneOfSubstring_ShouldReturnFalse()
        {
            // Arrange

            var a = "abcd";

            // Act

            var result = a.ContainsNone("a", "c", "z");

            // Assert

            Assert.False(result);
        }

        [Fact()]
        public void ContainsNone_WithStringNotContainingOneOfSubstring_ShouldReturnTrue()
        {
            // Arrange

            var a = "abcd";

            // Act

            var result = a.ContainsNone("x", "y", "z");

            // Assert

            Assert.True(result);
        }

        [Fact()]
        public void ContainsNone_WithOrdinalIgnoreCaseStringContainingOneOfSubstring_ShouldReturnFalse()
        {
            // Arrange

            var a = "abcd";

            // Act

            var result = a.ContainsNone("A", "C", "z");

            // Assert

            Assert.False(result);
        }

        [Fact()]
        public void ContainsNone_WithOrdinalIgnoreCaseStringNotContainingOneOfSubstring_ShouldReturnTrue()
        {
            // Arrange

            var a = "abcd";

            // Act

            var result = a.ContainsNone(StringComparison.OrdinalIgnoreCase, "x", "y", "z");

            // Assert

            Assert.True(result);
        }

        [Fact()]
        public void ContainsAll_WithStringContainigAllSubstrings_ShouldReturnTrue()
        {
            // Arrange

            var a = "abc";

            // Act

            var result = a.ContainsAll("a", "b", "c");

            // Assert

            Assert.True(result);
        }

        [Fact()]
        public void ContainsAll_WithStringNotContainigAllSubstrings_ShouldReturnFalse()
        {
            // Arrange

            var a = "abc";

            // Act

            var result = a.ContainsAll("a", "b", "c", "d");

            // Assert

            Assert.False(result);
        }

        [Fact()]
        public void ContainsAll_WithNullStringContainigAllNullSubstrings_ShouldReturnTrue()
        {
            // Arrange

            string? a = null;

            // Act

            var result = a.ContainsAll(null, null);

            // Assert

            Assert.True(result);
        }

        [Fact()]
        public void ContainsAll_WithNullStringNotContainigAllSubstrings_ShouldReturnFalse()
        {
            // Arrange

            string? a = null;

            // Act

            var result = a.ContainsAll(null, "a");

            // Assert

            Assert.False(result);
        }

        [Fact()]
        public void DefaultIfEmpty_WithNullString_ShouldReturnDefault()
        {
            // Arrange

            string? s = null;

            // Act

            var result = s.DefaultIfEmpty("default");

            // Assert

            Assert.Equal("default", result);
        }

        [Fact()]
        public void DefaultIfEmpty_WitEmptyString_ShouldReturnDefault()
        {
            // Arrange

            var s = string.Empty;

            // Act

            var result = s.DefaultIfEmpty("default");

            // Assert

            Assert.Equal("default", result);
        }

        [Fact()]
        public void DefaultIfEmpty_WitBlankString_ShouldReturnString()
        {
            // Arrange

            var s = " ";

            // Act

            var result = s.DefaultIfEmpty("default");

            // Assert

            Assert.Equal(" ", result);
        }

        [Fact()]
        public void DefaultIfBlank_WithNullString_ShouldReturnDefault()
        {
            // Arrange

            string? s = null;

            // Act

            var result = s.DefaultIfBlank("default");

            // Assert

            Assert.Equal("default", result);
        }

        [Fact()]
        public void DefaultIfBlank_WitEmptyString_ShouldReturnDefault()
        {
            // Arrange

            var s = string.Empty;

            // Act

            var result = s.DefaultIfBlank("default");

            // Assert

            Assert.Equal("default", result);
        }

        [Fact()]
        public void DefaultIfBlank_WitBlankString_ShouldReturnDefault()
        {
            // Arrange

            var s = " ";

            // Act

            var result = s.DefaultIfBlank("default");

            // Assert

            Assert.Equal("default", result);
        }

        [Fact()]
        public void DefaultIfBlank_WitNonBlankString_ShouldReturnString()
        {
            // Arrange

            var s = ".";

            // Act

            var result = s.DefaultIfBlank("default");

            // Assert

            Assert.Equal(".", result);
        }

        [Fact()]
        public void GetFirstNonEmpty_WithNonEmptyString_ShouldReturnNonEmptyString()
        {
            // Arrange

            // Act

            var result = GetFirstNonEmpty("", null, "a", "", "b");

            // Assert

            Assert.Equal("a", result);
        }

        [Fact()]
        public void GetFirstNonEmpty_WithOnlyEmptyString_ShouldReturnNull()
        {
            // Arrange

            // Act

            var result = GetFirstNonEmpty("", null, "", "", null);

            // Assert

            Assert.Null(result);
        }

        [Fact()]
        public void GetFirstNonBlank_WithNonBlankString_ShouldReturnNonBlankString()
        {
            // Arrange

            // Act

            var result = GetFirstNonBlank("", null, "a", " ", "b");

            // Assert

            Assert.Equal("a", result);
        }

        [Fact()]
        public void GetFirstNonBlank_WithOnlyEmptyString_ShouldReturnNull()
        {
            // Arrange

            // Act

            var result = GetFirstNonBlank("", null, " ", "a", null);

            // Assert

            Assert.Equal("a", result);
        }

        [Fact()]
        public void IsAllEmpty_WithNullStrings_ShouldReturnTrue()
        {
            // Arrange


            // Act

            var result = IsAllEmpty(null, null);

            // Assert

            Assert.True(result);
        }

        [Fact()]
        public void IsAllEmpty_WithNullOrEmptyStrings_ShouldReturnTrue()
        {
            // Arrange


            // Act

            var result = IsAllEmpty(null, string.Empty);

            // Assert

            Assert.True(result);
        }

        [Fact()]
        public void IsAllEmpty_WithOneNonEmpty_ShouldReturnFalse()
        {
            // Arrange


            // Act

            var result = IsAllEmpty(null, string.Empty, "a");

            // Assert

            Assert.False(result);
        }

        [Fact()]
        public void IsAllBlank_WithNullStrings_ShouldReturnTrue()
        {
            // Arrange


            // Act

            var result = IsAllBlank(null, null);

            // Assert

            Assert.True(result);
        }

        [Fact()]
        public void IsAllBlank_WithNullOrBlankStrings_ShouldReturnTrue()
        {
            // Arrange


            // Act

            var result = IsAllBlank(null, string.Empty, " ");

            // Assert

            Assert.True(result);
        }

        [Fact()]
        public void IsAllBlank_WithOneEmpty_ShouldReturnTrue()
        {
            // Arrange


            // Act

            var result = IsAllBlank(null, string.Empty);

            // Assert

            Assert.True(result);
        }

        [Fact()]
        public void IsAnyEmpty_WithOneNullStrings_ShouldReturnTrue()
        {
            // Arrange

            // Act

            var result = IsAnyEmpty(null, null);

            // Assert

            Assert.True(result);
        }

        [Fact()]
        public void IsAnyEmpty_WithNullOrEmptyStrings_ShouldReturnTrue()
        {
            // Arrange


            // Act

            var result = IsAnyEmpty(null, string.Empty, "a");

            // Assert

            Assert.True(result);
        }

        [Fact()]
        public void IsAnyEmpty_WithOneNonEmpty_ShouldReturnTrue()
        {
            // Arrange


            // Act

            var result = IsAnyEmpty(null, "a");

            // Assert

            Assert.True(result);
        }


        [Fact()]
        public void IsAnyBlank_WithNullStrings_ShouldReturnTrue()
        {
            // Arrange


            // Act

            var result = IsAnyBlank(null, "a");

            // Assert

            Assert.True(result);
        }

        [Fact()]
        public void IsAnyBlank_WithNullOrEmptyStrings_ShouldReturnTrue()
        {
            // Arrange


            // Act

            var result = IsAnyBlank(null, string.Empty, "a");

            // Assert

            Assert.True(result);
        }

        [Fact()]
        public void IsAnyBlank_WithOneBlank_ShouldReturnTrue()
        {
            // Arrange


            // Act

            var result = IsAnyBlank(null, " ");

            // Assert

            Assert.True(result);
        }

        [Fact()]
        public void Remove_WithNonNullString_ShouldRemoveGiveStrings()
        {
            // Arrange

            var a = "abcd";

            // Act

            var result = a.Remove("bc");

            // Assert

            Assert.Equal("ad", result);
        }

        [Fact()]
        public void Remove_WithNullString_ShouldReturnNull()
        {
            // Arrange

            string? a = null;

            // Act

            var result = a.Remove("bc");

            // Assert

            Assert.Null(result);
        }

        [Fact()]
        public void Repeat_WithNull_ShouldReturnNull()
        {
            // Arrange

            string? a = null;

            // Act

            var result = a.Repeat(3);

            // Assert

            Assert.Null(result);
        }

        [Fact()]
        public void Repeat_WithNonNull_ShouldReturnValuesTimesGiven()
        {
            // Arrange

            var a = "abc";

            // Act

            var result = a.Repeat(3);

            // Assert

            Assert.Equal("abcabcabc", result);
        }

        [Fact()]
        public void Reverse_WithNull_ShouldReturnNull()
        {
            // Arrange

            string? a = null;

            // Act

            var result = a.Reverse();

            // Assert

            Assert.Null(result);
        }

        [Fact()]
        public void Reverse_WithString_ShouldReturnReversedString()
        {
            // Arrange

            var a = "abc";

            // Act

            var result = a.Reverse();

            // Assert

            Assert.Equal("cba", result);
        }

        [Fact()]
        public void RemoveDiacritics_WithNull_ShouldReturnNull()
        {
            // Arrange

            string? a = null;

            // Act

            var result = a.RemoveDiacritics();

            // Assert

            Assert.Null(result);
        }

        [Fact()]
        public void RemoveDiacritics_WithString_ShouldReturnStringWihtouDiacritics()
        {
            // Arrange

            var a = "Ciências da Computação - CIÊNCIAS DA COMPUTAÇÃO";

            // Act

            var result = a.RemoveDiacritics();

            // Assert

            Assert.Equal("Ciencias da Computacao - CIENCIAS DA COMPUTACAO", result);
        }

        [Fact()]
        public void Truncate_WithNull_ShouldReturnNull()
        {
            // Arrange

            string? a = null;

            // Act

            var result = a.Truncate(5);

            // Assert

            Assert.Null(result);
        }

        [Fact()]
        public void Truncate_WithStringLargerThanLimit_ShouldReturnTruncatedString()
        {
            // Arrange

            var a = "0123456789";

            // Act

            var result = a.Truncate(5);

            // Assert

            Assert.Equal("01234", result);
        }

        [Fact()]
        public void Truncate_WithStringShorterThanLimit_ShouldReturnString()
        {
            // Arrange

            var a = "0123456789";

            // Act

            var result = a.Truncate(14);

            // Assert

            Assert.Equal("0123456789", result);
        }

        [Fact()]
        public void ReplaceNonNumeric_WithNull_ShouldReturnNull()
        {
            // Arrange

            string? s = null;

            // Act

            var result = s.ReplaceNonNumeric();

            // Assert

            Assert.Null(result);
        }

        [Fact()]
        public void ReplaceNonNumeric_WithAlphanumeric_ShouldReturnNumericString()
        {
            // Arrange

            var s = "+55(31)9 8765-4321";

            // Act

            var result = s.ReplaceNonNumeric();

            // Assert

            Assert.Equal("5531987654321", result);
        }

        [Fact()]
        public void IsNumber_WithNull_ShouldReturnFalse()
        {
            // Arrange

            string? s = null;

            // Act

            var result = s.IsNumber();

            // Assert

            Assert.False(result);
        }

        [Fact()]
        public void IsNumber_WithAlhphanumeric_ShouldReturnFalse()
        {
            // Arrange

            var s = "a12345";

            // Act

            var result = s.IsNumber();

            // Assert

            Assert.False(result);
        }

        [Fact()]
        public void IsNumber_WithNumeric_ShouldReturnTrue()
        {
            // Arrange

            var s = "0000123";

            // Act

            var result = s.IsNumber();

            // Assert

            Assert.True(result);
        }

        [Fact()]
        public void IsNotNumber_WithNull_ShouldReturnTrue()
        {
            // Arrange

            string? s = null;

            // Act

            var result = s.IsNotNumber();

            // Assert

            Assert.True(result);
        }

        [Fact()]
        public void IsNotNumber_WithAlhphanumeric_ShouldReturnTrue()
        {
            // Arrange

            var s = "a12345";

            // Act

            var result = s.IsNotNumber();

            // Assert

            Assert.True(result);
        }

        [Fact()]
        public void IsNotNumber_WithNumeric_ShouldReturnFalse()
        {
            // Arrange

            var s = "0000123";

            // Act

            var result = s.IsNotNumber();

            // Assert

            Assert.False(result);
        }

        [Fact]
        public void DescribeIfNone_WithNull_ShouldReturnNullString()
        {
            // Arrange

            string? a = null;

            // Act

            var result = a.DescribeIfNone();

            // Assert

            Assert.Equal("(null)", result);
        }

        [Fact]
        public void DescribeIfNone_WithEmpty_ShouldReturnEmptyString()
        {
            // Arrange

            var a = string.Empty;

            // Act

            var result = a.DescribeIfNone();

            // Assert

            Assert.Equal("(empty)", result);
        }

        [Fact]
        public void DescribeIfNone_WithBlank_ShouldReturnBlankString()
        {
            // Arrange

            var a = " ";

            // Act

            var result = a.DescribeIfNone();

            // Assert

            Assert.Equal("(blank)", result);
        }

        [Fact]
        public void DescribeIfNone_WithRegularString_ShouldReturnString()
        {
            // Arrange

            var a = "Nzr.Orm";

            // Act

            var result = a.DescribeIfNone();

            // Assert

            Assert.Equal("Nzr.Orm", result);
        }

        [Fact]
        public void Format_WithNullString_ShouldReturnNull()
        {
            // Arrange

            var culture = Thread.CurrentThread.CurrentCulture;
            string? s = null;

            // Act

            var result1 = s.Format("1", "2");
            var result2 = s.Format(culture, "1", "2");

            // Act

            Assert.True(IsAllNull(result1, result2));
        }

        [Fact]
        public void Format_WithFormatString_ShouldReturnFormatedString()
        {
            // Arrange

            var s = "Value is {0}";

            // Act

            var result = s.Format(1.99);

            // Act

            Assert.Equal($"Value is {1.99}", result);
        }

        [Fact]
        public void Format_WithFormatStringWithCulture_ShouldReturnFormatedString()
        {
            // Arrange

            var culture = new CultureInfo("pt-br");
            var s = "Value is {0}";

            // Act

            var result = s.Format(culture, 1.99);

            // Act

            Assert.Equal($"Value is 1,99", result);
        }

        [Fact]
        public void Append_WithNullString_ShouldReturnNull()
        {
            // Arrange

            string? s = null;

            // Act

            var result = s.Append("Nzr", ".", "Orm");

            // Assert

            Assert.Null(result);
        }

        [Fact]
        public void Append_WithString_ShouldReturnStringWithAppendedValues()
        {
            // Arrange

            var s = "Fast, simple, convention-based (but configurable) and extensible Micro-Orm: ";

            // Act

            var result = s.Append("Nzr", ".", "Orm");

            // Assert

            Assert.Equal("Fast, simple, convention-based (but configurable) and extensible Micro-Orm: Nzr.Orm", result);
        }

        [Fact]
        public void Equal_WithIgnoreDiacriticsOptionsAndWithNullValues_ShouldReturnTrue()
        {
            // Arrange

            string? a = null;
            string? b = null;

            // Act

            var result = a.Equals(b, true);

            // Assert

            Assert.True(result);
        }

        [Fact]
        public void Equal_WithIgnoreDiacriticsOptionAndWithOneNullValues_ShouldReturnFalse()
        {
            // Arrange

            string? a = null;
            var b = "A";

            // Act

            var result1 = a.Equals(b, true);
            var result2 = b.Equals(a, true);

            // Assert

            Assert.False(result1);
            Assert.False(result2);
        }

        [Fact]
        public void Equal_WithIgnoreDiacriticsOptionTrueAndSimilarWords_ShouldReturnTrue()
        {
            // Arrange

            var a = "CIÊNCIA";
            var b = "CIENCIA";

            // Act

            var result = a.Equals(b, true);

            // Assert

            Assert.True(result);
        }

        [Fact]
        public void Equal_WithIgnoreDiacriticsOptionFalseAndSimilarWords_ShouldReturnFalse()
        {
            // Arrange

            var a = "CIÊNCIA";
            var b = "CIENCIA";

            // Act

            var result = a.Equals(b, false);

            // Assert

            Assert.False(result);
        }
    }
}