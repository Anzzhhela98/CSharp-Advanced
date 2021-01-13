using System;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        private string model;

        private double fuelAmount;

        private double fuelConsumptionPerKilometer;

        private double travelledDistance;

        public Car(string model, double fuelAmout, double fuelConsumptionPerKilometer)
        {
            this.Model = model;
            this.FuelAmount = fuelAmout;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.TravelledDistance = 0;
        }
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public void Drive(double distance)
        {
            if (this.FuelConsumptionPerKilometer * distance <= this.FuelAmount)
            {
                this.FuelAmount -=
                    this.FuelConsumptionPerKilometer * distance;
                this.TravelledDistance += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
        public override string ToString()
        {
            return $"{this.Model} {this.FuelAmount:F2} {this.TravelledDistance}";
        }
    }
}
