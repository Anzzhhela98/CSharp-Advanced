namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double UNITS_OF_OXYGEN = 70;
        private const int UNITS  = 10;

        public Biologist(string name)
            : base(name, UNITS_OF_OXYGEN)
        {

        }

        public override void Breath()
        {
            if (this.Oxygen - UNITS > 0)
            {
                this.Oxygen -= UNITS;
            }

            this.Oxygen = 0;
        }
    }
}
