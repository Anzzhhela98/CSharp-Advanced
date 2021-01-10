using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console
                          .ReadLine()
                          .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                          .Select(int.Parse)
                          .ToArray();

            string command = string.Empty;

            Action<int[]> print = num => Console.WriteLine(string.Join(" ", numbers));

            Func<int[], string, int[]> manipulator = (numbers, command) =>
             {

                 switch (command)
                 {
                     case "add":
                         return numbers.Select(x => x + 1).ToArray();

                     case "multiply":
                         return numbers.Select(x => x * 2).ToArray();

                     case "subtract":
                         return numbers.Select(x => x - 1).ToArray();

                 }
                 return numbers.Select(x => x).ToArray();

             };

            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "print")
                {
                    print(numbers);
                    continue;
                }

                numbers = manipulator(numbers, command);
            }
        }
    }
}
