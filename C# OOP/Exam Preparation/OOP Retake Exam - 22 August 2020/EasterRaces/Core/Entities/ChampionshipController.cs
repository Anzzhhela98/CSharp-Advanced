using System;
using System.Linq;
using System.Text;
using EasterRaces.Core.Contracts;
using EasterRaces.Models.Cars.Entities;
using EasterRaces.Models.Races.Entities;
using EasterRaces.Repositories.Entities;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;
using EasterRaces.Models.Races.Contracts;
using EasterRaces.Models.Drivers.Entities;
using EasterRaces.Models.Drivers.Contracts;

namespace EasterRaces.Core.Entities
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly IRepository<IDriver> driversRepository;
        private readonly IRepository<ICar> carsRepository;
        private readonly IRepository<IRace> racersRepository;
        public ChampionshipController()
        {
            this.driversRepository = new DriverRepository();
            this.carsRepository = new CarRepository();
            this.racersRepository = new RaceRepository();
        }
        public string AddCarToDriver(string driverName, string carModel)
        {
            var car = this.carsRepository.GetByName(carModel);
            var driver = this.driversRepository.GetByName(driverName);

            if (driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            if (car == null)
            {
                throw new InvalidOperationException($"Car {carModel} could not be found.");
            }

            driver.AddCar(car);

            this.carsRepository.Remove(car);

            return $"Driver {driverName} received car {carModel}.";
        }

        public string AddDriverToRace(string raceName, string driverName)
        {

            var race = this.racersRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            var driver = this.driversRepository.GetByName(driverName);

            if (driver == null)
            {
                throw new InvalidOperationException($"Driver {driverName} could not be found.");
            }

            race.AddDriver(driver);

            return $"Driver {driverName} received car {raceName}.";
        }

        public string CreateCar(string type, string model, int horsePower)
        {
            var existCar = this.carsRepository.GetByName(model);

            if (existCar != null)
            {
                throw new ArgumentException($"Car { model } is already created.");
            }

            Car car = null;
            if (type == "Sports")
            {
                car = new SportsCar(model, horsePower);
            }

            if (type == "Muscle")
            {
                car = new MuscleCar(model, horsePower);
            }

            this.carsRepository.Add(car);

            return $"{car.GetType().Name} {model} is created.";
        }

        public string CreateDriver(string driverName)
        {
            var existDriver = this.driversRepository.GetByName(driverName);

            if (existDriver != null)
            {
                throw new ArgumentException($"Driver {driverName} is already created.");
            }

            var driver = new Driver(driverName);

            this.driversRepository.Add(driver);

            return $"Driver {driverName} is created.";
        }

        public string CreateRace(string name, int laps)
        {
            var existRace = this.racersRepository.GetByName(name);

            if (existRace != null)
            {
                throw new InvalidOperationException($"Race {name} is already create.");
            }

            var race = new Race(name, laps);

            this.racersRepository.Add(race);

            return $"Race {name} is created.";
        }

        public string StartRace(string raceName)
        {
            var race = this.racersRepository.GetByName(raceName);

            if (race == null)
            {
                throw new InvalidOperationException($"Race {raceName} could not be found.");
            }

            if (race.Drivers.Count < 3)
            {
                throw new InvalidOperationException($"Race {raceName} cannot start with less than 3 participants.");
            }

            var drivers = race.Drivers
                .OrderByDescending(x => x.Car.CalculateRacePoints(race.Laps))
                .ToList();

            StringBuilder result = new StringBuilder();

            result.AppendLine($"Driver {drivers[0].Name} wins {raceName} race.");
            result.AppendLine($"Driver {drivers[1].Name} is second in {raceName} race.");
            result.AppendLine($"Driver {drivers[2].Name} is third in {raceName} race.");

            this.racersRepository.Remove(race);

            return result.ToString().TrimEnd();
        }
    }
}
