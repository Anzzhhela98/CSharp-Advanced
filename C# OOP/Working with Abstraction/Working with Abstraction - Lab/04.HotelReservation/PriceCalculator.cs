using System;
using System.Collections.Generic;
using System.Text;

namespace _04.HotelReservation
{
    static class PriceCalculator
    {

      public  static decimal GetTotalPrice(decimal pricePerDay, int numberOfDays,
            Season season, Discount discount)
        {
            decimal price = 0M;

            price += pricePerDay * (int)season * numberOfDays;
            price -= price * (decimal)discount/100; 

            return price;
        }

    }
}
