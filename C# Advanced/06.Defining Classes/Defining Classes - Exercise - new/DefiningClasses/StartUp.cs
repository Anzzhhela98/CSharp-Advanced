using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split(" ");

                string name = data[0];
                int age = int.Parse(data[1]);

                people.Add(new Person(name, age));


            }
            foreach (Person person in people
                .Where(x=>x.Age>30).OrderBy(n=>n.Name))
            {
                Console.WriteLine(person);
            }
        }
    }
}
