using MXGP.Utilities.Messages;
using System;
namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle
    {

        private const int CUBIC_CENTIMETERS = 450;
        private const int MINIMUM_HORSE_POWER = 70;
        private const int MAX_HORSE_POWER = 100;
        private int horsePower;
        public PowerMotorcycle(string model, int horsePower)
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
