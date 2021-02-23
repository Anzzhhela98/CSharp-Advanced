using System;
using VehiclesExtension.Common;

namespace VehiclesExtension.Models
{
    public class Bus : Vehicle
    {
        private const double AIR_CONDITION = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }
        protected override bool Hole => false;
        protected override double AirCondition => AIR_CONDITION;
        public void EmptyBus(double distance)
        {
            double fuelWithDistance = distance * this.FuelConsumption;
            if (fuelWithDistance <= this.FuelQuantity)
            {
                this.FuelQuantity -= distance;
                Console.WriteLine(String.Format(GlobalConstants.TraveledDistance, GetType().Name, distance));
            }
            else
            {

                Console.WriteLine(String.Format(GlobalConstants.NeededRefueling, GetType().Name));
            }
        }
    }
}
