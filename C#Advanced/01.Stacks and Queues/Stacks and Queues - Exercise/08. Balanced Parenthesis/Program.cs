using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> stack = new Stack<char>();
            foreach (var symbol in input)
            {
                if (stack.Any())
                {
                    char symbolInList = stack.Peek();
                    if (symbolInList == '(' && symbol == ')')
                    {
                        stack.Pop();
                        continue;
                    }
                    else if (symbolInList == '{' && symbol == '}')
                    {
                        stack.Pop();
                        continue;
                    }
                    else if (symbolInList == '[' && symbol == ']')
                    {
                        stack.Pop();
                        continue;
                    }
                }
                stack.Push(symbol);
            }
            if (stack.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}