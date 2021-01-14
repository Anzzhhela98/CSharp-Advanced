using System;
using System.Linq;

namespace _01._Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = name => Console.WriteLine($"Sir {name}");

            Console.ReadLine()
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .ToList()
                        .ForEach(print);
        }
    }
}
