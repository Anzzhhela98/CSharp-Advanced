using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    public class Bakery
    {
        private string name;

        private int capacity;

        public Bakery(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.Employees = new List<Employee>();
        }
        public string Name
        {
            get => this.name;
            set { name = value; }
        }
        public int Capacity
        {
            get => this.capacity;
            set { capacity = value; }
        }
        public List<Employee> Employees { get; set; }

        public void Add(Employee employee)
        {
            if (capacity > 0)
            {
                this.Employees.Add(employee);
                this.capacity--;
            }
        }
        public bool Remove(string name)
        {
            if (Employees.Any(x => x.Name == name))
            {
                Employees.RemoveAll(x => x.Name == name);
                return true;
            }
            return false;
        }
        public Employee GetOldestEmployee()
        {
            return Employees.OrderByDescending(x => x.Age).First();
        }
        public Employee GetEmployee(string name)
        {
            return Employees.First(x => x.Name == name);
        }

        public int Count => this.Employees.Count;

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Employees working at Bakery {this.Name}:");

            foreach (var employee in Employees)
            {
                sb.AppendLine(employee.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
