using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            var elements = new Stack<int>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int[] numbers = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse).ToArray();
                if (numbers[0] == 1)
                {
                    elements.Push(numbers[1]);
                }
                else if (numbers[0] == 2)
                {
                    elements.Pop();
                }

                else if (elements.Count==0)
                {
                    continue;
                    
                }
                else if (numbers[0] == 3)
                {
                    Console.WriteLine(elements.Max());
                }
                else if (numbers[0] == 4)
                {
                    Console.WriteLine(elements.Min());
                }
            }

            Console.WriteLine(string.Join(", ", elements));
        }
    }
}
