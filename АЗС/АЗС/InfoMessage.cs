using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АЗС
{
    internal class InfoMessage
    {
        public static void IncorrectFuelInputErrorMessage()
        {
            Console.WriteLine();
            Console.WriteLine(
                    "Выбранного типа топлива нет в списке! \n" +
                    "Попробуйте снова \n"
                );
        }
        public static void IncorrectFuelAmountInpurErrorMessage()
        {
            Console.WriteLine("Некорректный ввод, введите целое положительное число");
        }
        public static void IncorrectStationInputErrorMessage()
        {
            Console.WriteLine();
            Console.WriteLine(
                    "Введенной станции нет в списке! \n" +
                    "Попробуйте снова \n"
                );
        }
        public static void PrintWelcomeMessage()
        {
            Console.WriteLine("Добро пожаловать в Гортопливо!");
            Console.WriteLine();
            Console.WriteLine("В данной системе вы можете оформить заказ топлива в одной из АЗС города!");
            Console.WriteLine();
        }
        public static void NoAvailableStationsMessage()
        {
            Console.WriteLine(
                    "По вашим критериям не удалось найти подходящие заправки\n" +
                    "Попробуйуте указать другой тип или объем топлива"
                );
        }

        public static void FuelAmountErrorMessage()
        {
            Console.WriteLine("Ошибка ввода!" +
                "Столько топлива нет на станции" +
                "Попробуйте снова");
        }
    }
}
