using System;
using VehiclesExtension.Common;
using VehiclesExtension.Contracts;

namespace VehiclesExtension.Models
{
    public abstract class Vehicle : IDriveable, IRefulable
    {
        private const double tank = 0.95;
        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }

        protected double FuelQuantity { get; set; }
        protected double FuelConsumption { get; set; }
        protected double TankCapacity { get; set; }
        protected abstract double AirCondition { get; }
        protected abstract bool Hole { get; }
        public virtual void  Drive(double distance)
        {
            double distanceWithFuel = distance * (this.FuelConsumption + AirCondition);
            if (distanceWithFuel <= this.FuelQuantity)
            {
                this.FuelQuantity -= distanceWithFuel;
                Console.WriteLine(String.Format(GlobalConstants.TraveledDistance, GetType().Name, distance));
            }
            else
            {
                Console.WriteLine(String.Format(GlobalConstants.NeededRefueling, GetType().Name));
            }
        }

        public void Refuel(double liters)
        {
            bool IsQuantityMoreThanCapacity =
                (liters + this.FuelQuantity) > this.TankCapacity;
            if (liters <= 0)
            {
                throw new ArgumentException(
                    String.Format(Common.GlobalConstants.IsLessThanOrToZero));
            }
            if (IsQuantityMoreThanCapacity)
            {
                throw new InvalidOperationException(
                    String.Format(Common.GlobalConstants.IsMoreThanCapacity, liters));
            }
            if (Hole)
            {
                this.FuelQuantity += liters * tank;
            }
            else
            {
                this.FuelQuantity += liters;
            }
        }
        public override string ToString() => $"{this.GetType().Name}: {this.FuelQuantity:f2}";
    }
}
