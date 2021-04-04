using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles;
using MXGP.Models.Races;
using MXGP.Models.Riders;
using MXGP.Repositories;
using MXGP.Repositories.Contracts;
using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private const int MIN_PARTICIPANTS = 3;

        private RiderRepository riderRepository;
        private RaceRepository raceRepository;
        private MotorcycleRepository motorcycleRepository;
        public ChampionshipController()
        {
            this.riderRepository = new RiderRepository();
            this.raceRepository = new RaceRepository();
            this.motorcycleRepository = new MotorcycleRepository();
        }


        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            var rider = this.riderRepository.Models.FirstOrDefault(x => x.Name == riderName);

            if (rider == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            var motorcycle = this.motorcycleRepository.Models.FirstOrDefault(x => x.Model == motorcycleModel);

            if (motorcycle == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.MotorcycleNotFound, motorcycleModel));
            }

            rider.AddMotorcycle(motorcycle);

            return String.Format(OutputMessages.MotorcycleAdded, riderName, motorcycleModel);
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            var rider = this.riderRepository.Models.FirstOrDefault(x => x.Name == riderName);

            if (rider == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RiderNotFound, riderName));
            }

            var race = this.raceRepository.Models.FirstOrDefault(x => x.Name == raceName);

            if (race == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            race.AddRider(rider);

            return String.Format(OutputMessages.RiderAdded, riderName, raceName);
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            var existMotorcycle = this.motorcycleRepository.Models.Any(x => x.Model == model);

            if (existMotorcycle)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.MotorcycleExists, model));
            }

            Motorcycle motorcycle = null;

            if (type == "Power")
            {
                motorcycle = new PowerMotorcycle(model, horsePower);
            }
            else if (type == "Speed")
            {
                motorcycle = new SpeedMotorcycle(model, horsePower);
            }

            this.motorcycleRepository.Add(motorcycle);

            return String.Format(OutputMessages.MotorcycleCreated, motorcycle.GetType().Name, model);
        }

        public string CreateRace(string name, int laps)
        {
            var existRace = this.raceRepository.Models.Any(x => x.Name == name);
            if (existRace)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExists, name));
            }
            Race race = new Race(name, laps);
            this.raceRepository.Add(race);

            return String.Format(OutputMessages.RiderAdded, name);
        }

        public string CreateRider(string riderName)
        {
            var existRider = this.riderRepository.Models.Any(x => x.Name == riderName);
            if (existRider)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.RiderExists, riderName));
            }

            Rider rider = new Rider(riderName);
            this.riderRepository.Add(rider);

            return String.Format(OutputMessages.RiderCreated, riderName);
        }

        public string StartRace(string raceName)
        {
            var existRace = this.raceRepository.Models.FirstOrDefault(x => x.Name == raceName);

            if (existRace==null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RiderNotFound, raceName));
            }

            if (existRace.Riders.Count< MIN_PARTICIPANTS)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceInvalid, raceName, MIN_PARTICIPANTS));
            }

            var winners = 
                riderRepository.Models.OrderByDescending(x => x.Motorcycle.CalculateRacePoints(existRace.Laps)).ToList();

            var firstplace = winners[0].Name;
            var secondPlace = winners[1].Name;
            var thirdPlace = winners[2].Name;
            raceRepository.Remove(existRace);

            var sb = new StringBuilder();
            sb.AppendLine($"Rider {firstplace} wins {raceName} race.");
            sb.AppendLine($"Rider {secondPlace} is second in {raceName} race.");
            sb.AppendLine($"Rider {thirdPlace} is third in {raceName} race.");

            return sb.ToString().TrimEnd();

        }
    }
}
