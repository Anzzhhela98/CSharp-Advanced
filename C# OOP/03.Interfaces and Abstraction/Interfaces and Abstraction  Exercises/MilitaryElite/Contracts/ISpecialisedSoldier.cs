using _MilitaryElite.Enumerations;

namespace _MilitaryElite.Contracts
{
    public interface ISpecialisedSoldier : IPrivate
    {
         Corps Corps { get; }
    }
}
