using System.Collections;
using System.Collections.Generic;

namespace Restaurant

{
    public class Product 
    {
        protected Product(string name, decimal price)
        {
            this.Name = name;
            this.Price = price;
        }
        public string Name { get; set; }
        public decimal Price { get; set; }

       
    }
}
