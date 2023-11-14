using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АЗС
{
    internal class NetworkStations
    {
        private List<Station> stations = new List<Station>();
        private Dictionary<int, int> discounts = new Dictionary<int, int>();

        public NetworkStations(List<Station> stations, Dictionary<int, int> discounts) 
        {
            Stations = stations;
            Discounts = discounts;
        }

        public List<Station> Stations
        {
            get { return stations; }
            set { stations = value; }
        }
        public Dictionary<int, int> Discounts
        {
            get { return discounts; }
            set { discounts = value; }
        }
        
        public  Station SelectStation()
        {
            string chosenStationName;
            while (true)
            {
                chosenStationName = EnterInfo.EnterStationName();

                if (Check.IsStationNameInStationList(this.Stations, chosenStationName))
                {
                    return Check.FindStationByStationName(this.Stations, chosenStationName);
                }
                else
                {
                    InfoMessage.IncorrectStationInputErrorMessage();
                    continue;
                }
            }
        }

        public static (Station chosenStation, string chosenFuel, int fuelAmount) OrderByStationList(List<Station> stationList)
        {
            Print.PrintStationList(stationList);
            Station chosenStation = GetClass.GetStation(stationList);
            chosenStation.PrintInfo();
            string chosenFuel = GetClass.GetFuelType(chosenStation.Gas);
            int fuelAmount = GetClass.GetFuelAmount();

            while (true)
            {
                if (!Check.IsFuelAmountAvailableOnSelectedStationAndFuelType(chosenStation, chosenFuel, fuelAmount))
                {
                    InfoMessage.FuelAmountErrorMessage();
                    fuelAmount = GetClass.GetFuelAmount();
                }
                else
                {
                    return (chosenStation, chosenFuel, fuelAmount);
                }
            }

        }
    }
}
