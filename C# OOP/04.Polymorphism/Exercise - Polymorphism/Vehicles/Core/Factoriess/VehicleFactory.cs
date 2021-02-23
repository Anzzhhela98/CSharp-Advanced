using System;
using Vehicles.Model;
namespace Vehicles.Core.Factories
{
    public class VehicleFactory
    {
        public Vehicle ProduceVehicle(string type, double fuelQty,
          double fuelConsumption)
        {
            Vehicle vehicle = null;

            if (type == "Car")
            {
                vehicle = new Car(fuelQty, fuelConsumption);
            }
            else if (type == "Truck")
            {
                vehicle = new Truck(fuelQty, fuelConsumption);
            }
            if (vehicle == null)
            {
                throw new ArgumentException(Common.Exeptions.InvalidTypeExeptionMessage);
            }
            return vehicle;
        }
    }
}
