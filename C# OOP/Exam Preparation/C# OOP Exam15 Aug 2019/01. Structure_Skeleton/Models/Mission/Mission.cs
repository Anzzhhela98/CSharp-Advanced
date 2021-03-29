using System.Linq;
using SpaceStation.Models.Planets;
using System.Collections.Generic;
using SpaceStation.Models.Astronauts.Contracts;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        private List<string> itemsToRemove;
        public Mission()
        {
            this.itemsToRemove = new List<string>();
        }
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astrounaut in astronauts)
            {
              
                    if (!astrounaut.CanBreath)
                    {
                        break;
                    }
                    foreach (var item in planet.Items)
                    {
                        astrounaut.Breath();
                        astrounaut.Bag.Items.Add(item);
                        itemsToRemove.Add(item);

                    }
                    RemovePlanetItems(planet);
                
            }
        }

        private void RemovePlanetItems(IPlanet planet)
        {
            foreach (var item in itemsToRemove)
            {
                planet.Items.Remove(item);
            }
            itemsToRemove.Clear();
        }
    }
}
