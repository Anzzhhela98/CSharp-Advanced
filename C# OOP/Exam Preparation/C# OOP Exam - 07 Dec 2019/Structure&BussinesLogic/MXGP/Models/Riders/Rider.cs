using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Riders.Contracts;
using MXGP.Utilities.Messages;
using System;


namespace MXGP.Models.Riders
{
    public class Rider : IRider
    {
        private const int MIN_SYMBOL = 5;
        private string name;

        public Rider(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (String.IsNullOrEmpty(value) || value.Length < MIN_SYMBOL)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidName, value, MIN_SYMBOL));
                }
                this.name = value;
            }
        }

        public IMotorcycle Motorcycle { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate => this.Motorcycle != null;

        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            if (motorcycle == null)
            {
                throw new ArgumentException(ExceptionMessages.MotorcycleInvalid);
            }

            this.Motorcycle = motorcycle;

        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
