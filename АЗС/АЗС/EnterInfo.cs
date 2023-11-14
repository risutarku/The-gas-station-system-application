using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АЗС
{
    internal class EnterInfo
    {
        public static string EnterFuelType()
        {
            string chosenFuel;
            InfoMessage.InputMessage();
            chosenFuel = Console.ReadLine().ToUpper().Trim();

            return chosenFuel;
        }
        public static string EnterFuelAmount()
        {
            InfoMessage.InputFuelAmountMessage();
            InfoMessage.InputMessage();
            string fuelAmount = Console.ReadLine().Trim();
            return fuelAmount;
        }
        public static string EnterStationName()
        {
            string chosenStationName;
            InfoMessage.InputMessage();
            chosenStationName = Console.ReadLine().ToUpper().Trim();

            return chosenStationName;
        }
        public static string EnterConfirmOrderAnswer()
        {
            while (true)
            {
                InfoMessage.AskConfirmOrderMessage();
                InfoMessage.InputMessage();
                string answer = Console.ReadLine();
                if (answer == "1")
                {
                    InfoMessage.DoneOrderMessage();
                    return answer;
                }
                else if (answer == "2")
                    return answer;
                else
                {
                    InfoMessage.IncorrectInputMessage();
                    continue;
                }
            }
        }
        public static string EnterRestatrtOrderAnswer()
        {
            while (true)
            {
                InfoMessage.AskRestartOrderMessage();
                InfoMessage.InputMessage();
                string answer = Console.ReadLine();
                if (answer == "1" || answer == "2")
                    return answer;
                else
                {
                    InfoMessage.IncorrectInputMessage();
                    continue;
                }
            }
        }
        public static string EnterChooseToPrintFuelOrStationListAnswer()
        {
            while (true)
            {
                InfoMessage.ChooseToPrintStationOrGasList();
                InfoMessage.InputMessage();

                string answer = Console.ReadLine();

                if (answer == "1" || answer == "2")
                    return answer;
                else
                {
                    InfoMessage.IncorrectInputMessage();
                    continue;
                }
            }
        }
    }
}
