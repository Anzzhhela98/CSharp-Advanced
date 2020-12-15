using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Matching_Brackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();

            var stack = new Stack<int>();
            for (int i = 0; i < expression.Length; i++)
            {
                switch (expression[i])
                {
                    case '(':
                        stack.Push(i);
                        break;
                    case ')':
                        int indexOfOpeningBrackets = stack.Pop();
                        var rezult = expression.Substring(indexOfOpeningBrackets,
                            i - indexOfOpeningBrackets + 1);
                        Console.WriteLine(rezult);
                        break;
                }
            }
        }
    }
}
