using System.Collections.Generic;

namespace _MilitaryElite.Contracts
{
    public interface IEngineer : ISpecialisedSoldier
    {
        IReadOnlyCollection<IRepair> Repairs { get; }
        void AddRepair(IRepair repair);
    }
}
