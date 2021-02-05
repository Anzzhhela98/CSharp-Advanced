using System;

namespace P01_RawData
{
   public static class Input
    {
        public static void SplitInput(out string model, out Engine engine, out Cargo cargo, out Tire[] tires)
        {
            string[] carData = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            model = carData[0];

            int engineSpeed = int.Parse(carData[1]);
            int enginePower = int.Parse(carData[2]);
            engine = new Engine(engineSpeed, enginePower);

            int cargoWeight = int.Parse(carData[3]);
            string cargoType = carData[4];
            cargo = new Cargo(cargoWeight, cargoType);

            tires = new Tire[]
          {
                    new Tire(double.Parse(carData[5]), int.Parse(carData[6])),
                    new Tire(double.Parse(carData[7]), int.Parse(carData[8])),
                    new Tire(double.Parse(carData[9]), int.Parse(carData[10])),
                    new Tire(double.Parse(carData[11]), int.Parse(carData[12])),
          };
        }
    }
}
