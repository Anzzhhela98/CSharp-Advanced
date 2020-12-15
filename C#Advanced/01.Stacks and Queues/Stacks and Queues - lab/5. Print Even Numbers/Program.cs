using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Print_Even_Numbers
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
            var evenNumbers = new Queue<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 == 0)
                {
                    evenNumbers.Enqueue(arr[i]);
                    continue;
                }
            }
            Console.WriteLine(string.Join(", ", evenNumbers));
        }
    }
}
