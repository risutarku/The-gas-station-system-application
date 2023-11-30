using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using АЗС.BuisnessLogic;

namespace АЗС.UserInterface
{
    public class NetworkStationService
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
