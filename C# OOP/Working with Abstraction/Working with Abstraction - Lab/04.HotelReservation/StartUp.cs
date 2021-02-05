using System;
using System.Linq;

namespace _04.HotelReservation
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] information = Console
                          .ReadLine()
                          .Split(" ")
                          .ToArray();
            decimal price = decimal.Parse(information[0]);
            int days = int.Parse(information[1]);

            Season season = Enum.Parse<Season>(information[2]);
            Discount discount = Discount.None;

            if (information.Length == 4)
            {
                discount = Enum.Parse<Discount>(information[3]);
            }

            decimal totalPrice = PriceCalculator.GetTotalPrice(price, days, season, discount);
            Console.WriteLine($"{totalPrice:f2}");
        }
    }
}
