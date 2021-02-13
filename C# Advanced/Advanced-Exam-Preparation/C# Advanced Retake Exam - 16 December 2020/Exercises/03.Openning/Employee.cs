namespace BakeryOpenning
{
    public class Employee
    {
        private string name;

        private int age;

        private string country;

        public Employee(string name, int age, string country)
        {
            this.Name = name;
            this.Age = age;
            this.Country = country;
        }

        public string Name
        {
            get => this.name;
            set { name = value; }
        }
        public int Age
        {
            get => this.age;
            set { age = value; }
        }
        public string Country
        {
            get => this.country;
            set { country = value; }
        }

        public override string ToString()
        {
            return $"Employee: {this.name}, {this.age} ({this.country})";
        }
    }
}
