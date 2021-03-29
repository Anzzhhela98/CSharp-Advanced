using System.Linq;
using SpaceStation.Models.Planets;
using System.Collections.Generic;
using SpaceStation.Repositories.Contracts;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<Planet>
    {
        private List<Planet> models;
        public PlanetRepository()
        {
            this.models = new List<Planet>();
        }
        public IReadOnlyCollection<Planet> Models => this.models;

        public void Add(Planet model) => this.models.Add(model);

        public Planet FindByName(string name)
        {
            Planet model = this.models.FirstOrDefault(x => x.Name == name);

            return model;
        }

        public bool Remove(Planet model) => this.models.Remove(model);
    }
}
