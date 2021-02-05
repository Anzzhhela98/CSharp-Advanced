using System;
using System.Collections.Generic;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {

            var count = int.Parse(Console.ReadLine());
            var persons = new List<Person>();

            for (int i = 0; i < count; i++)
            {
                var arguments = Console.ReadLine().Split();
                try
                {
                    var personData = new Person(arguments[0], arguments[1], int.Parse(arguments[2]), decimal.Parse(arguments[3]));
                    persons.Add(personData);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            Team team = new Team("SoftUni");

            foreach (var person in persons)
            {
                team.AddPlayer(person);
            }
            Console.WriteLine(team);
        }
    }
}
