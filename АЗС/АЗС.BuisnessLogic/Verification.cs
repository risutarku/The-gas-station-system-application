using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace АЗС.BuisnessLogic
{
    public class Verification
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
                if (station.Name.ToUpper() == chosenStationName.ToUpper())
                    return true;
            }
            return false;
        }
        public static Station FindStationByStationName(List<Station> availableStations, string chosenStationName)
        {
            foreach (Station station in availableStations)
            {
                if (station.Name.ToUpper() == chosenStationName.ToUpper())
                    return station;
            }
            return null;
        }
        public static bool IsFuelAmountAvailableOnSelectedStationAndFuelType(Station chosenStation, string chosenFuel, int fuelAmount)
        {
            if (!(chosenStation.Gas.Contains(chosenFuel)))
                return false;
            
            if (chosenStation.GasReserve[chosenFuel] >= fuelAmount && fuelAmount > 0)
                return true;
            else
                return false;
        }
    }
}
