using System.Collections.Generic;

namespace P02_CarsSalesman
{
    static class Runner
    {
        public static void Run()
        {
            List<Car> cars = new List<Car>();
            List<Engine> engines = new List<Engine>();

            InputDataCar.ReadDataCar(engines);

            InputDataEngine.ReadDataEengine(cars, engines);

            Printer.PrintCars(cars);
        }
    }
}
