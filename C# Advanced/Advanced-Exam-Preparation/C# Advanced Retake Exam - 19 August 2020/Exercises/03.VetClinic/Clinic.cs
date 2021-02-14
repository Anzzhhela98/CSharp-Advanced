using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VetClinic
{
    class Clinic
    {
        private List<Pet> pets;
        private int capciy;


        public Clinic(int capacity)
        {
            Capacity = capacity;
            this.pets = new List<Pet>();
        }
        public List<Pet> Pets
        {
            get
            {
                return this.pets;
            }
            set
            {
                this.pets = value;
            }
        }

        public int Capacity
        {
            get { return capciy; }
            set { capciy = value; }
        }

        public void Add(Pet pet)
        {
            if (this.Capacity > this.pets.Count)
            {
                pets.Add(pet);
            }
        }

        public bool Remove(string name)
        {
            Pet pet = Pets.FirstOrDefault(x => x.Name == name);

            if (pet != null)
            {
                this.pets.Remove(pet);
                return true;
            }
            return false;
        }

        public Pet GetPet(string name, string owner)
        {
            Pet pet = pets.FirstOrDefault(x => x.Name == name && x.Owner == owner);
            if (pets.Contains(pet))
            {
                return pet;
            }
            return null;
        }
        public Pet GetOldestPet()
        {
            Pet pet = pets.OrderByDescending(x => x.Age).First();
            return pet;
        }
        public int Count => this.Pets.Count;
        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("The clinic has the following patients:");

            foreach (var pet in pets)
            {
                sb.AppendLine($"Pet {pet.Name} with owner: {pet.Owner}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
