using System;
using System.Collections;
using System.Collections.Generic;
namespace CustomDataStructers
{
    public class CustomStack<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 4;
        private T[] items;
        private int count;

        public CustomStack()
        {
            this.items = new T[InitialCapacity];
            this.count = 0;
        }

        public int Count => this.count;

        public void Push(T element)
        {
            if (this.items.Length == this.Count)
            {
                EnsureCapacity();
            }
            this.items[count] = element;
            this.count++;
        }
        public T Pop()
        {
            ThrowWhenEmpty();
            var lastIndex = this.items[this.count - 1];
            this.count--;
            return lastIndex;
        }
        public T Peek()
        {
            ThrowWhenEmpty();
            return this.items[count - 1];
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

        private void ThrowWhenEmpty()
        {
            if (this.Count == 0)
            {
                throw new Exception("Stack is empty");
            }
        }
        public void ForEach(Action<T> action)
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                action(this.items[i]);
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.count-1; i >= 0; i--)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return null;
        }
    }
}
