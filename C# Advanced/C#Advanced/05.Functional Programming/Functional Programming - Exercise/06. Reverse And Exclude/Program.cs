using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] number = Console
                                .ReadLine()
                                .Split()
                                .Select(int.Parse)
                                .Reverse()
                                .ToArray();


            int num = int.Parse(Console.ReadLine());

            List<int> listOfNumber = new List<int>();
         
            Predicate<int> remove = n => n % num == 0;
           
            foreach (var n in number)
            {
                if (!remove(n))
                {
                    Console.Write($"{n} ");
                }
            }
        }
    }
}
