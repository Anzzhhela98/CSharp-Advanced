using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private int capacity;
        private List<Student> students;
        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.students = new List<Student>();
        }

        public List<Student> Students
        {
            get => this.students;
            set { this.students = value; }
        }
        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        public int Count => this.Students.Count;

        public string RegisterStudent(Student student)
        {
            if (this.Capacity > this.students.Count)
            {
                this.Students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            return $"No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            Student currentStudent = students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            if (students.Contains(currentStudent))
            {
                Students.Remove(currentStudent);
                return $"Dismissed student {firstName} {lastName}";
            }

            return "Student not found";
        }
        public string GetSubjectInfo(string subject)
        {
            StringBuilder sb = new StringBuilder();

            if (Students.Any(s => s.Subject == subject))
            {
                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");

                foreach (var student in Students)
                {
                    if (student.Subject == subject)
                    {
                        sb.AppendLine($"{student.FirstName} {student.LastName}");

                    }
                }
                return sb.ToString().TrimEnd();
            }
            return "No students enrolled for the subject";
        }

        public int GetStudentsCount => this.Count;

        public Student GetStudent(string firstName, string lastName)
        {
            return Students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
        }
    }
}
