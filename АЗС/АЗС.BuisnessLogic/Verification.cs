﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace АЗС.BuisnessLogic
{
    public class Verification
    {
        public static int CheckCorrectInput(string inputFuelAmount)//userInterface
        {
            if (int.TryParse(inputFuelAmount, out int fuelAmount))
            {
                Console.WriteLine("Вы ввели {0}л", fuelAmount);
                return fuelAmount;
            }
            else
                return 0;
        }
        public static bool IsStationNameInStationList(List<Station> availableStations, string chosenStationName)//station
        {
            foreach (Station station in availableStations)
            {
                if (station.Name.ToUpper() == chosenStationName.ToUpper())
                    return true;
            }
            return false;
        }
        public static Station FindStationByStationName(List<Station> availableStations, string chosenStationName)//station
        {
            if (IsStationNameInStationList(availableStations, chosenStationName))
            {
                return availableStations.Find(x => x.Name.ToUpper() == chosenStationName.ToUpper());
            }
            return null;
        }
        public static bool IsFuelAmountAvailableOnSelectedStationAndFuelType(Station chosenStation, string chosenFuel, int fuelAmount)//station
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
