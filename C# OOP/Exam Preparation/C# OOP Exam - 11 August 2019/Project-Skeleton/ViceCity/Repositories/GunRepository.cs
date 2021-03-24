using System.Linq;
using System.Collections.Generic;
using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Repositories.Contracts
{
    public class GunRepository : IRepository<IGun>
    {
        private readonly List<IGun> guns;
        public GunRepository()
        {
            this.guns = new List<IGun>();
        }
        public IReadOnlyCollection<IGun> Models => this.guns.AsReadOnly();

        public void Add(IGun model)
        {
            if (!this.guns.Contains(model))
            {
                this.guns.Add(model);
            }
        }

        public IGun Find(string name) => this.guns.First(n => n.Name == name);

        public bool Remove(IGun model) => this.guns.Remove(model);
    }
}
