using System;
using System.Linq;
using System.Collections.Generic;
using EasterRaces.Utilities.Messages;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Drivers.Contracts;

namespace EasterRaces.Models.Races.Entities
{
    public class Race : Contracts.IRace
    {
        private const int MIN_SYMBOL = 5;
        private const int MIN_LAPS = 1;
        private string name;
        private int laps;
        private readonly List<Drivers.Contracts.IDriver> drivers;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;

            this.drivers = new List<Drivers.Contracts.IDriver>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (String.IsNullOrEmpty(value) || value.Length < MIN_SYMBOL)
                {
                    throw new 
                        ArgumentException($"Name {value} cannot be less than {MIN_SYMBOL} symbols."); //?
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
                    throw new 
                        ArgumentException($"Laps cannot be less than {MIN_LAPS}.");
                }
                this.laps = value;
            }
        }

        public IReadOnlyCollection<Drivers.Contracts.IDriver> Drivers => this.drivers;

        public void AddDriver(Drivers.Contracts.IDriver driver)
        {
            if (driver == null)
            {
                throw new ArgumentNullException(nameof(IDriver), "Driver cannot be null");
            }

            if (!driver.CanParticipate)
            {
                throw new ArgumentException($"Driver {driver.Name} could not participate in race.");
            }

            if (this.drivers.Any(x => x.Name == driver.Name))
            {
                throw new ArgumentNullException(nameof(IDriver), $"Driver {driver.Name} is already added in {this.Name} race.");
            }

            this.drivers.Add(driver);
        }
    }
}
