using System;
using System.Linq;

namespace _01._Sort_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console
                          .ReadLine()
                          .Split(", ")
                          .Select(ParseNum)
                          .Where(EvenNum)
                          .OrderBy(n => n)
                          .ToArray();

            Console.WriteLine(string.Join(", ", numbers));
        }

        static int ParseNum(string n)
        {
            return int.Parse(n);
        }
        static bool EvenNum(int n)
        {
            return n % 2 == 0;
        }
    }
}
