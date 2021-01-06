using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            //{contest}:{password for contest}"
            string input = string.Empty;

            var data = new Dictionary<string, string>();

            var students = new Dictionary<string, Dictionary<string, int>>();

            while ((input = Console.ReadLine()) != "end of contests")
            {

                string[] info = input
                          .Split(":")
                          .ToArray();

                if (!data.ContainsKey(info[0]))
                {
                    data[info[0]] = info[1];
                }
            }

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                string[] info = input
                         .Split("=>")
                         .ToArray();

                string contest = info[0];
                string pass = info[1];
                string user = info[2];
                int points = int.Parse(info[3]);

                if (data.ContainsKey(contest))
                {
                    if (data[contest] == pass)
                    {
                        if (!students.ContainsKey(user))
                        {
                            students.Add(user, new Dictionary<string, int>());
                            students[user].Add(contest, points);
                        }
                        else
                        {
                            if (!students[user].ContainsKey(contest))
                            {
                                students[user].Add(contest, points);
                                
                            }
                            else
                            {
                                if (students[user][contest] < points)
                                {
                                    students[user][contest] = points;
                                }
                            }
              
                        }
                    }
                }
            }
            var topCandidate = students.OrderByDescending(x => x.Value.Sum(x => x.Value))
                .FirstOrDefault();
            
                Console.WriteLine($"Best candidate is {topCandidate.Key} with total {topCandidate.Value.Sum(x=>x.Value)} points.");
            Console.WriteLine("Ranking:");
            foreach (var student in students.OrderBy(x=>x.Key))
            {
                Console.WriteLine(student.Key);
                foreach (var contes in student.Value.OrderByDescending(x=>x.Value))
                {
                    Console.WriteLine($"#  {contes.Key} -> {contes.Value}");
                }
            }
        }
    }
}
