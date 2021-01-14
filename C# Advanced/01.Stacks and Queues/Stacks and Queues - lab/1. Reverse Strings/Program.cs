using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
               .Split(" ")
               .ToList();
            Stack<string> stack = new Stack<string>();
            foreach (var item in input)
            {
                string tempWord = string.Empty;
                for (int i = item.Length - 1; i >= 0; i--)
                {
                    tempWord += item[i];
                }
                stack.Push(tempWord);

            }
            while (stack.Count > 0)
            {
                Console.Write($"{stack.Pop()} ");

            }
        }
    }
}
