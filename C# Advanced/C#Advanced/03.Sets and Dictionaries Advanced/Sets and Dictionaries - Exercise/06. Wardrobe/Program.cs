using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console
                          .ReadLine()
                          .Split(" -> ")
                          .ToArray();
                string color = input[0];

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());

                }

                string[] clothes = input[1]
                                       .Split(",");

                foreach (var item in clothes)
                {
                    if (!wardrobe[color].ContainsKey(item))
                    {
                        wardrobe[color][item] = 0;
                    }
                    wardrobe[color][item]++;
                }
            }
            string[] checkItem = Console
                              .ReadLine()
                              .Split(" ")
                              .ToArray();
            string colorCheck = checkItem[0];
            string itemCheck = checkItem[1];

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes: ");

                foreach (var item in color.Value)
                {
                    string found = string.Empty;

                    if (color.Key == colorCheck && item.Key == itemCheck)
                    {
                        found = " (found!)";
                    }

                    Console.WriteLine($"* {item.Key} - {item.Value}{found}");
                }
            }
        }
    }
}
