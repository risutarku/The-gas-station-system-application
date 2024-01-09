using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace АЗС.BuisnessLogic
{
    public class Station
    {
        public string Name { get; }
        public string Address { get; set; }
        public List<string> Gas { get; set; }
        public Dictionary<string, int> GasPrice { get; set; }
        public Dictionary<string, int> GasReserve { get; set; }

        public Order MakeOrder(CurrentFuel chosenFeul, int fuelAmount, Discount discount)
        {
            return new Order(this ,chosenFeul, fuelAmount, discount);
        }

        public Station(
                string[] stationNameAddress, List<string> gasList,
                Dictionary<string, int> gasPrice, Dictionary<string, int> gasAmount
            )
        {
            Name = stationNameAddress[0];
            Address = stationNameAddress[1];
            Gas = gasList;
            GasPrice = gasPrice;
            GasReserve = gasAmount;
        }

    }
}
