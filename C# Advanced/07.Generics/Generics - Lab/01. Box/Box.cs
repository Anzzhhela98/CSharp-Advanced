using System.Collections.Generic;

namespace BoxOfT
{
    public class Box<T>
    {
        public int Count => this.Store.Count;
        public List<T> Store { get; set; }
        public Box()
        {
            this.Store = new List<T>();
        }
        public void Add(T element)
        {
            this.Store.Add(element);
        }
        public T Remove()
        {
            var element = Store[this.Count - 1];
            Store.RemoveAt(this.Count - 1);
            return element;
        }
    }
}
