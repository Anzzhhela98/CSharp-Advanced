namespace CounterStrike.Models.Guns
{
    public class Rifle : Gun
    {
        private const int STRIKE_RIFLE_BULLET = 10;

        public Rifle(string name, int bulletsCount) 
            : base(name, bulletsCount)
        {

        }

        protected override int FireRate
        {
            get
            {
                return STRIKE_RIFLE_BULLET;
            }
        }
    }
}
