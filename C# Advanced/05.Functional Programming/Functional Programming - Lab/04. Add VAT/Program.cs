using System;
using System.Linq;

namespace _04._Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<decimal, decimal> vatNumber = n => n * 1.2m;
            decimal[] numbers = Console
                           .ReadLine()
                           .Split(", ")
                           .Select(decimal.Parse)
                           .Select(vatNumber)
                           .ToArray();

            foreach (var number in numbers)
            {
                Console.WriteLine($"{number:f2}");
            }
        }
    }
}
