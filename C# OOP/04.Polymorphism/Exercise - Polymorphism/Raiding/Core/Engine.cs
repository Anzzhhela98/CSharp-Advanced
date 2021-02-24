using Raiding.Enumerator;
using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Core
{
    public class Engine : IEngine
    {

        public void Run()
        {
            List<BaseHero> heroes = new List<BaseHero>();

            int countOfHeroes = int.Parse(Console.ReadLine());

            for (int i = 0; i < countOfHeroes; i++)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();

                try
                {
                    BaseHero hero = null;

                    if (SearchHero(heroType) == Heroes.Druid)
                    {
                        heroes.Add(new Druid(heroName));
                    }
                    else if (SearchHero(heroType) == Heroes.Paladin)
                    {
                        heroes.Add(new Paladin(heroName));
                    }
                    else if (SearchHero(heroType) == Heroes.Rogue)
                    {
                        heroes.Add(new Rogue(heroName));
                    }
                    else if (SearchHero(heroType) == Heroes.Warrior)
                    {
                        heroes.Add(new Warrior(heroName));
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                    i--;
                }
            }

            int powerOfBoss = int.Parse(Console.ReadLine());

            int totalPowerOfHeroes = 0;
            totalPowerOfHeroes = PrintHeroes(heroes, totalPowerOfHeroes);

            string result = totalPowerOfHeroes >= powerOfBoss ? "Victory!" : "Defeat...";
            Console.WriteLine(result);

        }

        private static int PrintHeroes(List<BaseHero> heroes, int totalPowerOfHeroes)
        {
            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
                totalPowerOfHeroes += hero.Power;
            }

            return totalPowerOfHeroes;
        }

        private static Heroes SearchHero(string heroType)
        {
            Heroes hero;

            if (!Enum.TryParse<Heroes>(heroType, out hero))
            {
                throw new ArgumentException("Invalid hero!");
            }
            return hero;
        }
    }
}
