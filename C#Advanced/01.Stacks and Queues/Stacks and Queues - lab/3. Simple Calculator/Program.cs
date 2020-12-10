using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Simple_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Console
                          .ReadLine()
                          .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                          .Reverse()
                          .ToArray();
            var stack = new Stack<string>(arr);

            while (stack.Count > 1)
            {
                for (int i = 0; i < stack.Count; i += 3)
                {
                    int firstNum = int.Parse(stack.Pop());
                    string rezult = stack.Pop();
                    int seconNum = int.Parse(stack.Pop());
                    if (rezult == "+")
                    {
                        stack.Push((firstNum + seconNum).ToString());
                        continue;
                    }

                    stack.Push((firstNum - seconNum).ToString());

                }
            }
            Console.WriteLine(stack.Pop());
        }
    }
}
