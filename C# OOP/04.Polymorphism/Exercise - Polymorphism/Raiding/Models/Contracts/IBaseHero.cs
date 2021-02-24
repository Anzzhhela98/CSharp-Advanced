namespace Raiding.Models
{
    interface IBaseHero
    {
        public string Name { get; }
        public int Power { get;  }
        string CastAbility();
    }
}
