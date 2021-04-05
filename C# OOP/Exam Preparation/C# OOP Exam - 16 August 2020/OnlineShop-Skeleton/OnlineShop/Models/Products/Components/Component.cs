using OnlineShop.Common.Constants;
using System;
using System.Text;

namespace OnlineShop.Models.Products.Components
{
    public  class Component : Product, IComponent
    {
        protected Component(int id, string manufacturer, string model, decimal price, double overallPerformance, int generation)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.Generation = generation;
        }

        public int Generation { get; private set; }

        public override string ToString()
        {
            return base.ToString() +  String.Format(SuccessMessages.ComponentToString, this.Generation);
        }
    }
}
