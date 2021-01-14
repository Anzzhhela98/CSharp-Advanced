using System;
using System.Collections.Generic;

namespace _04._Even_Times
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            var inputNumber = new Dictionary<int, List<int>>();

            for (int i = 0; i < count; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (!inputNumber.ContainsKey(number))
                {
                    inputNumber.Add(number, new List<int>());
                }
                inputNumber[number].Add(number);
            }
            foreach (var num in inputNumber)
            {
                if (num.Value.Count%2==0)
                {
                    Console.WriteLine(num.Key);
                    return;
                }
            }
        }
    }
}
