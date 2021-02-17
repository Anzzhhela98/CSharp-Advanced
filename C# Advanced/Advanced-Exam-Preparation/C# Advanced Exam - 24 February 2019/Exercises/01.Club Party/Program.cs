using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Club_Party
{
    class Program
    {
        static void Main(string[] args)
        {

            var capacity = int.Parse(Console.ReadLine());
            Stack<string> input = new Stack<string>(Console.ReadLine().Split(" "));

            Queue<string> halls = new Queue<string>();
            List<int> allGroups = new List<int>();

            int currentCapacity = 0;

            while (true)
            {
                string currentElement = input.Pop();
                bool isNumber = int.TryParse(currentElement, out int parsedNumber);

                if (!isNumber)
                {
                    halls.Enqueue(currentElement);
                }
                else
                {
                    if (halls.Count == 0)
                    {
                        continue;
                    }

                    if (currentCapacity + parsedNumber > capacity)
                    {
                        Console.WriteLine($"{halls.Dequeue()} -> {string.Join(", ", allGroups)}");
                        allGroups.Clear();
                        currentCapacity = 0;
                    }
                    if (halls.Any())
                    {
                        allGroups.Add(parsedNumber);
                        currentCapacity += parsedNumber;
                    }
                }
            }
        }
    }
}
