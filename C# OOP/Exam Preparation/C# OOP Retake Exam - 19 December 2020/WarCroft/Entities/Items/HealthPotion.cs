using WarCroft.Entities.Characters.Contracts;

namespace WarCroft.Entities.Items
{
    public class HealthPotion : Item
    {
        private const int InitialWeight = 5;
        private const int Points = 20;
        public HealthPotion() : base(InitialWeight)
        {

        }
        public override void AffectCharacter(Character character)
        {
            base.AffectCharacter(character);

            character.Health += Points;
        }
    }
}
