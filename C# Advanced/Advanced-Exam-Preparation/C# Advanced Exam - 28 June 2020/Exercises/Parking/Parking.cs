using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> cars;

        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            this.cars = new List<Car>();
        }

        public List<Car> Cars
        {
            get => this.cars;
            set { cars = value; }
        }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count => this.Cars.Count;
        public void Add(Car car)
        {
            if (Capacity > this.cars.Count)
            {
                cars.Add(car);
                this.Capacity--;
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            Car car = cars.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);

            if (car != null)
            {
                cars.Remove(car);
                return true;
            }
            return false;
        }

        public Car GetLatestCar()
        {
            if (cars.Count == 0)
            {
                return null;
            }

            Car car;
            return car = cars.OrderByDescending(x => x.Year).First();
        }
        public Car GetCar(string manufacturer, string model)
        {
            Car car = cars.First(x => x.Manufacturer == manufacturer && x.Model == model);

            if (car != null)
            {
                return car;
            }
            return null;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {this.Type}:");

            foreach (var car in cars)
            {
                sb.AppendLine(car.ToString());
            }
            return sb.ToString().TrimEnd();

        }
    }
}
