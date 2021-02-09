using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _004.BorderControl.Core
{
    public class Engine
    {
        public void Run()
        {
            List<IIDValidatorable> residents = new List<IIDValidatorable>();
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] data = command
                               .Split(" ")
                               .ToArray();

                string name = data[0];

                if (data.Length == 3)
                {
                    int age = int.Parse(data[1]);
                    string ID = data[2];
                    IIDValidatorable citizen = new Ctizen(name, age, ID);
                    residents.Add(citizen);
                }
                else
                {
                    string ID = data[1];
                    IIDValidatorable robbot = new Robot(name, ID);
                    residents.Add(robbot);
                }

            }

            string lastDigit = Console.ReadLine();
            residents = residents.Where(x => x.ID.EndsWith(lastDigit)).ToList();
            residents.ForEach(Console.WriteLine);
        }
    }
}
