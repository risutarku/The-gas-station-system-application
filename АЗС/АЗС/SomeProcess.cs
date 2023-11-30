using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using АЗС.UserInterface;
using АЗС.DataAccess;
using АЗС.BuisnessLogic;

namespace АЗС
{
    public class SomeProcess
    {

        public static void Process(NetworkStation net)
        {
            Print.PrintWelcomeMessage();
            while (true)
            {
                Order myOrder = NewProcess(net);
                Cheque myCheque = myOrder.CreateCheque();
                Print.PrintCheque(myCheque);
                if (SomeProcess.ConfirmOrder() == "1")
                {
                    if (SomeProcess.RestartOrder() == "1")
                        continue;
                    else
                    {
                        FileWork.ChangeStationData(net.Stations, myOrder.ChosenStation.Name, myOrder.ChosenFuel.FuelTypeName, myOrder.FuelAmount);
                        FileWork.WriteCheque(myCheque);
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
            Station chosenStation = NetworkStationService.SelectStation(net);
            Print.PrintInfo(chosenStation);
            CurrentFuel chosenFuel = StationService.SelectFuel(chosenStation);
            int fuelAmount = StationService.ChooseFuelAmount(chosenFuel);
            Discount discount = net.GetDiscountSize(fuelAmount);

            while (true)
            {
                if (!Verification.IsFuelAmountAvailableOnSelectedStationAndFuelType(chosenStation, chosenFuel.FuelTypeName, fuelAmount))
                {
                    Print.FuelAmountErrorMessage();
                    fuelAmount = StationService.ChooseFuelAmount(chosenFuel);
                    discount = net.GetDiscountSize(fuelAmount);
                }
                else
                {
                    return chosenStation.MakeOrder(chosenFuel, fuelAmount, discount);
                }
            }
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
