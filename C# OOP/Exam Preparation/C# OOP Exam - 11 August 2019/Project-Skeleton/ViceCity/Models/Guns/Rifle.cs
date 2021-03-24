namespace ViceCity.Models.Guns
{
    public class Rifle : Gun
    {
        private const int BARREL_CAPACITY = 50;
        private const int TOTAL_BULLETS = 500;
        private const int BULLETS_PER_FIRE = 5;

        public Rifle(string name) 
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
