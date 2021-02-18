using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            const int Bread = 25;
            const int Cake = 50;
            const int Pastry = 75;
            const int FruitPie = 100;
            Dictionary<string, int> bakedFoods = new Dictionary<string, int>
            { {"Bread",0},
              {"Cake",0},
              {"Fruit Pie",0},
              {"Pastry",0},
            };

            Queue<int> liquids =
                new Queue<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());

            Stack<int> ingredients =
                new Stack<int>(Console.ReadLine().Split(" ").Select(int.Parse).ToArray());


            while (liquids.Any() && ingredients.Any())
            {
                int liquid = liquids.Dequeue();
                int ingredient = ingredients.Pop();
                int sum = liquid + ingredient;

                switch (sum)
                {
                    case Bread:
                        bakedFoods["Bread"]++;
                        break;
                    case Cake:
                        bakedFoods["Cake"]++;
                        break;
                    case Pastry:
                        bakedFoods["Pastry"]++;
                        break;
                    case FruitPie:
                        bakedFoods["Fruit Pie"]++;
                        break;
                    default:
                        ingredients.Push(ingredient + 3);
                        break;
                }
            }
            if (bakedFoods.All(x => x.Value >= 1))
            {
                Console.WriteLine($"Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }
            if (liquids.Any())
            {
                Console.WriteLine($"Liquids left: {string.Join(", ", liquids)}");
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }
            if (ingredients.Any())
            {
                Console.WriteLine($"Ingredients left: {string.Join(", ", ingredients)}");
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }

            foreach (var food in bakedFoods)
            {
                Console.WriteLine($"{food.Key}: {food.Value}");
            }
        }
    }
}
