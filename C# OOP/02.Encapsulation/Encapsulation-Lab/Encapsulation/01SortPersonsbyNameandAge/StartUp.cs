namespace PersonsInfo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        static void Main(string[] args)
        {
            var count = int.Parse(Console.ReadLine());
            var personData = new List<Person>();

            for (int i = 0; i < count; i++)
            {
                var arguments = Console.ReadLine().Split();
                var person = new Person(arguments[0], arguments[1], int.Parse(arguments[2]));
                personData.Add(person);
            }

            personData.OrderBy(p => p.FirstName)
                   .ThenBy(p => p.Age)
                   .ToList()
                   .ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}