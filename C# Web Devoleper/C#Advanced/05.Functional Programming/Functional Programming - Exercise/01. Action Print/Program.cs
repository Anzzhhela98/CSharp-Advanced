using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = x => Console.WriteLine($"{string.Join("/n", x)}");

            Console.ReadLine()
                        .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                        .ToList()
                        .ForEach(print);
        }
    }
}
