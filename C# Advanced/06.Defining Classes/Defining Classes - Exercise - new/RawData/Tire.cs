
namespace RawData
{
    public class Tire
    {
        //{tire1Pressure} {tire1Age} {tire2Pressure} {tire2Age} {tire3Pressure} {tire3Age} {tire4Pressure} {tire4Age}"
        private int year;

        private double pressure;

        public Tire(double pressure, int year)
        {
            Year = year;
            Pressure = pressure;
        }
        public int Year
        {
            get { return year; }
            set { year = value; }
        }

        public double Pressure
        {
            get { return pressure; }
            set { pressure = value; }
        }
    }
}
