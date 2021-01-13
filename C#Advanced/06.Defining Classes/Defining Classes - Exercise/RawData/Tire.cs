namespace RawData
{
    public class Tire
    {
        private double tireAge;

        private double tirePressure;

        public Tire(double tirePressure, int tireAge)
        {
            this.TireAge = tireAge;
            this.TirePressure = tirePressure;
        }
        public double TireAge
        {
            get { return tireAge; }
            set { tireAge = value; }
        }

        public double TirePressure
        {
            get { return tirePressure; }
            set { tirePressure = value; }
        }
    }
}
