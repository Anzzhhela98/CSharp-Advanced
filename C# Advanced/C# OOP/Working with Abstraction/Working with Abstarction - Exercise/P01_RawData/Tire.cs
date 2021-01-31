namespace P01_RawData
{
    public class Tire
    {
        public Tire(double pressure, int age)
        {
            this.Age = age;
            this.Pressure = pressure;
        }

        public int Age { get; private set; }
        public double Pressure { get; private set; }
    }
}
