using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            const int Datura = 40;
            const int Cherry = 60;
            const int Smoke = 120;

            Dictionary<string, int> pouchBomb = new Dictionary<string, int>
            {
              {"Cherry Bombs",0},
              {"Datura Bombs",0},
              {"Smoke Decoy Bombs",0},
            };

            Queue<int> bombs =
               new Queue<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());

            Stack<int> casings =
                new Stack<int>(Console.ReadLine().Split(", ").Select(int.Parse).ToArray());
            bool isBombPouchFull = false;

            while (bombs.Any() && casings.Any() && isBombPouchFull == false)
            {
                int bomb = bombs.Peek();
                int casing = casings.Pop();
                int sum = bomb + casing;

                switch (sum)
                {
                    case Datura:
                        bombs.Dequeue();
                        pouchBomb["Datura Bombs"]++;
                        break;
                    case Cherry:
                        bombs.Dequeue();
                        pouchBomb["Cherry Bombs"]++;
                        break;
                    case Smoke:
                        bombs.Dequeue();
                        pouchBomb["Smoke Decoy Bombs"]++;
                        break;
                    default:
                        casings.Push(casing - 5);
                        break;
                }

                isBombPouchFull = pouchBomb.All(x => x.Value >= 3);
            }
            if (!isBombPouchFull)
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }
            else
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            if (bombs.Any())
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombs)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            if (casings.Any())
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", casings)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            foreach (var bomb in pouchBomb)
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");

            }
        }
    }
}
