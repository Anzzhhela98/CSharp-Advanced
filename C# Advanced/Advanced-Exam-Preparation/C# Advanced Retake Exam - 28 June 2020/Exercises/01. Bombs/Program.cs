using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            const int DaturaBombs = 40;
            const int CherryBombs = 60;
            const int SmokeBombs = 120;

            var bombEffects =
                  new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            var bombCasing =
                new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            var bombPouch = new Dictionary<string, int>
            {
                {"Cherry Bombs", 0},
                {"Datura Bombs",0},
                {"Smoke Decoy Bombs",0}
            };
            bool isWrongSum = true;
            bool isBombPouchFull = false;

            while (bombCasing.Count > 0 && bombEffects.Count > 0 && isBombPouchFull == false)
            {
                isWrongSum = true;
                int effect = bombEffects.Peek();
                int casing = bombCasing.Pop();

                int sum = effect + casing;

                if (sum == DaturaBombs)
                {
                    bombEffects.Dequeue();
                    bombPouch["Datura Bombs"] += 1;
                    isWrongSum = false;
                }
                else if (sum == CherryBombs)
                {
                    bombEffects.Dequeue();
                    bombPouch["Cherry Bombs"] += 1;
                    isWrongSum = false;
                }
                else if (sum == SmokeBombs)
                {
                    bombEffects.Dequeue();
                    bombPouch["Smoke Decoy Bombs"] += 1;
                    isWrongSum = false;
                }
                if (isWrongSum)
                {
                    bombCasing.Push(casing - 5);
                }

                isBombPouchFull = bombPouch.All(x => x.Value >= 3);
            }
            ;
            if (isBombPouchFull)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }
            if (bombEffects.Count > 0)
            {
                Console.WriteLine($"Bomb Effects: {string.Join(", ", bombEffects)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            if (bombCasing.Count > 0)
            {
                Console.WriteLine($"Bomb Casings: {string.Join(", ", bombCasing)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            foreach (var bomb in bombPouch)
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }
        }
    }
}
