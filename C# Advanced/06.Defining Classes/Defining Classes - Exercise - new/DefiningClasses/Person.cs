namespace DefiningClasses
{
    public class Person
    {
        private int age;

        private string name;

        public Person()
        {
            Name = "No Name";
            Age = 1;
        }
        public Person(int age) :this()
        {
            this.Age = age;
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public override string ToString()
        {
            return $"{this.Name} - {this.Age}";
        }
    }
}
