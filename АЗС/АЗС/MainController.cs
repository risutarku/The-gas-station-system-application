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
    public class MainController
    {

        public static void StartApplication(NetworkStation net)
        {
            Print.PrintWelcomeMessage();
            while (true)
            {
                Order myOrder = StartOrder(net);
                Cheque myCheque = myOrder.CreateCheque();
                Print.PrintCheque(myCheque);
                if (ConfirmOrder() == "1")
                {
                    if (RestartOrder() == "1")
                        continue;
                    else
                    {
                        FileWorker.ChangeStationData(net.Stations, myOrder.ChosenStation.Name, myOrder.ChosenFuel.FuelTypeName, myOrder.FuelAmount);
                        FileWorker.WriteCheque(myCheque);
                        break;
                    }
                }
                else
                {
                    if (RestartOrder() == "1")
                        continue;
                    else
                        break;
                }
            }
        }

        private static Order StartOrder(NetworkStation net)
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
        private static string ConfirmOrder()
        {
            string answer = EnterInfo.EnterConfirmOrderAnswer();
            return answer;
        }
        private static string RestartOrder()
        {
            string answer = EnterInfo.EnterRestatrtOrderAnswer();
            return answer;
        }
    }
}
