using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АЗС
{
    internal class NetworkStation
    {
        private List<Station> stations = new List<Station>();
        private Dictionary<int, int> discounts = new Dictionary<int, int>();

        public NetworkStation(List<Station> stations, Dictionary<int, int> discounts) 
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
    }
}
