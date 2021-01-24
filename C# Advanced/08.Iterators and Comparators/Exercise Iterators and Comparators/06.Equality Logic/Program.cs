using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.EqualityLogic
{
    public class Program
    {
        static void Main(string[] args)
        {
            SortedSet<Person> sortedSet = new SortedSet<Person>();

            HashSet<Person> hashSet = new HashSet<Person>();
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {

                List<string> personData = Console
                            .ReadLine()
                            .Split(" ")
                            .ToList();

                Person person = new Person(personData[0], int.Parse(personData[1]));
                hashSet.Add(person);
                sortedSet.Add(person);
            }
            Console.WriteLine(hashSet.Count);
            Console.WriteLine(sortedSet.Count);
        }
    }
}
