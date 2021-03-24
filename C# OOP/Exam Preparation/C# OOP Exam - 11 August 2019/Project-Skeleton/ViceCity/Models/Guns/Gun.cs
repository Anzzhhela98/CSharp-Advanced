using System;
using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Models.Guns
{
    public abstract class Gun : IGun
    {
        private string name;
        private int bulletsPerBarrel;
        private int totalBullets;

        protected Gun(string name, int bulletsPerBarrel, int totalBullets)
        {
            this.Name = name;
            this.BulletsPerBarrel = bulletsPerBarrel;
            this.TotalBullets = totalBullets;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException
                        ("Name cannot be null or a white space!");
                }
                this.name = value;
            }
        }

        public int BulletsPerBarrel
        {
            get { return this.bulletsPerBarrel; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException
                        ("Bullets cannot be below zero!");
                }
                this.bulletsPerBarrel = value;
            }
        }

        public int TotalBullets
        {
            get { return this.totalBullets; }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException
                        ("Total bullets cannot be below zero!");
                }
                this.totalBullets = value;
            }
        }

        public bool CanFire => this.bulletsPerBarrel > 0 || this.totalBullets > 0;

        public abstract int Fire();

        protected void Reload(int barrelCapacity)
        {
            if (this.TotalBullets >= barrelCapacity)
            {
                this.BulletsPerBarrel = barrelCapacity;
                this.TotalBullets -= barrelCapacity;
            }
        }
        protected int DecreaseBullets(int bullets)
        {
            int fireBullets = 0;
            if (this.BulletsPerBarrel - bullets >= 0)
            {
                this.BulletsPerBarrel -= bullets;
                fireBullets = bullets;
            }
            return fireBullets;
        }
    }
}
