using OnlineShop.Common.Constants;
using System;


namespace OnlineShop.Models.Products.Peripherals
{
    public abstract class Peripheral : Product, IPeripheral
    {
        protected Peripheral(int id, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.ConnectionType = connectionType;
        }

        public string ConnectionType { get;  }

        public override string ToString()
        {
            return base.ToString() + String.Format(SuccessMessages.PeripheralToString, this.ConnectionType);
        }
    }
}
