using _MilitaryElite.Enumerations;
namespace _MilitaryElite.Contracts
{
    public interface IMission
    {
        string CodeName { get; }
        State State { get; }
        void CompleteMission();
    }
}
