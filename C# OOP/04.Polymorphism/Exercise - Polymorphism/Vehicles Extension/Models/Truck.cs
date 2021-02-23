namespace VehiclesExtension.Models
{
    public class Truck : Vehicle
    {
        private const double AIR_CONDITION = 1.6;
        private const bool HOLE = true;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }
        protected override bool Hole => HOLE;
        protected override double AirCondition => AIR_CONDITION;
    }
}
