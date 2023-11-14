using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace АЗС
{
    internal class Order
    {
        private CurrentFuel chosenFuel;
        private Station chosenStation;
        private int fuelAmount;
        private int discountSize;

        public Order(Station chosenStation, CurrentFuel chosenFuel, int fuelAmount, Discount discount)
        {
            ChosenStation = chosenStation;
            ChosenFuel = chosenFuel;
            FuelAmount = fuelAmount;
            DiscountSize = discount.DiscountSize;
        }

        public Cheque CreateCheque()
        {
            int totalPrice = Calculations.CountTotalPrice(ChosenStation.GasPrice[ChosenFuel.FuelTypeName], FuelAmount);
            double finalPriceWithDiscount = Calculations.CountDiscountPrice(totalPrice, DiscountSize);
            double discountAmount = Calculations.CountDiscount(totalPrice, finalPriceWithDiscount);
            string cheque = "";
            cheque += $"Ваш заказ\n" +
                $"АЗС: {ChosenStation.Name}, ул. {ChosenStation.Address}\n" +
                $"{ChosenFuel.FuelTypeName}   {ChosenStation.GasPrice[ChosenFuel.FuelTypeName]}р X {FuelAmount}л = {totalPrice}р\n" +
                $"Скидка составила: {discountAmount}р ({DiscountSize}%)\n" +
                $"Итого: {finalPriceWithDiscount}р";
            return new Cheque(cheque);
        }


        public int DiscountSize
        {
            get { return discountSize; }
            set { discountSize = value; }
        }

        public CurrentFuel ChosenFuel
        {
            get { return chosenFuel; } 
            set { chosenFuel = value; }
        }
        public Station ChosenStation
        {
            get { return chosenStation; }
            set { chosenStation = value; }
        }
        public int FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }
    }
}
