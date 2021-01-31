using System.Collections.Generic;

namespace P01_RawData
{
   public static class AddingCar
    {
        public static List<Car> Add(List<Car> cars, string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            cars.Add(new Car(model, engine, cargo, tires));
            return cars;
        }
    }
}
