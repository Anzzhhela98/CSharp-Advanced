using MXGP.Utilities.Messages;
using System;
namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle
    {
        private const int CUBIC_CENTIMETERS = 125;
        private const int MINIMUM_HORSE_POWER = 50;
        private const int MAX_HORSE_POWER = 69;
        private int horsePower;
        public SpeedMotorcycle(string model, int horsePower)
            : base(model, horsePower, CUBIC_CENTIMETERS)
        {
            this.HorsePower = horsePower;
        }
        public override int HorsePower
        {
            get
            {
                return this.horsePower;
            }
            protected set
            {
                if (value < MINIMUM_HORSE_POWER || value > MAX_HORSE_POWER)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidHorsePower, value));
                };
            }
        }
    }
}
