using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numer = Console
                          .ReadLine()
                          .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                          .Select(int.Parse)
                          .ToArray();
            string evenOrOdd = Console.ReadLine();

            Predicate<int> checEven = num => num % 2 == 0;
            Predicate<int> checOdd = num => num % 2 != 0;

            List<int> num = new List<int>();
            for (int i = numer[0]; i <= numer[1]; i++)
            {
                if (evenOrOdd == "even" && checEven(i))
                {
                    num.Add(i);
                }
                else if (evenOrOdd == "odd" && checOdd(i))
                {
                    num.Add(i);
                }
            }
            Console.WriteLine(string.Join(" ", num));
        }
    }
}
