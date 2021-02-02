using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Hospital
{
    public class Departament
    {
        public Departament(string name)
        {
            this.Name = name;
        }

        public List<Room> Rooms { get; set; }

        public string Name { get; set; }

        public bool AddPatienToRoom(Patient patient)
        {
            var currentRum = this.Rooms.FirstOrDefault(de => !de.IsFull);
            if (currentRum != null)
            {
                currentRum.Patients.Add(patient);
                return true;
            }
            return false;
        }

        private void CreateRooms()
        {
            for (int i = 0; i < 20; i++)
            {
                this.Rooms.Add(new Room());
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var room in this.Rooms)
            {
                foreach (var patient in room.Patients)
                {
                    sb.AppendLine(patient.Name);
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
