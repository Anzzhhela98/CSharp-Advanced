namespace _03.Ferrari
{
    public class Ferrari : IDriveable
    {
        public Ferrari(string driver)
        {
            this.Driver = driver;
        }
        public string Model => "488-Spider";

        public string Driver { get; private set; }

        public string Brakes()
        {
            return $"Brakes!";
        }

        public string Push()
        {
            return $"Gas!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{this.Brakes()}/{this.Push()}/{this.Driver}";
        }
    }
}
