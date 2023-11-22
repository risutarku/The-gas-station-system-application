using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АЗС
{
    internal class SomeProcess
    {

        public static void Process(NetworkStation net)
        {
            InfoMessage.PrintWelcomeMessage();
            while (true)
            {
                Order myOrder = NewProcess(net);
                Cheque myCheque = myOrder.CreateCheque();
                ChequeService.PrintCheque(myCheque);
                if (SomeProcess.ConfirmOrder() == "1")
                {
                    if (SomeProcess.RestartOrder() == "1")
                        continue;
                    else
                    {
                        FileWork.ChangeStationData(net.Stations, myOrder.ChosenStation.Name, myOrder.ChosenFuel.FuelTypeName, myOrder.FuelAmount);
                        ChequeService.WriteCheque(myCheque);
                        break;
                    }
                }
                else
                {
                    if (SomeProcess.RestartOrder() == "1")
                        continue;
                    else
                        break;
                }

            }
        }

        public static Order NewProcess(NetworkStation net)
        {
            SomeProcess.ChooseToPrintFuelOrStationList();
            Print.PrintStationList(net.Stations);
            Station chosenStation = NetworkStationService.SelectStation(net);
            chosenStation.PrintInfo();
            CurrentFuel chosenFuel = StationService.SelectFuel(chosenStation);
            int fuelAmount = StationService.ChooseFuelAmount(chosenFuel);
            Discount discount = NetworkStationService.GetDiscountSize(net, fuelAmount);

            while (true)
            {
                if (!Check.IsFuelAmountAvailableOnSelectedStationAndFuelType(chosenStation, chosenFuel.FuelTypeName, fuelAmount))
                {
                    InfoMessage.FuelAmountErrorMessage();
                    fuelAmount = StationService.ChooseFuelAmount(chosenFuel);
                    discount = NetworkStationService.GetDiscountSize(net, fuelAmount);
                }
                else
                {
                    return chosenStation.MakeOrder(chosenFuel, fuelAmount, discount);
                }
            }
        }
        
        public static string ChooseToPrintFuelOrStationList()
        {
            string answer = EnterInfo.EnterChooseToPrintFuelOrStationListAnswer();
            return answer;
        }
        public static string ConfirmOrder()
        {
            string answer = EnterInfo.EnterConfirmOrderAnswer();
            return answer;
        }
        public static string RestartOrder()
        {
            string answer = EnterInfo.EnterRestatrtOrderAnswer();
            return answer;
        }
    }
}
