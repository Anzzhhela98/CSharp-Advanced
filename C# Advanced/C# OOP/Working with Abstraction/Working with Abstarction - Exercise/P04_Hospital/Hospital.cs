using System.Collections.Generic;
using System.Linq;

namespace P04_Hospital
{
    public class Hospital
    {
        public Hospital()
        {
            Departaments = new List<Departament>(); ;
            Doctors = new List<Doctor>();
        }

        public List<Departament> Departaments { get; set; }
        public List<Doctor> Doctors { get; set; }

        public void AddDoctors(string firstName, string lastName)
        {
            if (!this.Doctors.Any(d => d.FirstName == firstName && d.LastName == lastName))
            {
                var doctor = new Doctor(firstName, lastName);
            }

        }
        public void AddDepartament(string name)
        {
            if (!this.Doctors.Any(d => d.FirstName == name)) ;
            {
                var departament = new Departament(name);
                this.Departaments.Add(departament);
            }
        }
        public void AddPAtient(string departmentName, string doctorName, string patientName)
        {

            var departament = this.Departaments.FirstOrDefault(de => de.Name == departmentName);
            var doctor = this.Doctors.FirstOrDefault(d => d.FullName == doctorName);

            Patient patient = new Patient(patientName);

            if (departament.AddPatienToRoom(patient))
            {
                doctor.Patients.Add(patient);
            }
        }
    }
}
