using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АЗС
{
    internal class OrderService
    {
        // in order?
        public static double CountDiscount(int totalPriceWithoutDiscount, double finalPriceWithDiscount)
        {
            return Math.Round((totalPriceWithoutDiscount - finalPriceWithDiscount), 2);
        } //сумма скидки
        public static int CountTotalPrice(int priceOfSelectedFuelOnStation, int fuelAmount)
        {
            int totalPrice = priceOfSelectedFuelOnStation * fuelAmount;
            return totalPrice;
        } // сумма без скидки
        public static double CountDiscountPrice(int totalPrice, int discount)
        {
            double discountPrice = Convert.ToDouble(totalPrice) * (1 - (Convert.ToDouble(discount) / 100));
            return discountPrice;
        } // сумма со скидкой
    }
}
