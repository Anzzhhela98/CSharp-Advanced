using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    class Family
    {
        public Family()
        {
            Members = new List<Person>();
        }

        public List<Person> Members { get; set; }
        public IEnumerable<object> Where { get; internal set; }

        public void AddMember(Person data)
        {
            Members.Add(data);
        }

        public List<Person> GetOldesMember()
        {
            return this.Members
                .Where(x => x.Age > 30)
                .OrderBy(x => x.Name).ToList();
        }
    }
}
