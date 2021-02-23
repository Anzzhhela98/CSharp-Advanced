using System;
using VehiclesExtension.Common;
using VehiclesExtension.Models;

namespace VehiclesExtension.Factories
{
    public class VehicleFactory
    {
        public Vehicle ProduceVehicle(string type, double fuelQty,
          double fuelConsumption, double tankCapacity)
        {
            Vehicle vehicle = null;

            if (type == "Car")
            {
                vehicle = new Car(fuelQty, fuelConsumption, tankCapacity);
            }
            else if (type == "Truck")
            {
                vehicle = new Truck(fuelQty, fuelConsumption, tankCapacity);
            }
            else if (type == "Bus")
            {
                vehicle = new Bus(fuelQty, fuelConsumption, tankCapacity);
            }
            if (vehicle == null)
            {
                throw new ArgumentException(GlobalConstants.InvalidTypeExeptionMessage);
            }
            return vehicle;
        }

    }
}
