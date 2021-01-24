using System;
using System.Collections;
using System.Collections.Generic;
namespace _01.ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> collections;
        private int index;
        public ListyIterator(List<T> collections)
        {
            this.collections = collections;
            this.index = 0;
        }

        public bool Move()
        {
            if (HasNext())
            {
                index++;
                return true;
            }
            return false;
        }
        public bool HasNext()
        {
            if (this.index < collections.Count - 1)
            {
                return true;
            }
            return false;
        }
        public void Print()
        {

            if (collections.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            else
            {
                Console.WriteLine(collections[index]);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in collections)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.Enumerator => GetEnumerator();
    }
}
