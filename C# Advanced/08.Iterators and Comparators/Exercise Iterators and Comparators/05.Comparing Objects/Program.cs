using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.ComparingObjects
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;

            List<Person> people = new List<Person>();
            while ((input = Console.ReadLine()) != "END")
            {
                string[] dataPerson = input
                          .Split(" ")
                          .ToArray();

                people.Add(new Person(dataPerson[0], int.Parse(dataPerson[1]), dataPerson[2]));
            }
            int indexToCompare = int.Parse(Console.ReadLine());

            Person comparePerson = people[indexToCompare - 1];

            int matches = 1;

            foreach (var person in people)
            {
                if (person.CompareTo(comparePerson) == 0 && !person.Equals(comparePerson))
                {
                    matches++;
                }
            }
            if (matches > 1)
            {

                Console.WriteLine($"{matches} {people.Count - matches} {people.Count}");
                return;
            }
            Console.WriteLine("No matches");


        }
    }
}
