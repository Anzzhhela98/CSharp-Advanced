using INStock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace INStock
{
    public class ProductStock : IProductStock
    {
        private List<IProduct> productStock;
        public ProductStock()
        {
            this.productStock = new List<IProduct>();
        }
        public IProduct this[int index]
        {
            get
            {
                if (index >= 0 && index < this.productStock.Count)
                {
                    return this.productStock[index] as IProduct;
                }

                throw new IndexOutOfRangeException("Index was out of range!");
            }

            set
            {
                if (index < 0 && index >= this.productStock.Count)
                {
                    throw new IndexOutOfRangeException("Index was out of range!");
                }

                this.productStock.Insert(index, value);
            }
        }

        public int Count => this.productStock.Count;

        public void Add(IProduct product)
        {
            foreach (IProduct label in productStock)
            {
                if (label.CompareTo(product) == 0)
                {
                    throw new ArgumentException("Product alredy exist!");
                }
            }
            this.productStock.Add(product);
        }

        public bool Contains(IProduct product)
        {
            foreach (IProduct label in productStock)
            {
                if (label.CompareTo(product) == 0)
                {
                    return true;
                }
            }
            return false;
        }

        public IProduct Find(int index)
        {
            if (!(index >= 0 && index < this.productStock.Count))
            {
                throw new IndexOutOfRangeException("Index was out of range!");
            }
            return this.productStock[index];
        }

        public IEnumerable<IProduct> FindAllByPrice(double price)
        {
            return this.productStock.Where(x => x.Price == (decimal)price);
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {

            return this.productStock.Where(x => x.Quantity == quantity);
        }

        public IEnumerable<IProduct> FindAllInRange(double lo, double hi)
        {
            return this.productStock
                .Where(x => x.Price >= (decimal)lo && x.Price <= (decimal)hi);
        }

        public IProduct FindByLabel(string label)
        {
            if (!this.productStock.Any(p => p.Label == label))
            {
                throw new ArgumentException("The product doesn't exist");
            }

            return this.productStock.First(p => p.Label == label);
        }

        public IProduct FindMostExpensiveProduct()
        {
            if (!this.productStock.Any())
            {
                throw new InvalidOperationException("There is no product left!");
            }
            return this.productStock.OrderByDescending(x => x.Price).First();
        }

        public bool Remove(IProduct product)
        {
            if (this.productStock.Contains(product))
            {
                this.productStock.Remove(product);
                return true;
            }
            return false;
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            for (int i = 0; i < this.productStock.Count; i++)
            {
                yield return this.productStock[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
