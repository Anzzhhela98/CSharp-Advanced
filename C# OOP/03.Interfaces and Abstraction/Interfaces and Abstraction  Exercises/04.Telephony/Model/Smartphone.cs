using _04.Telephony.Contract;
using System;
namespace _04.Telephony
{
    public class Smartphone : IBrowsing, ICallable
    {

        public string Browsing(string site)
        {
            if (Common.Validator.IsSiteValid(site))
            {
                throw new InvalidOperationException(String.Format(Common.Validator.INVALID_SITE));
            }

            return $"Browsing: {site}!";
        }

        public string Calling(string number)
        {
            if (!Common.Validator.IsNumberValid(number))
            {
                throw new InvalidOperationException(String.Format(Common.Validator.INVALID_NUMBER));
            }

            return $"Calling... {number}";
        }
    }
}
