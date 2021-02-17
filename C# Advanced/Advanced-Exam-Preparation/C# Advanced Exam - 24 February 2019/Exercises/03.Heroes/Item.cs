using System.Text;

namespace Heroes
{
    public class Item
    {
        public Item(int strength, int ability, int intelligence)
        {
            this.Strength = strength;
            this.Ability = ability;
            this.Intelligence = intelligence;
        }

        public int Strength { get; set; }
        public int Ability { get; set; }
        public int Intelligence { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Item:");
            sb.AppendLine($"  * Strength: {Strength}");
            sb.AppendLine($"  * Ability: {Ability}");
            sb.AppendLine($"  * Intelligence: {Intelligence}");
            return sb.ToString().TrimEnd();
        }
    }
}
