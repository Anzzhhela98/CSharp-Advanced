using System.Collections.Generic;
namespace SpaceStation.Models.Bags
{
    public class Bag : IBag
    {
        private List<string> items;
        public Bag()
        {
            this.items = new List<string>();
        }
        public ICollection<string> Items => this.items;
    }
}
