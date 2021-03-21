namespace CounterStrike.Models.Guns
{
    public class Pistol : Gun
    {
        private const int STRIKE_PISTOL_BULLET = 1;

        public Pistol(string name, int bulletsCount)
            : base(name, bulletsCount)
        {

        }

        protected override int FireRate
        {
            get
            {
                return STRIKE_PISTOL_BULLET;
            }
        }
    }
}
