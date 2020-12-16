using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console
                          .ReadLine()
                          .Split(" ")
                          .Select(int.Parse)
                          .ToArray();
            int count = 0;
            int pushNum = 0;
            int popNum = 0;
            int findNum = 0;
            for (int i = 1; i <= 3; i++)
            {
                if (i == 1)
                {
                    pushNum = arr[count];

                }
                else if (i == 2)
                {
                    popNum = arr[count];

                }
                else
                {

                    findNum = arr[count];
                }
                count++;

            }
            int[] numbers = Console
                             .ReadLine()
                             .Split(" ")
                             .Select(int.Parse)
                             .ToArray();

            var elements = new Stack<int>();

            for (int i = 0; i < pushNum; i++)
            {
                elements.Push(numbers[i]);
            }
            for (int i = 0; i < popNum; i++)
            {
                elements.Pop();
            }

            if (elements.Contains(findNum))
            {
                Console.WriteLine("true");
            }
            else if (elements.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                int minNum = int.MaxValue;
                int curMinNum = 0;
                while (elements.Any())
                {

                    curMinNum = elements.Pop();
                    if (minNum > curMinNum)
                    {
                        minNum = curMinNum;
                    }
                }
                Console.WriteLine(minNum);
            }

        }
    }
}
