using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace АЗС
{
    internal class Station
    {
        private string name;
        private string address;
        private List<string> gas = new List<string>();
        private Dictionary<string, int> gasPrice = new Dictionary<string, int>();
        private Dictionary<string, int> gasReserve = new Dictionary<string, int>();

        /*
        public static Station Create
            (
                string[] stationNameAddress, List<string> gasList,
                Dictionary<string, int> gasPrice, Dictionary<string, int> gasAmount
            )
        {
            return new Station
            {
                Name = stationNameAddress[0],
                Address = stationNameAddress[1],
                Gas = gasList,
                GasPrice = gasPrice,
                GasReserve = gasAmount
            };
        }*/

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

        public Station()
        {

        }

        public string Name
        { 
            get { return name; } 
            set { name = value; }
        }

        public string Address
        {
            get { return address; } 
            set { address = value; }
        }
        
        public List<string> Gas
        {
            get { return gas; } 
            set { gas = value; }
        }

        public Dictionary<string, int> GasPrice
        {
            get { return gasPrice; } 
            set { gasPrice = value; }
        }

        public Dictionary<string, int> GasReserve
        {
            get { return gasReserve; }
            set { gasReserve = value; }
        }

        public void PrintInfo()
        {   
            Console.WriteLine(
                    "Название: {0,10}   Адрес: {1,10}", name, address
                );
            Console.WriteLine(
                    "{0,10} | {1,10} | {2,10}","Топливо", "Цена, руб ", "Запасы, л"
                );
            foreach (var gas in gasPrice)
                Console.WriteLine(
                        "{0,10} | {1,10} | {2,10}", gas.Key, gas.Value, gasReserve[gas.Key]
                    );
            Console.WriteLine();
        }
    }
}
