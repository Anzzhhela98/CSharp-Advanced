namespace Restaurant
{
    public class Cake : Dessert
    {
        private const decimal DefaultCakePrice = 5.0M;
        private const double DefaultCalories = 1000.0;
        private const double DefaultGrams = 250.0;
        public Cake(string name ) 
         : base(name, DefaultCakePrice, DefaultGrams, DefaultCalories)
        {

        }
    }
}
