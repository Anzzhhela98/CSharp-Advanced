namespace CustomDataStructers
{
    using System;
    using System.Text;
    public class CustomList<T>
    {
        private const int InitialCapacity = 2;
        private T[] items;
        public CustomList()
        {
            this.items = new T[InitialCapacity];
            this.Count = 0;
        }

        public int Count { get; private set; }
        public T this[int index]
        {
            get
            {
                ValidIndex(index);
                return this.items[index];
            }
            set
            {
                ValidIndex(index);
                this.items[index] = value;
            }
        }
        public void Add(T item)
        {

            if (this.Count == this.items.Length)
            {
                EnsureCapacity();
            }
            this.items[this.Count] = item;
            this.Count++;
        }

        public T RemoveAt(int index)
        {
            ValidIndex(index);
            T element = this.items[index];
            ShiftLeft(index);
            this.Count--;
            Shrink();
            return element;
        }
        public void InsertAt(int index, T element)
        {
            ValidIndex(index);
            EnsureCapacity();
            this.Count++;
            ShiftRight(index);
            this.items[index] = element;

        }
        public T Find(Predicate<T> match)
        {
            for (int i = 0; i < this.items.Length; i++)
            {
                if (match(items[i]))
                {
                    return items[i];
                }
            }
            return default(T);
        }
        private void EnsureCapacity()
        {
            if (this.items.Length > this.Count)
            {
                return;
            }
            var copy = new T[this.items.Length * 2];

            for (int i = 0; i < this.items.Length; i++)
            {
                copy[i] = items[i];
            }
            this.items = copy;
        }
        public void Reverse()
        {
            for (int i = 0; i < this.Count / 2; i++)
            {
                Swap(i, this.Count - i - 1);
            }
        }
        public void Swap(int firstIndex, int secondIndex)
        {
            ValidIndex(firstIndex);
            ValidIndex(secondIndex);
            var temp = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = temp;

        }
        private void ValidIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }

        }
        private void Shrink()
        {
            if (this.Count * 4 >= this.items.Length)
            {
                return;
            }
            var tempArray = new T[this.items.Length / 2];

            for (int i = 0; i < this.Count; i++)
            {
                tempArray[i] = this.items[i];
            }
            this.items = tempArray;
        }
        private void ShiftLeft(int index)
        {
            for (int i = 0; i < this.Count-1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
            this.items[this.Count - 1] = default;
        }
        private void ShiftRight(int index)
        {
            for (int i = this.Count; i > index; i--)
            {
                this.items[i] = this.items[i - 1];
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.Count - 1; i++)
            {
                sb.Append($"{this.items[i]}, ");
            }

            return sb.ToString().TrimEnd(' ', ',');
        }

    }
}
