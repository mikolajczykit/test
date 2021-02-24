using System;
using System.Globalization;
using Xunit;

namespace newx
{
    // class name which is tested with tests
    public class LogicTests
    {
        // sut - system under test
        public Logic sut = new Logic();

        //[Fact] - bez parametrow wejsciowych
        [Theory]
        [InlineData("23123.0000", "23123")]
        [InlineData("23123.0", "23123")]
        [InlineData("23123", "23123")]
        [InlineData("23123.0010", "23123.001")]
        public void RemoveZeros_PassDecimalsWithZeros_ReturnsStringWithoutZeros(string testCase, string expectedValue)
        {
            // arrange - perpare data

            // act - execute tested method
            var result = sut.RemoveZeros(testCase);
            // assert
            Assert.Equal(expectedValue, result);
        }

        [Theory]
        [InlineData("sdasd23123.0000", "sdasd23123.0000")]
        [InlineData("sdasd23123.0020", "sdasd23123.0020")]
        [InlineData("23123sfdsf.0020", "23123sfdsf.0020")]
        [InlineData("23123sfdsf.0", "23123sfdsf.0")]
        [InlineData("sfdas", "sfdas")]
        [InlineData("123.sfdas", "123.sfdas")]
        [InlineData("sfdas.123", "sfdas.123")]
        [InlineData("000.123s", "000.123s")]
        [InlineData(null, null)]
        public void RemoveZeros_PassStringsWithNumbers_ReturnsOriginalString(string testCase, string expectedValue)
        {
            // arrange - perpare data

            // act - execute tested method
            var result = sut.RemoveZeros(testCase);
            // assert
            Assert.Equal(expectedValue, result);
        }
    }

    public class Logic
    {
        public string RemoveZeros(string text)
        {
            if(decimal.TryParse(text, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out var number))
            {
                return number.ToString("0.#################", CultureInfo.InvariantCulture);
            }

            return text;
        }
    }
}
