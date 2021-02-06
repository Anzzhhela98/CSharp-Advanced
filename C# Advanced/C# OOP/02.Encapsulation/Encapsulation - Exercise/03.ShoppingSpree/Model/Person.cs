using _03.ShoppingSpree.Common;
using System;
using System.Collections.Generic;

namespace _03.ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> bag;
        private Person()
        {
            bag = new List<Product>();
        }
        public Person(string name, decimal money):this()
        {
            this.Name = name;
            this.Money = money;
        }

        public IReadOnlyCollection<Product> Bag => this.bag.AsReadOnly();
        public string Name
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || String.IsNullOrEmpty(value))
                {
                    throw new
                    ArgumentException(String.Format(GlobalConstants.InvalidInputNameExeptionMessage, nameof(this.Name)));
                }
                this.name = value;
            }
        }
        public decimal Money
        {
            get
            {
                return this.money ;
            }
           private set
            {
                if (value < GlobalConstants.COST_MIN_VALUE)
                {
                    throw new
                        ArgumentException(String.Format(GlobalConstants.InvalidMoneyExeptionMessage, nameof(this.Money)));
                }
                this.money = value;
            }
        }
   
        public void BuyProduct(Product product)
        {
            if (this.Money < product.Cost)
            {
                throw new
                InvalidOperationException(String.Format(GlobalConstants.InsufficientMoneyExeptionMessage, this.Name, product.Name));
            }
            this.Money -= product.Cost;
            this.bag.Add(product);
        }
        public override string ToString()
        {
            string productsOutput = this.Bag.Count > 0 ? String.Join(", ", this.Bag) : "Nothing bought";
            return $"{this.Name} - {productsOutput}";
        }
    }
}
