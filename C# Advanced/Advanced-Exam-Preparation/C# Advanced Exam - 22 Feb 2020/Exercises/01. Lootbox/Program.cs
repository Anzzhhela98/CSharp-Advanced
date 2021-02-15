using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Lootbox
{
    class Program
    {
        static void Main(string[] args)
        {
            const int NEEDED_CLAIMD_ITEMS = 100;

            var firstBox = new Queue<int>
                (Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            var secondBox = new Stack<int>
                (Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            int claimedItems = 0;

            while (firstBox.Count > 0 && secondBox.Count > 0)
            {
                int firtsItem = firstBox.Peek();
                int secondItem = secondBox.Pop();

                int sum = firtsItem + secondItem;

                if (sum % 2 == 0)
                {
                    claimedItems += sum;
                    firstBox.Dequeue();
                }
                else
                {
                    firstBox.Enqueue(secondItem);
                }
            }
            if (firstBox.Count==0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }
            if (claimedItems>=NEEDED_CLAIMD_ITEMS)
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
