using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, List<string>>> countinents =
                new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console
                          .ReadLine()
                          .Split(" ")
                          .ToArray();
                string countinent = input[0];
                string country = input[1];
                string city = input[2];

                if (!countinents.ContainsKey(countinent))
                {
                    countinents.Add(countinent, new Dictionary<string, List<string>>());
                }

                if (!countinents[countinent].ContainsKey(country))
                {
                    countinents[countinent].Add(country, new List<string>());
                }
                    countinents[countinent][country].Add(city);

            }
            foreach (var continent in countinents)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"{country.Key} -> {string.Join(", ",country.Value)}");
                }
            }
        }
    }
}
