using System;
using System.Linq;

namespace P04_Hospital
{
    public class Engine
    {
        private Hospital hospital;
        public Engine()
        {
            this.hospital = new Hospital();
        }
        public void Run()
        {
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "Output")
            {
                string[] argument = command.Split();

                var department = argument[0];
                var firstName = argument[1];
                var lastName = argument[2];
                var patient = argument[3];
                var fullName = firstName + lastName;

                        this.hospital.AddDoctors(firstName, lastName);
                this.hospital.AddDepartament(department);
                this.hospital.AddPAtient(department, fullName, patient);
            }

            while ((command = Console.ReadLine()) != "End")
            {
                string[] argument = command.Split();

                if (argument.Length == 1)
                {
                    var departmentName = argument[0];
                    var department = this.hospital.Departaments.FirstOrDefault(de => de.Name == departmentName);

                    Console.WriteLine(department);
                }
                else
                {
                    bool isRoom = int.TryParse(argument[1], out int result);

                    if (isRoom)
                    {
                        var departmentName = argument[0];
                        var department = this.hospital.Departaments.FirstOrDefault(de => de.Name == departmentName);

                        var currentRoom = department.Rooms[result - 1];
                        Console.WriteLine(currentRoom);
                    }
                    else
                    {
                        string firstName = argument[0];
                        string lastName = argument[1];

                        string fullName = firstName + " " + lastName;

                        var doctor = this.hospital.Doctors.FirstOrDefault(c => c.FirstName == firstName);

                        Console.WriteLine(doctor);
                    }
                }
            }
        }
    }
}
