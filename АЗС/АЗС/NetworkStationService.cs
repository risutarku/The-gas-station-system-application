using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АЗС
{
    internal class NetworkStationService
    {
        public static Station SelectStation(NetworkStation net)
        {
            Print.SelectStationMessage(); 
            Print.PrintStationList(net.Stations);
            string chosenStationName;
            while (true)
            {
                chosenStationName = EnterInfo.EnterStationName();

                if (Verification.IsStationNameInStationList(net.Stations, chosenStationName))
                {
                    return Verification.FindStationByStationName(net.Stations, chosenStationName);
                }
                else
                {
                    Print.IncorrectStationInputErrorMessage();
                    continue;
                }
            }
        }
    }
}
