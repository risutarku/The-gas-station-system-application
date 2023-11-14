using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АЗС
{
    internal class GetClass
    {
        public static string GetFuelType(List<string> fuel) // done 
        {
            string chosenFuel;
            while (true)
            {
                Print.ShowFuelList(fuel);
                chosenFuel = EnterInfo.EnterFuelType();

                if (!(fuel.Contains(chosenFuel)))
                {
                    InfoMessage.IncorrectFuelInputErrorMessage();
                    continue;
                }
                else
                    return chosenFuel;
            }


        }
        public static int GetFuelAmount() // ввод литров топлива // done
        {
            while (true)
            {
                string inputFuelAmount = EnterInfo.EnterFuelAmount();
                int fuelAmount = Check.CheckCorrectInput(inputFuelAmount);

                if (fuelAmount == 0)
                {
                    InfoMessage.IncorrectFuelAmountInpurErrorMessage();
                    continue;

                }
                else
                    return fuelAmount;
            }
        }
        public static List<Station> GetAvailableStations(List<Station> gasStations, string myFuelType, int fuelAmount) // выбор подходящий станции их всего списка станций // done
        {
            List<Station> availableStations = new List<Station>();
            foreach (var station in gasStations)
            {
                if (Check.IsGasAvailable(myFuelType, fuelAmount, station))
                {
                    availableStations.Add(station);
                }
            }
            return availableStations;
        }
        public static Station GetStation(List<Station> availableStations)
        {
            string chosenStationName;
            while (true)
            {
                chosenStationName = EnterInfo.EnterStationName();

                if (Check.IsStationNameInStationList(availableStations, chosenStationName))
                {
                    return Check.FindStationByStationName(availableStations, chosenStationName);
                }
                else
                {
                    InfoMessage.IncorrectStationInputErrorMessage();
                    continue;
                }
            }
        }
        public static int GetDiscount(Dictionary<int, int> discounts, int fuelAmount)
        {
            int discount = 0;
            foreach (KeyValuePair<int, int> kvp in discounts)
            {
                if (fuelAmount > kvp.Key)
                    discount = kvp.Value;
            }
            return discount;
        }
    }
}
