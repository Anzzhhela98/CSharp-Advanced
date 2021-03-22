namespace EasterRaces.Models.Cars.Entities
{
    public class MuscleCar : Car
    {
        private const double CUBIC_CENTIMETERS = 5000;
        private const int MIN_HORSE_POWER = 400;
        private const int MAX_HORSE_POWER = 600;

        public MuscleCar(string model, int horsePower)
            : base(model, horsePower, CUBIC_CENTIMETERS, MIN_HORSE_POWER, MAX_HORSE_POWER)
        {

        }
    }
}
