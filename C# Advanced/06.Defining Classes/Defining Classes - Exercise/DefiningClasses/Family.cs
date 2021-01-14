using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;

        public Family()
        {
            this.people = new List<Person>();
        }
        public void AddMember(Person person)
        {
            this.people.Add(person);
        }

        public Person GetOldestMember()
          => people.OrderByDescending(age => age.Age)
            .FirstOrDefault();
        public List<Person> GetOlderThan30()
        {
            return people.Where(x => x.Age > 30).ToList();
        }
    }
}
