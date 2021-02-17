using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    class HeroRepository
    {
        private List<Hero> heros;
        public HeroRepository()
        {
            this.heros = new List<Hero>(0);
        }
        public List<Hero> Heros { get; set; }
        public int Count => this.heros.Count;
        public void Add(Hero hero)
        {
            heros.Add(hero);
        }
        public void Remove(string name)
        {
            Hero hero = heros.FirstOrDefault(x => x.Name == name);
            heros.Remove(hero);
        }
        public Hero GetHeroWithHighestStrength() =>
            heros.OrderByDescending(x => x.Item.Strength).FirstOrDefault();
        public Hero GetHeroWithHighestAbility() =>
           heros.OrderByDescending(x => x.Item.Ability).FirstOrDefault();
        public Hero GetHeroWithHighestIntelligence() =>
           heros.OrderByDescending(x => x.Item.Intelligence).FirstOrDefault();
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var h in heros)
            {
                sb.AppendLine($"Hero: {h.Name} - {h.Level}lvl");
                sb.AppendLine($"Item:");
                sb.AppendLine($"    * Strength: {h.Item.Strength}");
                sb.AppendLine($"    * Ability: {h.Item.Ability}");
                sb.AppendLine($"    * Intelligence: {h.Item.Intelligence}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
