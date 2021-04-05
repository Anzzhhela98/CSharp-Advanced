namespace OnlineShop.Models.Products.Peripherals.Models
{
    public class Headset : Peripheral
    {
        public Headset(int id, string manufacturer, string model, decimal price, double overallPerformance)
            : base(id, manufacturer, model, price, overallPerformance)
        {

        }
    }
}
