using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АЗС
{
    internal class ChangeData
    {
        public static void ChangeStationData(List<Station> stations, string selectedStationName, string myFuelType, int fuelAmount)
        {
            Station localStation = new Station();
            foreach (Station station in stations)
            {
                if (station.Name == selectedStationName)
                    station.GasReserve[myFuelType] = station.GasReserve[myFuelType] - fuelAmount;
            }
        }
    }
}
