using MXGP.Models.Riders.Contracts;
using MXGP.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;
namespace MXGP.Repositories
{
    public class RiderRepository : IRepository<IRider>
    {
        private readonly List<IRider> riders;
        public RiderRepository()
        {
            this.riders = new List<IRider>();
        }
        public ICollection<IRider> Models => this.riders;

        public void Add(IRider model) => this.riders.Add(model);

        public IReadOnlyCollection<IRider> GetAll() => this.riders.AsReadOnly();

        public IRider GetByName(string name) => this.riders.FirstOrDefault(x => x.Name == name);

        public bool Remove(IRider model) => this.riders.Remove(model);
    }
}

