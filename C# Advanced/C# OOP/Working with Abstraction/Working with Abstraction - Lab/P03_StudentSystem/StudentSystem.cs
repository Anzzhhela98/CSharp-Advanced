using System;
using System.Collections.Generic;

namespace P03_StudentSystem
{
    public class StudentSystem
    {
        public StudentSystem()
        {
            this.Repo = new Dictionary<string, Student>();
        }

        private Dictionary<string, Student> Repo { get; set; }

        public void ParseCommand()
        {
            string[] args = Console.ReadLine().Split();

            if (args[0] == "Create")
            {
                var name = args[1];
                var age = int.Parse(args[2]);
                var grade = double.Parse(args[3]);

                Student student = new Student(name, age, grade);
                Create(student);
            }
            else if (args[0] == "Show")
            {
                var studentName = args[1];
                Show(studentName);
            }
            else if (args[0] == "Exit")
            {
                Exit();
            }
        }
        public void Create(Student student)
        {
            if (!this.Repo.ContainsKey(student.Name))
            {
                this.Repo.Add(student.Name, student);
            }
        }
        public void Show(string studentName)
        {
            if (this.Repo.ContainsKey(studentName))
            {
                var student = this.Repo[studentName];
                Console.WriteLine(student.ToString());
            }
        }
        public void Exit()
        {
            Environment.Exit(0);
        }
    }
}
