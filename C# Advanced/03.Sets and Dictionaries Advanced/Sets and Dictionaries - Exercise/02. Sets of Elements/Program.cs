using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] lenghts = Console
                          .ReadLine()
                          .Split()
                          .Select(int.Parse)
                          .ToArray();

            HashSet<int> first = new HashSet<int>();
            HashSet<int> second = new HashSet<int>();


            for (int k = 0; k < lenghts[0]; k++)
            {
                int num = int.Parse(Console.ReadLine());

                first.Add(num);
            }

            for (int l = 0; l < lenghts[1]; l++)
            {
                int num = int.Parse(Console.ReadLine());

                second.Add(num);
            }

            foreach (var num in first)
            {
                if (second.Contains(num))
                {
                    Console.Write($"{num} ");
                }
            }
        }
    }
}
