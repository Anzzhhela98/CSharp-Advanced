
using System.Collections.Generic;
using System.Text;

namespace _03.GenericSwapMethodStrings
{
    class Box<T>
    {
        public Box()
        {
            Value = new List<T>();
        }

        public List<T> Value { get; set; }

        public void Swap(int a, int b)
        {
            var tempArray = Value[a];
            this.Value[a] = this.Value[b];
            this.Value[b] = tempArray;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var input in Value)
            {
                sb.AppendLine($"{input.GetType().FullName}: {input}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
