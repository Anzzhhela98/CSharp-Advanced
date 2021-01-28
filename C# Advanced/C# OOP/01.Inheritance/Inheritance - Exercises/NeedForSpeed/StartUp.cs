namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SportCar car = new SportCar(200, 100);

            car.Drive(25);
        }
    }
}
