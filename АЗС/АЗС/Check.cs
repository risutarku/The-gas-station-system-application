using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АЗС
{
    internal class Check
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
        public static bool IsGasAvailable(string myFuelType, int fuelAmount, Station gasStation) // проверка станции на наличие данного количества и типа топлива // done
        {
            bool availability = false;
            if (gasStation.gasPrice.ContainsKey(myFuelType))
            {
                int localFuelAmount = gasStation.gasReserve[myFuelType];
                if (localFuelAmount >= fuelAmount)
                {
                    availability = true;
                }
            }
            return availability;
        }
        public static bool IsStationNameInStationList(List<Station> availableStations, string chosenStationName)
        {
            foreach (Station station in availableStations)
            {
                if (station.name.ToUpper() == chosenStationName)
                    return true;
            }
            return false;
        }
        public static Station FindStationByStationName(List<Station> availableStations, string chosenStationName)
        {
            Station tmpStation = new Station();
            foreach (Station station in availableStations)
            {
                if (station.name.ToUpper() == chosenStationName)
                    return station;
            }
            return null;
        }
        public static bool IsFuelAmountAvailableOnSelectedStationAndFuelType(Station chosenStation, string chosenFuel, int fuelAmount)
        {
            if (chosenStation.gasReserve[chosenFuel] < fuelAmount)
                return false;
            else
                return true;
        }
    }
}
