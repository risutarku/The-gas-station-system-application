using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АЗС
{
    internal class Order
    {
        private Fuel chosenFuel;
        private Station chosenStation;
        private int fuelAmount;

        public Order(Station chosenStation, Fuel chosenFuel, int fuelAmount)
        {
            ChosenStation = chosenStation;
            ChosenFuel = chosenFuel;
            FuelAmount = fuelAmount;
        }

        

        public Fuel ChosenFuel
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
