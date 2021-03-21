namespace CounterStrike.Models.Maps.Contracts
{
    using CounterStrike.Models.Players;
    using CounterStrike.Models.Players.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public interface IMap
    {
        string Start(ICollection<IPlayer> players);
    }
}
