using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sequence = Console
                          .ReadLine()
                          .Split(" ")
                          .Select(int.Parse)
                          .ToArray();
            int capacity = int.Parse(Console.ReadLine());
            int currCapacity = capacity;
            ; int value = 0;

            var stack = new Stack<int>(sequence);
            while (stack.Any())
            {
                if (currCapacity - stack.Peek() >= 0)
                {
                    currCapacity -= stack.Peek();
                    stack.Pop();
                    if (stack.Count == 0 && currCapacity != capacity)
                    {
                        value++;
                    }
                    continue;
                }
                value++;
                currCapacity = capacity;
            }
            Console.WriteLine($"{value}");
        }
    }
}
