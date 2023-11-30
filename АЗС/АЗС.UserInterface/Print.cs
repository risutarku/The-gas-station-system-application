using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using АЗС.BuisnessLogic;

namespace АЗС.UserInterface
{
    public class Print
    {
        public static void PrintFuelList(List<string> fuel)
        {
            string fuelMenu = "";
            Console.WriteLine("Выберите тип топлива:\n");
            foreach (string fuelItem in fuel)
            {
                fuelMenu += fuelItem;
                fuelMenu += " ";
            }
            fuelMenu.Trim();
            Console.WriteLine(fuelMenu);
            Console.WriteLine();
        }

        public static void PrintStationList(List<Station> stationList)
        {
            foreach (Station station in stationList)
                Console.WriteLine($"{station.Name}");
            Console.WriteLine();
        }

        public static void PrintInfo(Station station)
        {
            Console.WriteLine(
            "Название: {0,10}   Адрес: {1,10}", station.Name, station.Address
                );
            Console.WriteLine(
                    "{0,10} | {1,10} | {2,10}", "Топливо", "Цена, руб ", "Запасы, л"
                );
            foreach (var gas in station.GasPrice)
                Console.WriteLine(
                        "{0,10} | {1,10} | {2,10}", gas.Key, gas.Value, station.GasReserve[gas.Key]
                    );
            Console.WriteLine();
        }
        public static void PrintCheque(Cheque cheque)
        {
            Console.WriteLine(cheque.ChequeString);
        }
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

        public static void FuelAmountErrorMessage()
        {
            Console.WriteLine("Ошибка ввода!\n" +
                "Столько топлива нет на станции\n" +
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

        public static void SelectStationMessage()
        {
            Console.WriteLine("Выберите станцию\n");
        }
    }
}
