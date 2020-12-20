using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int amountOfMeals = int.Parse(Console.ReadLine());

            int[] orders = Console
                          .ReadLine()
                          .Split(" ")
                          .Select(int.Parse)
                          .ToArray();
            var servedОrders = new Queue<int>(orders);

            Console.WriteLine(orders.Max());
         
            while (servedОrders.Any())
            {
                if (servedОrders.Peek() <= amountOfMeals)
                {
                    amountOfMeals -= servedОrders.Dequeue();
                    continue;
                }
                Console.WriteLine($"Orders left: {string.Join(' ', servedОrders)}");
               
                break;
            }

            if (servedОrders.Count==0)
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
