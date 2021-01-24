using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _04.Froggy
{
    public class Lake : IEnumerable<int>
    {
        private List<int> stoneNumbers;

        public Lake(List<int> stoneNumbers)
        {
            this.stoneNumbers = stoneNumbers;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < stoneNumbers.Count; i+=2)
            {
                if (i % 2 == 0)
                {
                    yield return stoneNumbers[i];
                }
            }
            for (int i = stoneNumbers.Count-1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return stoneNumbers[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
