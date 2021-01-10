using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            string[] names = Console
                          .ReadLine()
                          .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                          .ToArray();

            Func<string[], int, string[]> namesLenght = (name, num) =>
                {
                    foreach (var person in name)
                    {
                        if (person.Length <= num)
                        {
                            Console.WriteLine(person);
                        }

                    }
                    return name;
                };

            namesLenght(names, num);
        }
    }
}
