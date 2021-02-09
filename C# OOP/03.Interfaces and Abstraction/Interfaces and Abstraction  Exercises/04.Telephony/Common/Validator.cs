using System;
using System.Linq;

namespace _04.Telephony.Common
{
    public static class Validator
    {
        public static bool IsNumberValid(string number) => number.All(Char.IsDigit);

        public const string INVALID_NUMBER = "Invalid number!";
        public const int NUMBER_IS_LONG = 10;

        public static bool IsSiteValid(string site) => site.Any(Char.IsDigit);

        public const string INVALID_SITE = "Invalid URL!";
    }
}
