using EasterRaces.Models.Drivers.Contracts;

namespace EasterRaces.Models.Races.Contracts
{
    using System.Collections.Generic;

    public interface IRace
    {
        string Name { get; }

        int Laps { get; }

        IReadOnlyCollection<Drivers.Contracts.IDriver> Drivers { get; }

        void AddDriver(Drivers.Contracts.IDriver driver);
    }
}