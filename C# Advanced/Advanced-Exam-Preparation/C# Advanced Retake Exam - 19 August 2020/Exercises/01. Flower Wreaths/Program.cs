using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Flower_Wreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MIN_VALUE_OF_FLOWERS = 0;
            const int MAX_VALUE = 15;

            int countOfWreaths = 0;
            int leftValueOfFlowers = 0;

            var lilies = new Stack<int>
                  (Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            var roses = new Queue<int>
              (Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            while (lilies.Count > MIN_VALUE_OF_FLOWERS && roses.Count > MIN_VALUE_OF_FLOWERS)
            {
                int currentLily = lilies.Pop();
                int currentRose = roses.Peek();

                int sum = currentLily + currentRose;

                if (sum == MAX_VALUE)
                {
                    countOfWreaths++;

                    roses.Dequeue();
                }
                else if (sum > MAX_VALUE)
                {
                    lilies.Push(currentLily - 2);
                }
                else
                {
                    leftValueOfFlowers += currentRose + currentLily;
                    roses.Dequeue();
                }
            }

            countOfWreaths += leftValueOfFlowers / MAX_VALUE;

            if (countOfWreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {countOfWreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - countOfWreaths} wreaths more!");
            }
        }
    }
}
