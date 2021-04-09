using OnlineShop.Common.Constants;
using System;
namespace OnlineShop.Models.Products
{
    public abstract class Product : IProduct
    {
        private const int MINIMUM_VALUE = 1;
        private int id;
        private string manufacturer;
        private string model;
        private decimal price;
        private double overallPerformance;

        protected Product(int id, string manufacturer, string model, decimal price, double overallPerformance)
        {
            this.Id = id;
            this.Manufacturer = manufacturer;
            this.Model = model;
            this.Price = price;
            this.OverallPerformance = overallPerformance;
        }

        public int Id
        {
            get { return this.id; }
            private set
            {
                if (value < MINIMUM_VALUE)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidProductId);
                }

                this.id = value;
            }
        }

        public string Manufacturer
        {
            get { return this.manufacturer; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidManufacturer);
                }

                this.manufacturer = value;
            }
        }

        public string Model
        {
            get { return this.model; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidModel);
                }

                this.model = value;
            }
        }

        public virtual decimal Price
        {
            get { return this.price; }
            private set
            {
                if (value < MINIMUM_VALUE)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPrice);
                }

                this.price = value;
            }
        }

        public virtual double OverallPerformance
        {
            get { return this.overallPerformance; }
            private set //?
            {
                if (value < MINIMUM_VALUE)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOverallPerformance);
                }
                this.overallPerformance = value;
            }


        }  

        public override string ToString()
        {
            return string.Format(SuccessMessages.ProductToString,
                this.OverallPerformance.ToString("f2"),
                this.Price.ToString("f2"),
                this.GetType().Name,
                this.Manufacturer,
                this.Model,
                this.Id);
        }

    }
}
