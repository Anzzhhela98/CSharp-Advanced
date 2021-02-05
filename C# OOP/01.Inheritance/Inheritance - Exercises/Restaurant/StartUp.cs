using System.Collections.Generic;

namespace Restaurant
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Product> listing = new List<Product>();

            Coffee coffe = new Coffee("Lavaza", 30);
            Dessert desert = new Dessert("Nedelq", 25, 500, 1000);
            var tea = new Tea("Twings", 2, 250);
            var soup = new Soup("Potato", 3, 250);

            listing.Add(coffe);
            listing.Add(desert);
            listing.Add(tea);
            listing.Add(soup);

            foreach (var item in listing)
            {
                System.Console.WriteLine($"{item.GetType()}, {item.Name}, {item.Price},{item}");
            }
        }
    }
}