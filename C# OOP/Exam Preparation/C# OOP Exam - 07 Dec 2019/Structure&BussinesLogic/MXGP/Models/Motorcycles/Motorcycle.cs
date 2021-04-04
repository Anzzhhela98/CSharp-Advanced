using MXGP.Models.Motorcycles.Contracts;
using MXGP.Utilities.Messages;
using System;
namespace MXGP.Models.Motorcycles
{
    public abstract class Motorcycle : IMotorcycle
    {
        private const int MIN_SYMBOL = 4;
        private string model;

        protected Motorcycle(string model, int horsePower, double cubicCentimeters)
        {
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
        }

        public string Model
        {
            get { return this.model; }
            private set
            {
                if (String.IsNullOrWhiteSpace(value) || value.Length < MIN_SYMBOL)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidModel, value, MIN_SYMBOL));
                }
                this.model = value;
            }
        }

        public virtual int HorsePower { get; protected set; }

        public double CubicCentimeters { get; private set; }

        public double CalculateRacePoints(int laps) => CubicCentimeters / HorsePower * laps;
    }
}
