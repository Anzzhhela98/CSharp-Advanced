namespace VehiclesExtension.Models
{
    public class Car : Vehicle
    {
        private const double AIR_CONDITION = 0.9;
        private const bool HOLE = false;
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {

        }
        protected override bool Hole => HOLE;
        protected override double AirCondition => AIR_CONDITION;
    }
}
