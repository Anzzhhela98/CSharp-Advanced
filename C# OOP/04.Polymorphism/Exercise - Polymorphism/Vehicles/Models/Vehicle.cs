using System;
using Vehicles.Contracts;

namespace Vehicles.Model
{
    public abstract class Vehicle : IRefuelable, IDriveable
    {
        private const double tank = 0.95;
        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }
        public double FuelQuantity { get; set; }
        public double FuelConsumption { get; set; }
        public abstract bool Hole { get; }
        public string Drive(double distance)
        {
            double fuelNeeded = this.FuelConsumption * distance;
            if (this.FuelQuantity < fuelNeeded)
            {
                throw new ArgumentException
                    (string.Format(Common.Exeptions.ExeptionOverloadFuel, GetType().Name));
            }
            this.FuelQuantity -= fuelNeeded;
            return $"{this.GetType().Name} travelled { distance} km";
        }
        public virtual void Refuel(double liters)
        {
            if (Hole)
            {
                this.FuelQuantity += liters * tank;

            }
            else
            {
                this.FuelQuantity += liters;
            }
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}
