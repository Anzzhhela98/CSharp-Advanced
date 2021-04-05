namespace OnlineShop.Models.Products.Computers.Models
{
    public class Laptop : Computer
    {
        private const double OVERALL_PERFORMANCE = 10;
        public Laptop(int id, string manufacturer, string model, decimal price) 
            : base(id, manufacturer, model, price, OVERALL_PERFORMANCE)
        {

        }

    }
}
