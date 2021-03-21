using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Utilities.Messages;
using System;

namespace CounterStrike.Models.Guns
{
    public abstract class Gun : IGun
    {
        private string name;
        private int bulletsCount;

        protected Gun(string name, int bulletsCount)
        {
            this.Name = name;
            this.BulletsCount = bulletsCount;
        }

        public string Name
        {
            get => this.name;
            private set 
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGunName);
                }
                this.name = value;
            }
        }

        public int BulletsCount
        {
            get => this.bulletsCount;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Bullets cannot be below 0.");
                }
                this.bulletsCount = value;
            }
        }
        abstract protected int FireRate { get; }
        public  int Fire()
        {
            if (this.BulletsCount - FireRate >= 0)
            {
                BulletsCount -= FireRate;
                return FireRate;
            }

            int resultInBullets = BulletsCount;
            BulletsCount = 0;
            return resultInBullets;
        }
    }
}
