using System.Collections.Generic;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        private int capacity;
        public Parking(int capacity)
        {
            Capacity = capacity;
            AllCars = new List<Car>();
        }

        public List<Car> AllCars { get; set; }
        public int Capacity { get; set; }
        public int Count => AllCars.Count;


        public string AddCar(Car car)
        {
            if (AllCars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            if (Count >= Capacity)
            {
                return "Parking is full!";
            }
            else
            {
                AllCars.Add(car);
                return $"Successfully added new car {car.Make } {car.RegistrationNumber}";
            }

        }
        public string RemoveCar(string registrationNumber)
        {
            if (!AllCars.Any(x => x.RegistrationNumber == registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                AllCars.Remove(AllCars.Where(x => x.RegistrationNumber == registrationNumber).FirstOrDefault());
                return $"Successfully removed {registrationNumber}";
            }

        }
        public Car GetCar(string registrationNumber)
        {

            return AllCars.FirstOrDefault(x=>x.RegistrationNumber==registrationNumber);
        }
        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            foreach (var number in RegistrationNumbers)
            {
                if (AllCars.Any(x => x.RegistrationNumber == number.ToString()))
                {
                    this.AllCars.RemoveAll(x => x.RegistrationNumber == number);
                }
            }
        }
    }
}
