using System;
using System.Collections.Generic;
using System.Text;

namespace P05_GreedyTimes
{
    public class Gem 
    {
        public Gem(string name, decimal quantity) :base(name, quantity)
        {
            this.Name = name;
            this.Quantity = quantity;
        }


        public override string ToString()
        {
            return $"##{this.Name} - {this.Quantity}";
        }
    }
}
