using System;
using System.Linq;
using Xunit;

namespace MyBnb.Tests
{
    public class CountriesTests
    {
        [Theory]
        [InlineData("it", true)]
        [InlineData("i", false)]
        [InlineData("xx", false)]
        void OnlyWhenCountryCodeExists_ThenValidationPasses(string code, bool expected)
        {
            Func<string, bool> codeExists = c => 
                new []{"it", "in", "ir"}.Contains(c);

            var actual = Countries.CodeIsValid(codeExists, code);

            Assert.Equal(expected, actual);
        }

        void WhenCodeHasIncorrectFormat_ThenItsExistenceIsNotChecked()
        {
            // can also achieve this by refactoring the previous test
            // to take an additional parameter
            Func<string, bool> codeExists = c => 
            {
                Assert.True(false);
                return true;
            };

            var actual = Countries.CodeIsValid(codeExists, "i");

            Assert.False(actual);
        }
    }
}
