using System;
using System.Collections.Generic;
using System.Text;

namespace P05_GreedyTimes
{
    public class Gold
    {
        public Gold(string name, decimal quantity)
        {
            this.Name = name;
            this.Quantity = quantity;
        }

        public string Name { get; set; }
        public decimal Quantity { get; set; }

        public void Add(decimal quantity)
        {
            this.Quantity += quantity;
        }

        public override string ToString()
        {
            return $"##{this.Name} {this.Quantity}";
        }
    }
}
