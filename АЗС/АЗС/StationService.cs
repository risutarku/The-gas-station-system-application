using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АЗС
{
    internal class StationService
    {

        public static CurrentFuel SelectFuel(Station station)
        {
            string chosenFuel;
            while (true)
            {
                Print.PrintFuelList(station.Gas);
                chosenFuel = EnterInfo.EnterFuelType();

                if (!(station.Gas.Contains(chosenFuel)))
                {
                    Print.IncorrectFuelInputErrorMessage();
                    continue;
                }
                else
                    return new CurrentFuel(chosenFuel);
            }
        }

        public static int ChooseFuelAmount(CurrentFuel chosenFuel)
        {
            while (true)
            {
                string inputFuelAmount = EnterInfo.EnterFuelAmount();
                int fuelAmount = Verification.CheckCorrectInput(inputFuelAmount);

                if (fuelAmount == 0)
                {
                    Print.IncorrectFuelAmountInpurErrorMessage();
                    continue;

                }
                else
                    return fuelAmount;
            }
        }
    }
}
