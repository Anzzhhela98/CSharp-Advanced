using System;
using System.Linq;

using Vehicles.Model;
using Vehicles.Core.Factories;

namespace Vehicles.Core
{
    public class Engine : IEngine
    {
        private VehicleFactory vehicleFactory;

        public Engine()
        {
            this.vehicleFactory = new VehicleFactory();
        }
        public void Run()
        {
            Vehicle car = ProduceVehicle();
            Vehicle truck = ProduceVehicle();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                try
                {
                    ProcessCommand(car, truck);
                }
                catch (InvalidOperationException ioe)
                {

                    Console.WriteLine(ioe.Message);
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
        }

        private static void ProcessCommand(Vehicle car, Vehicle truck)
        {
            string[] cmndArgs = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string cmndType = cmndArgs[0];
            string vehicleType = cmndArgs[1];
            double arg = double.Parse(cmndArgs[2]);
            try
            {
                if (cmndType == "Drive")
                {
                    if (vehicleType == "Car")
                    {
                        Console.WriteLine(car.Drive(arg));
                    }
                    else if (vehicleType == "Truck")
                    {
                        Console.WriteLine(truck.Drive(arg));
                    }
                }
                else
                {
                    if (vehicleType == "Car")
                    {
                        car.Refuel(arg);
                    }
                    else if (vehicleType == "Truck")
                    {
                        truck.Refuel(arg);
                    }
                }
            }
            catch (Exception ioe )
            {

                Console.WriteLine(ioe.Message);
            }
           
        }

        private Vehicle ProduceVehicle()
        {
            string[] vehicleArgs = Console.ReadLine()
                                   .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                   .ToArray();
            string type = vehicleArgs[0];
            double fuelQty = double.Parse(vehicleArgs[1]);
            double fuelConumption = double.Parse(vehicleArgs[2]);

            return this.vehicleFactory.ProduceVehicle(type, fuelQty, fuelConumption);
        }
    }
}
