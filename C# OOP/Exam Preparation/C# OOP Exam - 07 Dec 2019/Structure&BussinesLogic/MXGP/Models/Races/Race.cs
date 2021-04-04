using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders.Contracts;
using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
namespace MXGP.Models.Races
{
    public class Race : IRace
    {
        private const int MIN_SYMBOL = 5;
        private const int MIN_LAPS = 1;
        private List<IRider> riders;

        private string name;
        private int laps;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;

            this.riders = new List<IRider>();
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

        public int Laps
        {
            get { return this.laps; }
            private set
            {
                if (value < MIN_LAPS)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidNumberOfLaps, MIN_LAPS));
                }
                this.laps = value;
            }
        }

        public IReadOnlyCollection<IRider> Riders => this.riders.AsReadOnly();

        public void AddRider(IRider rider)
        {
            if (rider==null)
            {
                throw new ArgumentException(ExceptionMessages.RiderInvalid);
            }
            if (!rider.CanParticipate)
            {
                throw new ArgumentException(String.Format( ExceptionMessages.RiderNotParticipate,rider.Name));
            }
            if (this.Riders.Contains(rider))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.RiderAlreadyAdded, rider.Name,this.Name));
            }

            this.riders.Add(rider);
        }
    }
}
