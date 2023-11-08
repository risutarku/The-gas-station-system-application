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
            Console.Write("Ввод: ");
            chosenFuel = Console.ReadLine().ToUpper().Trim();

            return chosenFuel;
        }
        public static string EnterFuelAmount()
        {
            Console.WriteLine("Введите объём топлива (в литрах)");
            Console.Write("Ввод: ");
            string fuelAmount = Console.ReadLine().Trim();
            return fuelAmount;
        }
        public static string EnterStationName()
        {
            string chosenStationName;
            Console.Write("Ввод: ");
            chosenStationName = Console.ReadLine().ToUpper().Trim();

            return chosenStationName;
        }
        public static string EnterConfirmOrderAnswer()
        {
            while (true)
            {
                Console.WriteLine(
                        "Вы подтверждаете ваш заказ?\n" +
                        "1-Да 2-Нет"
                    );
                Console.Write("Ввод: ");
                string answer = Console.ReadLine();
                if (answer == "1")
                {
                    Console.WriteLine("Ваш заказ готов!");
                    return answer;
                }
                else if (answer == "2")
                    return answer;
                else
                {
                    Console.WriteLine("Неверный ввод, попробуйте снова!");
                    continue;
                }
            }
        }
        public static string EnterRestatrtOrderAnswer()
        {
            while (true)
            {
                Console.WriteLine(
                        "Вы желаете оформить заказ заново?\n" +
                        "1-Да 2-Выйти из приложения"
                    );
                Console.Write("Ввод: ");
                string answer = Console.ReadLine();
                if (answer == "1" || answer == "2")
                    return answer;
                else
                {
                    Console.WriteLine("Неверный ввод, попробуйте снова!");
                    continue;
                }
            }
        }
        public static string EnterChooseToPrintFuelOrStationListAnswer()
        {
            while (true)
            {
                Console.WriteLine(
                    "Выберите из списка станций или из списка топлива\n" +
                    "1-показать список станций 2-показать список топлива"
                );
                Console.Write("Ввод: ");

                string answer = Console.ReadLine();

                if (answer == "1" || answer == "2")
                    return answer;
                else
                {
                    Console.WriteLine("Неправильный ввод попробуйте снова");
                    continue;
                }
            }
        }
    }
}
