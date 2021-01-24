using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Froggy
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console
                         .ReadLine()
                         .Split(", ")
                         .Select(int.Parse)
                         .ToList();

            Lake stonesNumber = new Lake(numbers);

            Console.WriteLine(string.Join(", ", stonesNumber));
        }
    }
}
