using OnlineShop.Common.Constants;
using OnlineShop.Models.Products.Components;
using OnlineShop.Models.Products.Peripherals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineShop.Models.Products.Computers
{
    public abstract class Computer : Product, IComputer
    {
        private List<IComponent> components;
        private List<IPeripheral> peripherals;
        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public override double OverallPerformance
        {
            get
            {
                if (this.components.Count == 0)
                {
                    return base.OverallPerformance;
                }
                else
                {
                    return base.OverallPerformance + this.Components.Average(x => x.OverallPerformance);
                }
            }

        }

        public override decimal Price => base.Price + this.components.Sum(x => x.Price) + this.peripherals.Sum(x => x.Price);

        public IReadOnlyCollection<IComponent> Components => this.components.AsReadOnly();

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals.AsReadOnly();

        public void AddComponent(IComponent component)
        {
            var result = this.components.FirstOrDefault(x => x.GetType().Name == component.GetType().Name);
            if (result != null)
            {
                throw new ArgumentException(String.Format
                    (ExceptionMessages.ExistingComponent, component.GetType().Name, this.GetType().Name, this.Id));
            }
            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
         
            if (this.peripherals.Any(x => x.GetType().Name == peripheral.GetType().Name))
            {
                throw new ArgumentException(String.Format
                    (ExceptionMessages.ExistingPeripheral, peripheral.GetType().Name, this.GetType().Name, this.Id));
            }

            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            IComponent result = this.components.FirstOrDefault(x => x.GetType().Name == componentType);

            if (result == null || this.components == null)
            {
                throw new ArgumentException
                    (String.Format(ExceptionMessages.NotExistingComponent, componentType, this.GetType().Name, this.Id));
            }

            this.components.Remove(result);
            return result;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            IPeripheral result = this.peripherals.FirstOrDefault(x => x.GetType().Name == peripheralType);

            if (result == null || this.components == null)
            {
                throw new ArgumentException
                    (String.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, this.GetType().Name, this.Id));
            }

            this.peripherals.Remove(result);
            return result;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());

            sb.AppendLine(String.Format(SuccessMessages.ComputerComponentsToString, this.components.Count));
            foreach (var component in this.components)
            {
                sb.AppendLine($"  {component}");
            }

            double value = 0;
            if (this.peripherals.Any())
            {
                value = this.peripherals.Average(x => x.OverallPerformance);

            }
            else
            {
                value = 0;
            }

            sb.AppendLine($" Peripherals ({this.peripherals.Count}); Average Overall Performance ({value:f2}):");

            foreach (var peripheral in peripherals)
            {
                sb.AppendLine($"  {peripheral}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
