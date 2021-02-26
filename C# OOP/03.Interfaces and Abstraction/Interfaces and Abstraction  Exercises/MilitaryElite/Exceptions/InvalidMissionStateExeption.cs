using System;

namespace _MilitaryElite.Exeptions
{
    public class InvalidMissionStateExeption : Exception
    {
        private const string DEF_EXC_MSG = "Invalid mission state";
        public InvalidMissionStateExeption():base(DEF_EXC_MSG)
        {

        }

        public InvalidMissionStateExeption(string message)
            : base(message)
        {

        }
    }
}
