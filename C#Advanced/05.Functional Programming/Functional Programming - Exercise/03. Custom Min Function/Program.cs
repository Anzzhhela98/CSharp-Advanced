using System;
using System.Linq;

namespace _03._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> smallestNum = number =>
            {
                int minValue = int.MaxValue;

                foreach (var num in number)
                {
                    if (num < minValue)
                    {
                        minValue = num;
                    }
                }
                return minValue;
            };

            int[] numbers = Console
                            .ReadLine()
                            .Split()
                            .Select(int.Parse)
                            .ToArray();

            Console.WriteLine(smallestNum(numbers));
                           
        }
    }
}
