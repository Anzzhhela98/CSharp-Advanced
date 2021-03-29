namespace SpaceStation.Models.Astronauts
{
    public class Geodesist : Astronaut
    {
        private const double UNITS_OF_OXYGEN = 50;
        public Geodesist(string name) : base(name, UNITS_OF_OXYGEN)
        {

        }
    }
}
