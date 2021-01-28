namespace NeedForSpeed
{
    public class Vehicle
    {
        public const double DefaultFuelConsumption = 1.25;

        public virtual double FuelConsumption
        {
            get
            {
                return DefaultFuelConsumption;
            }
        }
        public Vehicle(int horsePower, double fuel)
        {
            Fuel = fuel;
            HorsePower = horsePower;
        }

        public int HorsePower { get; set; }
        public double Fuel { get; set; }

        public virtual void Drive(double kilometers)
        {
            if (kilometers * FuelConsumption <= Fuel)
            {
                Fuel -= kilometers * FuelConsumption;
            }
        }

    }
}
