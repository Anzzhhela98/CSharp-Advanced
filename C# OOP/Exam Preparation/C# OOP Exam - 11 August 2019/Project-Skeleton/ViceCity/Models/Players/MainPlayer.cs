using System;
using System.Collections.Generic;
using System.Text;

namespace ViceCity.Models.Players
{
    public class MainPlayer : Player
    {
        private const string initialName = "Tommy Vercetti";
        private const int initialLifePoints = 100;

        public MainPlayer()
            : base(initialName, initialLifePoints)
        {

        }
    }
}
