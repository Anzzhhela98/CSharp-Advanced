using _04.Telephony.Contract;
using System;


namespace _04.Telephony.Model
{
    public class StationaryPhone : ICallable
    {
        public string Calling(string number)
        {
            if (!Common.Validator.IsNumberValid(number))
            {
                throw new InvalidOperationException(String.Format(Common.Validator.INVALID_NUMBER));
            }

            return $"Dialing... {number}";
        }
    }
}
