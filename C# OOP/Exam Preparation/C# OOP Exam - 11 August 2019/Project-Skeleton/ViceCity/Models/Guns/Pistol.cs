namespace ViceCity.Models.Guns.Contracts
{
    public class Pistol : Gun
    {
        private const int BARREL_CAPACITY = 10;
        private const int TOTAL_BULLETS = 100;
        private const int BULLETS_PER_FIRE = 1;

        public Pistol(string name)
            : base(name, BARREL_CAPACITY, TOTAL_BULLETS)
        {

        }

        public override int Fire()
        {
            if (this.BulletsPerBarrel < BULLETS_PER_FIRE)
            {
                this.Reload(BARREL_CAPACITY);
            }

            return this.DecreaseBullets(BULLETS_PER_FIRE);
        }
    }
}
