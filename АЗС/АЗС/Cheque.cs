using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АЗС
{
    internal class Cheque
    {
        private Fuel chosenFuel;
        private Station chosenStation;
        private int fuelAmount;
        private int purchaseAmount;
        //private int discount;
        //private double discountSize;
        //private double purchaseAmountWithDiscount;

        public Cheque(Fuel chosenFuel, Station chosenStation, int fuelAmount)
        {
            ChosenFuel = chosenFuel;
            ChosenStation = chosenStation;
            FuelAmount = fuelAmount;
            PurchaseAmount = Calculations.CountTotalPrice(chosenStation.GasPrice[chosenFuel.FuelTypeName], fuelAmount);
        }
        public Fuel ChosenFuel
        {
            get { return chosenFuel; }
            set { chosenFuel = value; }
        }
        public Station ChosenStation
        {
            get { return ChosenStation; }
            set { ChosenStation = value; }
        }
        public int FuelAmount
        {
            get { return FuelAmount; }
            set { FuelAmount = value; }
        }
        public int PurchaseAmount
        {
            get { return PurchaseAmount; }
            set { PurchaseAmount = value; }
        }
        public int Discount
        {
            get { return Discount; }
            set { Discount = value; }
        }
        public double DiscountSize
        {
            get { return DiscountSize; }
            set { DiscountSize = value; }
        }
        public double PurchaseAmountWithDiscount
        {
            get { return PurchaseAmountWithDiscount; }
            set { PurchaseAmountWithDiscount = value; }
        }
    }
}
