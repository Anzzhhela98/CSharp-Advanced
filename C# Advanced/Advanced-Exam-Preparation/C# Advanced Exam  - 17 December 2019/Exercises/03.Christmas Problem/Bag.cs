using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Christmas
{
    class Bag
    {
        private List<Present> presents;

        public Bag(string color, int capacity)
        {
            this.Color = color;
            this.Capacity = capacity;
            this.presents = new List<Present>();

        }

        public List<Present> Presents { get; set; }

        public string Color { get; set; }
        public int Capacity { get; set; }

        public int Count => this.presents.Count;

        public void Add(Present present)
        {
            if (this.Capacity > this.presents.Count)
            {
                presents.Add(present);
                this.Capacity++;
            }
        }

        public bool Remove(string name)
        {
            Present present = presents.FirstOrDefault(x => x.Name == name);

            return presents.Remove(present);
        }
        public Present GetHeaviestPresent()
        {
            Present currentPresent = presents.OrderByDescending(x => x.Weight).FirstOrDefault();
            return currentPresent;
        }
        public Present GetPresent(string name)
        {
            Present currentPresent = presents.FirstOrDefault(x => x.Name == name);
            return currentPresent;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.Color} bag contains:");

            foreach (var present in presents)
            {
                sb.AppendLine(present.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
