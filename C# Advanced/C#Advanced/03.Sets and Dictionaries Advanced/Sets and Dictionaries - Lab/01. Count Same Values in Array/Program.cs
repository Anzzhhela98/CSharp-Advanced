using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] values = Console
                          .ReadLine()
                          .Split(" ")
                          .Select(double.Parse)
                          .ToArray();

            Dictionary<double, int> dictionaryOfNums =
                new Dictionary<double, int>();
            foreach (var value in values)
            {
                if (!dictionaryOfNums.ContainsKey(value))
                {
                    dictionaryOfNums.Add(value, 0);
                }
                dictionaryOfNums[value]++;
            }
            foreach (var kvp in dictionaryOfNums)
            {

                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}
