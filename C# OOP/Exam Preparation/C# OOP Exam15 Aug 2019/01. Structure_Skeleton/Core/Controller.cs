using System;
using System.Linq;
using System.Text;
using SpaceStation.Repositories;
using System.Collections.Generic;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Astronauts;
using SpaceStation.Utilities.Messages;
using SpaceStation.Models.Astronauts.Contracts;

namespace SpaceStation.Core.Contracts
{
    public class Controller : IController
    {
        private const int UNITS = 60;
        private AstronautRepository astronautRepository;
        private PlanetRepository planetRepository;
        private Mission mission;
        private int exploredPlanetsCount;

        public Controller()
        {
            this.astronautRepository = new AstronautRepository();
            this.planetRepository = new PlanetRepository();
            this.mission = new Mission();

            this.exploredPlanetsCount = 0;
        }

        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut = null;

            if (type == nameof(Biologist))
            {
                astronaut = new Biologist(astronautName);
            }
            else if (type == nameof(Geodesist))
            {
                astronaut = new Geodesist(astronautName);
            }
            else if (type == nameof(Meteorologist))
            {
                astronaut = new Meteorologist(astronautName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautType);
            }

            this.astronautRepository.Add(astronaut);

            return String.Format(OutputMessages.AstronautAdded, type, astronautName);
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            Planet model = new Planet(planetName);

            foreach (var item in items)
            {
                model.Items.Add(item);
            }

            this.planetRepository.Add(model);

            return String.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            List<IAstronaut> astronauts = new List<IAstronaut>();
            var planet = planetRepository.FindByName(planetName);

            if (astronauts == null)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAstronautCount);
            }

            foreach (var astronaut in astronautRepository.Models)
            {
                if (astronaut.Oxygen >= UNITS)
                {
                    astronauts.Add(astronaut);
                }
            }

            mission.Explore(planet, astronauts);

            exploredPlanetsCount = astronauts.Where(a => a.Oxygen > 0).Count();
            return String.Format(OutputMessages.PlanetExplored, planetName, exploredPlanetsCount);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.exploredPlanetsCount} planets were explored!");
            sb.AppendLine("Astronauts info:");

            foreach (var astronaut in astronautRepository.Models)
            {
                sb.AppendLine($"Name: { astronaut.Name}");
                sb.AppendLine($"Oxygen: { astronaut.Oxygen}");
                sb.AppendLine("Bag items: ");
                foreach (var item in astronaut.Bag.Items)
                {
                    sb.Append($"{item}");
                }

            }
            return sb.ToString().TrimEnd();
        }

        public string RetireAstronaut(string astronautName)
        {
            var astronaut = this.astronautRepository.FindByName(astronautName);

            if (astronaut == null)
            {
                throw new
                    InvalidOperationException(String.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }

            this.astronautRepository.Remove(astronaut);

            return String.Format(OutputMessages.AstronautRetired, astronautName);
        }
    }
}
