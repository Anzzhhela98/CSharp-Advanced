using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int countStudents = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> studentsGrades =
                new Dictionary<string, List<decimal>>();

            for (int i = 0; i < countStudents; i++)
            {
                string[] input = Console
                            .ReadLine()
                            .Split(" ")
                            .ToArray();

                string name = input[0];
                decimal grade = decimal.Parse(input[1]);
                if (!studentsGrades.ContainsKey(name))
                {
                    studentsGrades.Add(name, new List<decimal>());

                }
                studentsGrades[name].Add(grade);
            }
            foreach (var stundent in studentsGrades)
            {
                Console.WriteLine
                    ($"{stundent.Key} -> {string.Join(" ", stundent.Value.Select(x => x.ToString("F2")))} (avg: {stundent.Value.Average():f2})");
            }
        }
    }
}
