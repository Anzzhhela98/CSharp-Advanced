using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            const int needeClaimedItems = 100;

            Queue<int> firtsBoxes =
               new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());

            Stack<int> secondBoxes =
                new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());

            int claimedItems = 0;
            while (firtsBoxes.Any() && secondBoxes.Any())
            {
                int firstBox = firtsBoxes.Peek();
                int secondBox = secondBoxes.Pop();

                int sum = firstBox + secondBox;

                if (sum % 2 == 0)
                {
                    firtsBoxes.Dequeue();
                    claimedItems += sum;
                }
                else
                {
                    firtsBoxes.Enqueue(secondBox);
                }
            }

            if (!firtsBoxes.Any())
            {
                Console.WriteLine("First lootbox is empty");
            }
            if (!secondBoxes.Any())
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (claimedItems >= needeClaimedItems)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems}");
            }
        }
    }
}
