using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АЗС
{
    internal class Verification
    {
        public static int CheckCorrectInput(string inputFuelAmount)
        {
            if (int.TryParse(inputFuelAmount, out int fuelAmount))
            {
                Console.WriteLine("Вы ввели {0}л", fuelAmount);
                return fuelAmount;
            }
            else
                return 0;
        }
        public static bool IsStationNameInStationList(List<Station> availableStations, string chosenStationName)
        {
            foreach (Station station in availableStations)
            {
                if (station.Name.ToUpper() == chosenStationName)
                    return true;
            }
            return false;
        }
        public static Station FindStationByStationName(List<Station> availableStations, string chosenStationName)
        {
            foreach (Station station in availableStations)
            {
                if (station.Name.ToUpper() == chosenStationName)
                    return station;
            }

            return null;
        }
        public static bool IsFuelAmountAvailableOnSelectedStationAndFuelType(Station chosenStation, string chosenFuel, int fuelAmount)
        {
            if (chosenStation.GasReserve[chosenFuel] < fuelAmount)
                return false;
            else
                return true;
        }
    }
}
