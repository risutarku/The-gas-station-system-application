using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АЗС
{
    internal class Fuel
    {
        private string fuelTypeName;
        private int fuelAmount;
        private int fuelPrice;

        public Fuel(string fuelTypeName)
        {
            FuelTypeName= fuelTypeName;
        }

        public static Fuel SelectFuel(Station chosenStation)
        {
            string chosenFuel;
            while (true)
            {
                Print.ShowFuelList(chosenStation.Gas);
                chosenFuel = EnterInfo.EnterFuelType();

                if (!(chosenStation.Gas.Contains(chosenFuel)))
                {
                    InfoMessage.IncorrectFuelInputErrorMessage();
                    continue;
                }
                else
                    return new Fuel(chosenFuel);
            }
        }
        public string FuelTypeName
        {
            get { return fuelTypeName; }
            set { fuelTypeName = value; }
        }


    }
}
