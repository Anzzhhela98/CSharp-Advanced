using System;
using System.Linq;
using System.Collections.Generic;
using ViceCity.Core.Contracts;
using ViceCity.Models.Guns;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Models.Players;
using ViceCity.Models.Players.Contracts;
using ViceCity.Models.Neghbourhoods;
using System.Text;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        private const string MainPlayerNameKey = "Vercetti";
        private const string FullNameMainPlayer = "Tommy Vercetti";

        private readonly IPlayer mainPlayer;
        private readonly ICollection<IPlayer> civilPlayers;
        private readonly ICollection<IGun> guns;
        private readonly INeighbourhood neighbourhood;

        public Controller()
        {
            this.mainPlayer = new MainPlayer();
            this.civilPlayers = new List<IPlayer>();
            this.guns = new List<IGun>();
            this.neighbourhood = new Neighbourhood();
        }

        public string AddGun(string type, string name)
        {
            if (type == nameof(Rifle))
            {
                this.guns.Add(new Rifle(name));
            }
            else if (type == nameof(Pistol))
            {
                this.guns.Add(new Pistol(name));
            }
            else
            {
                return "Invalid gun type!";
            }

            return $"Successfully added {name} of type: {type}";
        }
        public string AddPlayer(string name)
        {
            var civilPlayer = new CivilPlayer(name);
            this.civilPlayers.Add(civilPlayer);

            return $"Successfully added civil player: {name}!";
        }

        public string AddGunToPlayer(string name)
        {
            string message = String.Empty;
            if (!guns.Any())
            {
                return "There are no guns in the queue!";
            }

            IGun gun = this.guns.FirstOrDefault();
            if (name == MainPlayerNameKey)
            {
                mainPlayer.GunRepository.Add(gun);
                this.guns.Remove(gun);
                return $"Successfully added {gun.Name} to the Main Player: Tommy Vercetti";
            }

            var civilPlayer = this.civilPlayers.FirstOrDefault(p => p.Name == name);
            if (civilPlayer != null)
            {
                civilPlayer.GunRepository.Add(gun);

                this.guns.Remove(gun);
                return $"Successfully added {gun.Name} to the Civil Player: {civilPlayer.Name}";
            }
            else
            {
                return "Civil player with that name doesn't exists!";
            }

            //this.guns.Remove(gun);
            return message;
        }

        public string Fight()
        {
            var civilTotalLife = civilPlayers.Sum(c => c.LifePoints);
            this.neighbourhood.Action(this.mainPlayer, this.civilPlayers);

            var sumCivilAfterFight = civilPlayers.Sum(c => c.LifePoints);

            if (mainPlayer.LifePoints == 100 && sumCivilAfterFight == civilTotalLife)
            {
                return "Everything is okay!";
            }
            else
            {
                var sb = new StringBuilder();

                var deadCivilPlayers = civilPlayers.Where(c => !c.IsAlive).Count();
                sb.AppendLine("A fight happened:");
                sb.AppendLine($"Tommy live points: {mainPlayer.LifePoints}!");
                sb.AppendLine($"Tommy has killed: {deadCivilPlayers} players!");
                sb.AppendLine($"Left Civil Players: {civilPlayers.Where(c => c.IsAlive).Count()}!");

                return sb.ToString().TrimEnd();
            }

        }
    }
}
