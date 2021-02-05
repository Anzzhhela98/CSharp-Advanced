using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreedyTimes
{
    public class Bag
    {

        private List<Item> items;

        public Bag(decimal capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        
        }

        public decimal Capacity { get; set; }
        public IReadOnlyCollection<Item> Item => this.items.AsReadOnly();
        public decimal ItemAmount => this.items.Sum(g => g.Quantity);
        public void AddItem(Item item)
        {
            Item gemy = this.items.FirstOrDefault(gi => gi.Name == item.Name);
            if (gemy == null && item.Quantity + this.GemsAmount <= this.Capacity)
            {
                if (this.ItemAmount >= this.GemsAmount + item.Quantity)
                {
                    this.items.Add(item);
                }
            }
            else if (item.Quantity + this.GemsAmount <= this.Capacity)
            {
                if (this.ItemAmount >= this.GemsAmount + item.Quantity)
                {
                    gemy.Add(item.Quantity);
                }
            }
        }
    }
}
