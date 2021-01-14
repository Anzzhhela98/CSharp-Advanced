using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Family family = new Family();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] info = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = info[0];
                int age = int.Parse(info[1]);

                Person person = new Person(name, age);
                
                family.AddMember(person);
            }
            Person oldestMember = family.GetOldestMember();

            List<Person> olderThan30 = family.GetOlderThan30();

            foreach (Person item in olderThan30.OrderBy(n => n.Name))
            {
                Console.WriteLine($"{item.Name} - " +
                    $"{item.Age}");
            }
        }
    }
}
