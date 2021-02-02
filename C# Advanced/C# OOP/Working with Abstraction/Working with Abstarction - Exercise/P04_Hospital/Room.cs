
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Hospital
{
    public class Room
    {
        public Room()
        {
            Patients = new List<Patient>(); ;
        }

        public List<Patient> Patients { get; set; }

       public bool IsFull => this.Patients.Count >= 3;
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var patient in this.Patients.OrderBy(p=>p.Name))
            {
                sb.AppendLine(patient.Name);
            }
            return sb.ToString().TrimEnd();
        }
    }
}
