using System;
using System.Linq;
using System.Collections.Generic;
using WarCroft.Entities.Items;
using WarCroft.Constants;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private const int DefaultCapacity = 100;
        private int capacity;
        private List<Item> items;
        protected Bag(int capacity)
        {
            this.Capacity = capacity;
            this.items = new List<Item>();
        }

        public int Capacity
        {
            get { return this.capacity; }
            set
            {
                if (value < 0 || value > DefaultCapacity) //?
                {
                    this.capacity = DefaultCapacity;
                }
                else
                {
                    this.capacity = value;
                }
            }
        }

        public int Load => this.Items.Sum(i => i.Weight);

        public IReadOnlyCollection<Item> Items => this.items.AsReadOnly();

        public void AddItem(Item item)
        {
            if (this.Load + item.Weight > this.Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }

            this.items.Add(item);
        }

        public Item GetItem(string name)
        {
            if (!this.items.Any())
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }

            if (!this.items.Any(x => x.GetType().Name == name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            Item item = this.items.FirstOrDefault(x => x.GetType().Name == name);
            this.items.Remove(item);

            return item;
        }
    }
}
