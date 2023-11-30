using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АЗС.BuisnessLogic
{
    public class NetworkStation
    {
        public List<Station> Stations { get; set; }
        private Dictionary<int, int> Discounts { get; set; }

        public NetworkStation(List<Station> stations, Dictionary<int, int> discounts) 
        {
            Stations = stations;
            Discounts = discounts;
        }

        public Discount GetDiscountSize(int fuelAmount)
        {
            int discountSize = 0;
            foreach (KeyValuePair<int, int> kvp in Discounts)
            {
                if (fuelAmount > kvp.Key)
                    discountSize = kvp.Value;
            }
            return new Discount(discountSize);
        }
    }
}
