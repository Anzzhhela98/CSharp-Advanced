namespace Vehicles.Model
{
    public class Car : Vehicle
    {
        private const double FUEL_CONSUMPTION_MODIFIER = 0.9;
        public Car(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption)
        {
            this.FuelConsumption += FUEL_CONSUMPTION_MODIFIER;
        }

        public override bool Hole => false;
    }
}
