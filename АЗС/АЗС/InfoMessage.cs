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
        public static void FileNotExistsMessage()
        {
            Console.WriteLine("\nФайла с таким именем не существует или файл заполнен некорректно");
        }
        public static void FileNameNotExistsMessage()
        {
            Console.WriteLine("\nФайла с таким именем не существует");
        }
        public static void IncorrectInputMessage()
        {
            Console.WriteLine("Неверный ввод, попробуйте снова!");
        }
        public static void AskConfirmOrderMessage()
        {
            Console.WriteLine(
                    "Вы подтверждаете ваш заказ?\n" +
                    "1-Да 2-Нет"
                );
        }
        public static void AskRestartOrderMessage()
        {
            Console.WriteLine(
                    "Вы желаете оформить заказ заново?\n" +
                    "1-Да 2-Выйти из приложения"
                );
        }
        public static void ChooseToPrintStationOrGasList()
        {
            Console.WriteLine(
                "Выберите из списка станций или из списка топлива\n" +
                "1-показать список станций 2-показать список топлива"
            );
        }
        public static void InputMessage()
        {
            Console.Write("Ввод: ");
        }
        public static void DoneOrderMessage()
        { 
            Console.WriteLine("Ваш заказ готов!");
        }
        public static void InputFuelAmountMessage()
        {
            Console.WriteLine("Введите объём топлива (в литрах)");
        }

    }
}
