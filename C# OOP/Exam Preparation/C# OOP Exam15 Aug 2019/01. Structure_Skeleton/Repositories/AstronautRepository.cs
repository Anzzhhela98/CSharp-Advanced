using System;
using System.Linq;
using System.Text;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;
using System.Collections.Generic;
namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private  List<IAstronaut> models;
        public AstronautRepository()
        {
            this.models = new List<IAstronaut>();
        }
        public IReadOnlyCollection<IAstronaut> Models => this.models.AsReadOnly();

        public void Add(IAstronaut model) => this.models.Add(model);

        public IAstronaut FindByName(string name)
        {
            IAstronaut astronaut = this.models.FirstOrDefault(x => x.Name == name);

            return astronaut;
        }

        public bool Remove(IAstronaut model) => this.models.Remove(model);

    }
}
