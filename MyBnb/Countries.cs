using System;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace MyBnb
{
    public static class Countries
    {
        static Regex countryCodeRegExp = new Regex("[a-z]{2}");

        internal static bool CodeIsValid(Func<string, bool> codeExists, string code) =>
            CodeHasCorrectFormat(code) && CodeExists(code);

        public static bool CodeIsValid(string code) =>
            CodeIsValid(CodeExists, code);

        static bool CodeHasCorrectFormat(string code) =>
            countryCodeRegExp.IsMatch(code);

        static bool CodeExists(string code) 
        {
            var uri = $"https://restcountries.eu/rest/v2/alpha/{code}";
            var request = new HttpClient().GetAsync(uri);
            return request.Result.StatusCode != HttpStatusCode.NotFound;
        }
    }
}
