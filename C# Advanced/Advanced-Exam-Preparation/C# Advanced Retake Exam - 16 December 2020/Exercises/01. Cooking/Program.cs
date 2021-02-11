using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            var prodcuts = new Dictionary<string, int>()
            {
                ["Pastry"] = 0,
                ["Bread"] = 0,
                ["Fruit Pie"] = 0,
                ["Cake"] = 0,

            };

            Queue<double> liquids;
            Stack<double> ingredians;

            ReadInput(out liquids, out ingredians);

            while (liquids.Count != 0 && ingredians.Count != 0)
            {
                double liquid = liquids.Dequeue();
                double ingredian = ingredians.Pop();
                double amount = liquid + ingredian;

                switch (amount)
                {
                    case 25:
                        prodcuts["Bread"] += 1;
                        break;
                    case 50:
                        prodcuts["Cake"] += 1;
                        break;
                    case 75:
                        prodcuts["Fruit Pie"] += 1;
                        break;
                    case 100:
                        prodcuts["Pastry"] += 1;
                        break;
                    default:
                        ingredians.Push(ingredian + 3);
                        break;
                }
            }

            bool isEvrithingCooked = prodcuts.All(x => x.Value > 0);

            Print(prodcuts, liquids, ingredians, isEvrithingCooked);
        }

        private static void ReadInput(out Queue<double> liquids, out Stack<double> ingredians)
        {
            liquids = new Queue<double>
                (Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse));
            ingredians = new Stack<double>
(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse));
        }

        private static void Print(Dictionary<string, int> prodcuts, Queue<double> liquids, Stack<double> ingredians, bool isEvrithingCooked)
        {
            Console.WriteLine(isEvrithingCooked == true ? "Wohoo! You succeeded in cooking all the food!" : "Ugh, what a pity! You didn't have enough materials to cook everything.");

            Console.WriteLine(liquids.Count == 0 ? "Liquids left: none" : $"Liquids left: {string.Join(", ", liquids)}");

            Console.WriteLine(ingredians.Count == 0 ? "Ingredients left: none" : $"Ingredients left: {string.Join(", ", ingredians)}");

            foreach (var product in prodcuts.OrderBy(p => p.Key))
            {
                Console.WriteLine($"{product.Key}: {product.Value}");
            }
        }
    }
}
