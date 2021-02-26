using System;

namespace _MilitaryElite.Exceptions
{
    public class InavlidCompletionExeption : Exception
    {
        private const string DEF_EXS_MSG = "Mission alredy completed!";
        public InavlidCompletionExeption() : base()
        {
        }

        public InavlidCompletionExeption(string message) : base(message)
        {
        }
    }
}
