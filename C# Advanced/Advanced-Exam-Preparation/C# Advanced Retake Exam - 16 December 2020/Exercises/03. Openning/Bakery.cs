using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BakeryOpenning
{
    class Bakery
    {
        private List<Employee> repositoryOfEmploye;

        public Bakery(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.repositoryOfEmploye = new List<Employee>();
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public void Add(Employee employee)
        {
            if (Capacity > 0)
            {
                this.repositoryOfEmploye.Add(employee);
                this.Capacity--;
            }
        }
        public bool Remove(string name)
        {
            if (repositoryOfEmploye.Any(x => x.Name == name))
            {
                repositoryOfEmploye.RemoveAll(x => x.Name == name);
                return true;
            }
            return false;
        }
        public Employee GetOldestEmployee()
        {
            return repositoryOfEmploye.OrderByDescending(x => x.Age).First();
        }
        public Employee GetEmployee(string name)
        {
            return repositoryOfEmploye.First(x => x.Name == name);
        }

        public int Count => this.repositoryOfEmploye.Count;

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Employees working at Bakery {this.Name}:");

            foreach (var employee in repositoryOfEmploye)
            {
                sb.AppendLine(employee.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}