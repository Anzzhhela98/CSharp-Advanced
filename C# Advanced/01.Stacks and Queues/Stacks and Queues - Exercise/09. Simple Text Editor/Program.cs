using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var sb = new StringBuilder();
            var stack = new Stack<string>();
            stack.Push(sb.ToString());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                int command = int.Parse(input[0]);

                switch (command)
                {
                    case 1:
                        sb.Append(input[1]);
                        stack.Push(sb.ToString());
                        break;
                    case 2:
                        int number = int.Parse(input[1]);
                        sb.Remove(sb.Length - number, number);
                        stack.Push(sb.ToString());
                        break;
                    case 3:
                        int index = int.Parse(input[1]);
                        Console.WriteLine(sb[index - 1]);
                        break;
                    case 4:
                        stack.Pop();
                        sb = new StringBuilder();
                        sb.Append(stack.Peek());
                        break;
                }
            }
        }
    }
}
