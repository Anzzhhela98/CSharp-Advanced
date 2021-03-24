using System.Linq;
using System.Collections.Generic;
using ViceCity.Models.Players.Contracts;
using ViceCity.Models.Neghbourhoods.Contracts;

namespace ViceCity.Models.Neghbourhoods
{
    public class Neighbourhood : INeighbourhood
    {
        public Neighbourhood()
        {

        }
        public void Action(IPlayer mainPlayer, ICollection<IPlayer> civilPlayers)
        {
            foreach (var gun in mainPlayer.GunRepository.Models)
            {
                foreach (var curCivilPlayers in civilPlayers)
                {
                    while (curCivilPlayers.IsAlive && gun.CanFire)
                    {
                        curCivilPlayers.TakeLifePoints(gun.Fire());
                    }
                    if (!gun.CanFire)
                    {
                        break;
                    }
                }
            }

            foreach (var currenCivil in civilPlayers.Where(p => p.IsAlive))
            {
                foreach (var gun in currenCivil.GunRepository.Models)
                {
                    while (mainPlayer.IsAlive && gun.CanFire)
                    {
                        mainPlayer.TakeLifePoints(gun.Fire());
                    }

                    if (!mainPlayer.IsAlive)
                    {
                        break;
                    }
                }
            }
        }
    }
}
