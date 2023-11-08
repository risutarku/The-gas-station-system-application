using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АЗС
{
    internal class NoIdea
    {
        public static string CreatePreOrderCheque(Station chosenStation, string chosenFuel, int fuelAmount, Dictionary<int, int> discounts)
        {
            int priceOfSelectedStation = chosenStation.gasPrice[chosenFuel];
            int totalPrice = Calculations.CountTotalPrice(priceOfSelectedStation, fuelAmount);
            int discount = GetClass.GetDiscount(discounts, fuelAmount);
            double finalPriceWithDiscount = Calculations.CountDiscountPrice(totalPrice, discount);
            double discountAmount = Calculations.CountDiscount(totalPrice, finalPriceWithDiscount);
            string cheque = "";
            cheque += $"Ваш заказ\n" +
                $"АЗС: {chosenStation.name}, ул. {chosenStation.address}\n" +
                $"{chosenFuel}   {chosenStation.gasPrice[chosenFuel]}р X {fuelAmount}л = {totalPrice}р\n" +
                $"Скидка составила: {discountAmount}р ({discount}%)\n" +
                $"Итого: {finalPriceWithDiscount}р";
            return cheque;
        }
        public static void CreateCheque(Station chosenStation, string myFuelType, int fuelAmount, Dictionary<int, int> discounts)
        {
            string text = NoIdea.CreatePreOrderCheque(chosenStation, myFuelType, fuelAmount, discounts);
            FileWork.WriteCheque(text);
        }
    }
}
