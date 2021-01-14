using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(" ");
            string command = string.Empty;

            Stack<int> sumStack = new Stack<int>();
            for (int i = 0; i < numbers.Length; i++)
            {
                sumStack.Push(int.Parse(numbers[i]));
            }
            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                string[] splitted = command
                          .Split()
                          .ToArray();
                int firstNum = int.Parse(splitted[1]);
                if (splitted[0].ToLower() == "add")
                {
                    int secondNum = int.Parse(splitted[2]);
                    sumStack.Push(firstNum);
                    sumStack.Push(secondNum);

                }
                else if (splitted[0].ToLower() == "remove")
                {
                    if (sumStack.Count >= firstNum)
                    {
                        for (int i = 0; i < firstNum; i++)
                        {
                            sumStack.Pop();
                        }
                    }
                }
            }
            Console.WriteLine($"Sum: {sumStack.Sum()}");
        }
    }
}
