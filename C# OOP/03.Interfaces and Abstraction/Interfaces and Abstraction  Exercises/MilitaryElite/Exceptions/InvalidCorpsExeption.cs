using System;

namespace _MilitaryElite.Exeptions
{
    public class InvalidCorpsExeption : Exception
    {
        private const string DEF_EXS_MSG = "Invalid corps!";
        public InvalidCorpsExeption():base(DEF_EXS_MSG)
        {

        }

        public InvalidCorpsExeption(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
