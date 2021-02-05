

namespace NeedForSpeed
{
    public class SportCar : Car
    {
        public const double DefaultCarFuelConsumption = 10;
        public SportCar(int horsePower, double fuel) : base(horsePower, fuel)
        {

        }

        public override double FuelConsumption
        {
            get
            {
                return DefaultCarFuelConsumption;
            }
        }
    }
}
