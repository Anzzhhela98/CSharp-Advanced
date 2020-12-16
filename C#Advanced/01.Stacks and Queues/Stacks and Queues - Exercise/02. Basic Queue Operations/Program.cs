using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console
                          .ReadLine()
                          .Split(" ")
                          .Select(int.Parse)
                          .ToArray();

            int popNum = arr[1];
            int findNum = arr[2];

            int[] numbers = Console
                             .ReadLine()
                             .Split(" ")
                             .Select(int.Parse)
                             .ToArray();

            var elements = new Queue<int>(numbers);


            for (int i = 0; i < popNum; i++)
            {
                elements.Dequeue();
            }

            if (elements.Contains(findNum))
            {
                Console.WriteLine("true");
            }

            else
            {

                Console.WriteLine(elements.Count > 0 ? elements.Min() : 0);
            }

        }
    }
}
