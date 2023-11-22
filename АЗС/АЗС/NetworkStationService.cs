using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АЗС
{
    internal class NetworkStationService
    {
        public static Discount GetDiscountSize(NetworkStation net, int fuelAmount)
        {
            int discountSize = 0;
            foreach (KeyValuePair<int, int> kvp in net.Discounts)
            {
                if (fuelAmount > kvp.Key)
                    discountSize = kvp.Value;
            }
            return new Discount(discountSize);
        }
        public static Station SelectStation(NetworkStation net)
        {
            string chosenStationName;
            while (true)
            {
                chosenStationName = EnterInfo.EnterStationName();

                if (Check.IsStationNameInStationList(net.Stations, chosenStationName))
                {
                    return Check.FindStationByStationName(net.Stations, chosenStationName);
                }
                else
                {
                    InfoMessage.IncorrectStationInputErrorMessage();
                    continue;
                }
            }
        }
    }
}
