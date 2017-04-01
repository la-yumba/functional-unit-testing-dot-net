using System;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;

namespace MyBnb
{
    public static class Countries
    {
        static Regex countryCodeRegExp = new Regex("[a-z]{2}");

        // this passes, but unit tests should not do I/O
        // Fast (what if this API is slow)
        // Repeatable (what if 'xx' becomes a country, or you run with no connection?)
        internal static bool CodeIsValid(string code) 
        {
            if (!countryCodeRegExp.IsMatch(code))
                return false;

            var uri = $"https://restcountries.eu/rest/v2/alpha/{code}";
            var request = new HttpClient().GetAsync(uri);
            return request.Result.StatusCode != HttpStatusCode.NotFound;
        }
    }
}
