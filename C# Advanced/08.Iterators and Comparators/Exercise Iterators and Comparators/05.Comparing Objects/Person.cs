using System;
namespace _05.ComparingObjects
{
    public class Person : IComparable<Person>
    {

        public string Name { get; set; }

        public int Age { get; set; }

        public string Town { get; set; }

        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }
        public int CompareTo(Person other)
        {
            if (this.Name.CompareTo(other.Name) != 0)
            {
                return this.Name.CompareTo(other.Name);
            }
            if (this.Age.CompareTo(other.Age) != 0)
            {
                this.Age.CompareTo(other.Age);
            }

            return this.Town.CompareTo(other.Town);

        }
    }
}
