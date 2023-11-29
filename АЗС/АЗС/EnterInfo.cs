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
            Print.InputMessage();
            chosenFuel = Console.ReadLine().ToUpper().Trim();

            return chosenFuel;
        }
        public static string EnterFuelAmount()
        {
            Print.InputFuelAmountMessage();
            Print.InputMessage();
            string fuelAmount = Console.ReadLine().Trim();
            return fuelAmount;
        }
        public static string EnterStationName()
        {
            string chosenStationName;
            Print.InputMessage();
            chosenStationName = Console.ReadLine().ToUpper().Trim();

            return chosenStationName;
        }
        public static string EnterConfirmOrderAnswer()
        {
            while (true)
            {
                Print.AskConfirmOrderMessage();
                Print.InputMessage();
                string answer = Console.ReadLine();
                if (answer == "1")
                {
                    Print.DoneOrderMessage();
                    return answer;
                }
                else if (answer == "2")
                    return answer;
                else
                {
                    Print.IncorrectInputMessage();
                    continue;
                }
            }
        }
        public static string EnterRestatrtOrderAnswer()
        {
            while (true)
            {
                Print.AskRestartOrderMessage();
                Print.InputMessage();
                string answer = Console.ReadLine();
                if (answer == "1" || answer == "2")
                    return answer;
                else
                {
                    Print.IncorrectInputMessage();
                    continue;
                }
            }
        }
        public static string EnterChooseToPrintFuelOrStationListAnswer()
        {
            while (true)
            {
                Print.ChooseToPrintStationOrGasList();
                Print.InputMessage();

                string answer = Console.ReadLine();

                if (answer == "1" || answer == "2")
                    return answer;
                else
                {
                    Print.IncorrectInputMessage();
                    continue;
                }
            }
        }
    }
}
