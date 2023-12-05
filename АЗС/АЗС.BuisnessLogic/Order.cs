using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace АЗС.BuisnessLogic
{
    public class Order
    {
        private int DiscountSize { get; set; }
        public CurrentFuel ChosenFuel { get; set; }
        public Station ChosenStation { get; set; }
        public int FuelAmount { get; set; }

        public Order(Station chosenStation, CurrentFuel chosenFuel, int fuelAmount, Discount discount)
        {
            ChosenStation = chosenStation;
            ChosenFuel = chosenFuel;
            FuelAmount = fuelAmount;
            DiscountSize = discount.DiscountSize;
        }

        public Order()
        {

        }
        public Cheque CreateCheque()
        {
            int totalPrice = CountTotalPrice(ChosenStation.GasPrice[ChosenFuel.FuelTypeName], FuelAmount);
            double finalPriceWithDiscount = CountDiscountPrice(totalPrice, DiscountSize);
            double discountAmount = CountDiscount(totalPrice, finalPriceWithDiscount);
            string cheque = "";
            cheque += $"Ваш заказ\n" +
                $"АЗС: {ChosenStation.Name}, ул. {ChosenStation.Address}\n" +
                $"{ChosenFuel.FuelTypeName}   {ChosenStation.GasPrice[ChosenFuel.FuelTypeName]}р X {FuelAmount}л = {totalPrice}р\n" +
                $"Скидка составила: {discountAmount}р ({DiscountSize}%)\n" +
                $"Итого: {finalPriceWithDiscount}р";
            return new Cheque(cheque);
        }
        private static double CountDiscount(int totalPriceWithoutDiscount, double finalPriceWithDiscount)
        {
            return Math.Round((totalPriceWithoutDiscount - finalPriceWithDiscount), 2);
        } //сумма скидки
        private static int CountTotalPrice(int priceOfSelectedFuelOnStation, int fuelAmount)
        {
            int totalPrice = priceOfSelectedFuelOnStation * fuelAmount;
            return totalPrice;
        } // сумма без скидки
        private static double CountDiscountPrice(int totalPrice, int discount)
        {
            double discountPrice = Convert.ToDouble(totalPrice) * (1 - (Convert.ToDouble(discount) / 100));
            return Math.Round(discountPrice, 2);
        } // сумма со скидкой
    }
}
