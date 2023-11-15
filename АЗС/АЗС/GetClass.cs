using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АЗС
{
    internal class GetClass
    {
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
    }
}
