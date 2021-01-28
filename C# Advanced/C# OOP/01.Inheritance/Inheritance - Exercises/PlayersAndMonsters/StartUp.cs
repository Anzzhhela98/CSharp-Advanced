using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Hero hero  =  new Hero("Blade", 2);
            Elf elf = new Elf("Bandy", 13);

            Console.WriteLine(elf);
            Console.WriteLine(hero.ToString());
        }
    }
}