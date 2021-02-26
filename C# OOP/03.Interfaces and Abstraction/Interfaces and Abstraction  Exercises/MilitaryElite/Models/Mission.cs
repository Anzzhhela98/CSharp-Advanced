using _MilitaryElite.Contracts;
using _MilitaryElite.Enumerations;
using _MilitaryElite.Exceptions;
using _MilitaryElite.Exeptions;
using System;

namespace _MilitaryElite.Models
{
    public class Mission : IMission
    {
        public Mission(string coldName, string state)
        {
            this.CodeName = coldName;
            this.State = this.TryParseState(state);
        }

        public string CodeName { get; private set; }

        public State State { get; private set; }

        public void CompleteMission()
        {
            if (this.State == State.Finished)
            {
                throw new InavlidCompletionExeption();

            }

            this.State = State.Finished;
        }
        private State TryParseState(string stateStr)
        {
            State state;
            bool parsed = Enum.TryParse<State>(stateStr, out state);

            if (!parsed)
            {
                throw new InvalidMissionStateExeption();
            }
            return state;
        }
        public override string ToString()
        {
            return $"  Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
