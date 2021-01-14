using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            var charsDictionary = new Dictionary<char, int>();

            foreach (var letter in input)
            {
                if (!charsDictionary.ContainsKey(letter))
                {
                    charsDictionary.Add(letter, 0);
                }
                charsDictionary[letter]++;
            }
            foreach (var letter in charsDictionary.OrderBy(x=>x.Key))
            {
                Console.WriteLine($"{letter.Key}: {letter.Value} time/s ");
            }
        }
    }
}
