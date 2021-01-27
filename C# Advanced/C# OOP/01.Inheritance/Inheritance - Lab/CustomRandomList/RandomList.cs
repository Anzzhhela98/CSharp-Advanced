using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        public Random random { get; set; }
        public RandomList()
        {
            this.random = new Random();
        }
        public string RandomString()
        {
            int index = random.Next(0, this.Count);
            string removedItem = this[index];
            this.RemoveAt(index);

            return removedItem;
        }
    }
}
