using System;
namespace _03.ShoppingSpree.Common
{
    public class Product
    {

        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            this.Name = name;
            this.Cost = cost;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                if (String.IsNullOrWhiteSpace(value)||String.IsNullOrEmpty(value))
                {
                    throw new
                        ArgumentException(String.Format(GlobalConstants.InvalidInputNameExeptionMessage, nameof(this.Name)));
                }
                this.name = value;
            }
        }
        public decimal Cost
        {
            get => this.cost;

            private set
            {
                if (value < GlobalConstants.COST_MIN_VALUE)
                {
                    throw new
                        ArgumentException(String.Format(GlobalConstants.InsufficientMoneyExeptionMessage, nameof(this.Cost)));
                }
                this.cost = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Name}";
        }
    }
}
