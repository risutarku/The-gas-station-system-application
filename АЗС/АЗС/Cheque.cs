using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace АЗС
{
    internal class Cheque
    {
        private CurrentFuel chosenFuel;
        private Station chosenStation;
        private int fuelAmount;
        private int purchaseAmount;
        private string chequeString = "";

        public Cheque(string chequeString)
        {
            ChequeString = chequeString;
        }

        public void PrintCheque()
        {
            Console.WriteLine(ChequeString);
        }

        public void WriteCheque()
        {
            using (StreamWriter SW = new StreamWriter("./Check.txt", false))
            {
                SW.WriteLine(ChequeString);
            }
        }

        public Cheque(Order myOrder)
        {
            ChosenFuel = myOrder.ChosenFuel;
            ChosenStation = myOrder.ChosenStation;
            FuelAmount = myOrder.FuelAmount;
            PurchaseAmount = Calculations.CountTotalPrice(ChosenStation.GasPrice[ChosenFuel.FuelTypeName], FuelAmount);
        }

        public string ChequeString
        {
            get { return chequeString; }
            set { chequeString = value; }
        }

        public CurrentFuel ChosenFuel
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
