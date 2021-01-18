using System;

namespace CustomDataStructers
{
    public class CustomList
    {
        private const int InitialCapacity = 2;
        private int[] items;
        public CustomList() //int[] items
        {
            this.items = new int[InitialCapacity];
        }

        public int Count { get; private set; }
        public int this[int index]
        {
            get
            {
                if (index >= this.Count)
                {
                    throw new IndexOutOfRangeException();
                }
                return this.items[index];
            }
            set
            {
                if (index >= this.Count)
                {
                    throw new IndexOutOfRangeException();
                }
                this.items[index] = value;
            }
        }
        private void EnsureCapacity()
        {
            if (this.items.Length < this.Count)
            {
                return;
            }
            int[] copy = new int[this.items.Length * 2];

            for (int i = 0; i < this.items.Length; i++)
            {
                copy[i] = items[i];
            }
            this.items = copy;
        }

        public void Add(int item)
        {

            if (this.Count == this.items.Length)
            {
                EnsureCapacity();
            }
            this.items[this.Count] = item;
            this.Count++;
        }
        public int RemoveAt(int index)
        {
            ValidIndex(index);
            return;
        }

        public bool ValidIndex(int index)
        {
            if (index >= 0 && index < this.Count)
            {
                return true;
            }
            return false;
        }

    }
}
