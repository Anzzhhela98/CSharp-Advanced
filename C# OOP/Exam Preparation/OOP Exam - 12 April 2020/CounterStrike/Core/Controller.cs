using System;
using System.Linq;
using System.Text;
using CounterStrike.Models.Maps;
using CounterStrike.Models.Guns;
using CounterStrike.Repositories;
using CounterStrike.Models.Players;
using CounterStrike.Core.Contracts;
using CounterStrike.Utilities.Messages;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players.Contracts;

namespace CounterStrike.Core
{
    public class Controller : IController
    {
        private GunRepository gunRepository;
        private PlayerRepository playerRepository;
        private IMap map;

        public Controller()
        {
            gunRepository = new GunRepository();
            playerRepository = new PlayerRepository();
            map = new Map();
        }

        public string AddGun(string type, string name, int bulletsCount)
        {
            IGun gun;
            if (type == "Rifle")
            {
                gun = new Rifle(name, bulletsCount);
            }
            else if (type == "Pistol")
            {
                gun = new Pistol(name, bulletsCount);
            }
            else
            {
                throw new ArgumentException("Invalid gun type!");
            }
            this.gunRepository.Add(gun);

            return String.Format(OutputMessages.SuccessfullyAddedGun, name);
        }

        public string AddPlayer(string type, string username, int health, int armor, string gunName)
        {
            IGun gun = gunRepository.FindByName(gunName);
            if (gun is null)
            {
                throw new ArgumentException("Gun cannot be found!");
            }

            IPlayer player;
            if (type == "Terrorist")
            {
                player = new Terrorist(username, health, armor, gun);
            }
            else if (type == "CounterTerrorist")
            {
                player = new CounterTerrorist(username, health, armor, gun);
            }
            else
            {
                throw new ArgumentException("Invalid player type!");
            }

            this.playerRepository.Add(player);

            return String.Format(OutputMessages.SuccessfullyAddedPlayer, username);
        }

        public string StartGame()
        {
            return this.map.Start(playerRepository.Models.ToList());
        }

        public string Report()
        {
            var sortedPlayers = this.playerRepository.Models
                .OrderBy(p => p.GetType().Name)
                .ThenByDescending(h => h.Health)
                .ThenBy(u => u.Username);

            StringBuilder sb = new StringBuilder();
            foreach (var palyer in sortedPlayers)
            {
                sb.AppendLine(palyer.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
