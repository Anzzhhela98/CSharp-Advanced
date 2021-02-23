using System;
using System.Collections.Generic;
using System.Text;
using Vehicles_Extension.Contracts;

namespace Vehicles_Extension.Models
{
    public abstract class Vehicle: IDriveable, IRefulable
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }

        protected double FuelQuantity { get; set; }
        protected double FuelConsumption { get; set; }
        protected double TankCapacity { get; set; }

        public string Drive(double distance)
        {
            throw new NotImplementedException();
        }

        public void Refuel(double fuel)
        {
            throw new NotImplementedException();
        }
    }
}
