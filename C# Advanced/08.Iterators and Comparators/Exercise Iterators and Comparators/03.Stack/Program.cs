using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            CustomStack<int> stack = new CustomStack<int>();

            while ((input = Console.ReadLine()) != "END")
            {
                var data = input
                          .Split(" ",
                          StringSplitOptions.RemoveEmptyEntries)
                          .ToList();

                if (data[0] == "Push")
                {
                    int[] element = data.Skip(1)
                        .Select(i => i.Split(',').First())
                        .Select(int.Parse)
                        .ToArray();

                    stack.Push(element);

                }
                else
                {
                    try
                    {
                        stack.Pop();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }

            foreach (int number in stack)
            {
                Console.WriteLine(number);
            }

            foreach (int number in stack)
            {
                Console.WriteLine(number);
            }

        }
    }
}
