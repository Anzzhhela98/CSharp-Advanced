using System;
using System.Collections;
using System.Collections.Generic;

namespace _03.Stack
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private List<T> elements;
        private int index = -1;
        public CustomStack()
        {
            this.elements = new List<T>();
        }
        public void Push(T[] items)
        {
            foreach (var item in items)
            {
                elements.Add(item);
                index++;
            }
        }
        public void Pop()
        {
            if (elements.Count > 0)
            {
                elements.Remove(elements[index]);
                index--;
            }
            else
            {
                throw new InvalidOperationException("No elements");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = index; i >= 0; i--)
            {
                yield return elements[i];
            }
        }

        IEnumerator IEnumerable.Enumerator => GetEnumerator();
    }
}
