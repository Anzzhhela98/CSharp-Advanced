using System;
using System.Linq;
using VehiclesExtension.Factories;
using VehiclesExtension.Models;

namespace VehiclesExtension.Core
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
            Vehicle bus = ProduceVehicle();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                try
                {
                    ProcessCommand(car, truck, bus);
                }
                catch (InvalidOperationException ioe)
                {

                    Console.WriteLine(ioe.Message);
                }
            }
            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }
        private static void ProcessCommand(Vehicle car, Vehicle truck, Vehicle bus)
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
                        car.Drive(arg);
                    }
                    else if (vehicleType == "Truck")
                    {
                        truck.Drive(arg);
                    }
                    else if (vehicleType == "Bus")
                    {
                        bus.Drive(arg);
                    }
                }
                else if (cmndType == "DriveEmpty")
                {
                    if (vehicleType == "Bus")
                    {
                        ((Bus)bus).EmptyBus(arg);
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
                    else if (vehicleType == "Bus")
                    {
                        bus.Refuel(arg);
                    }
                }
            }
            catch (Exception ioe)
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
            double tankCapacity = double.Parse(vehicleArgs[3]);

            return this.vehicleFactory.ProduceVehicle(type, fuelQty, fuelConumption, tankCapacity);
        }
    }
}
