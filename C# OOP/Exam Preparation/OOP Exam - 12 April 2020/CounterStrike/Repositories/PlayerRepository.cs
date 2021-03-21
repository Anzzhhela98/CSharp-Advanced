using System;
using System.Linq;
using System.Collections.Generic;
using CounterStrike.Utilities.Messages;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Models.Players.Contracts;

namespace CounterStrike.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private List<IPlayer> models;
        public PlayerRepository()
        {
            this.models = new List<IPlayer>();
        }
        public IReadOnlyCollection<IPlayer> Models
        {
            get { return this.models.AsReadOnly(); }
        }


        public void Add(IPlayer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerRepository);
            }

            this.models.Add(model);
        }

        public IPlayer FindByName(string name)
        {
            return this.models.FirstOrDefault(m => m.Username == name);
        }

        public bool Remove(IPlayer model)
        {
            return this.models.Remove(model);
        }
    }
}
