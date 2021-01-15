
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
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }


        public Car(string model, double fuelAmount,
            double fuelConsumptionPerKilometer)
        {
            this.Model = model;
            this.FuelAmount = fuelAmount;
            this.FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            this.TravelledDistance = 0;
        }

    

        public void Move(double distance)
        {

            if ((distance * this.FuelConsumptionPerKilometer) <= this.FuelAmount)
            {
                this.FuelAmount -= distance * this.FuelConsumptionPerKilometer;
                this.TravelledDistance += distance;
            }
            else
            {
               Console.WriteLine("Insufficient fuel for the drive");
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Model} {this.FuelAmount:f2}" +
                $" {this.TravelledDistance}");
            return sb.ToString().TrimEnd();
        }

    }
}
