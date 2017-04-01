using System;
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
            var actual = Countries.CodeIsValid(code);
            Assert.Equal(expected, actual);
        }
    }
}
