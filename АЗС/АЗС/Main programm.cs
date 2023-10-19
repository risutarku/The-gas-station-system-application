using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Collections.Generic;
using АЗС;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using System.Reflection;

internal class Program
{
    public static void ShowFuelList(List<string> fuel) //вывод списка топлива // done
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
    public static string GetFuelType(List<string> fuel) // done 
    {
        string chosenFuel;
        while (true)
        {
            ShowFuelList(fuel);
            chosenFuel = EnterFuelType();

            if (!(fuel.Contains(chosenFuel)))
            {
                IncorrectFuelInputErrorMessage();
                continue;
            }
            else
                return chosenFuel;
        }

        static string EnterFuelType()
        {
            string chosenFuel;
            Console.Write("Ввод: ");
            chosenFuel = Console.ReadLine().ToUpper().Trim();

            return chosenFuel;
        }

        static void IncorrectFuelInputErrorMessage()
        {
            Console.WriteLine();
            Console.WriteLine(
                    "Выбранного типа топлива нет в списке! \n" +
                    "Попробуйте снова \n"
                );
        }
    }
    static string EnterFuelAmount()
    {
        Console.WriteLine("Введите объём топлива (в литрах)");
        Console.Write("Ввод: ");
        string fuelAmount = Console.ReadLine().Trim();
        return fuelAmount;
    }
    public static int GetFuelAmount() // ввод литров топлива // done
    {
        

        static int CheckCorrectInput(string inputFuelAmount)
        {
            if (int.TryParse(inputFuelAmount, out int fuelAmount))
            {
                Console.WriteLine("Вы ввели {0}л", fuelAmount);
                return fuelAmount;
            }
            else
                return 0;
        }

        static void IncorrectFuelAmountInpurErrorMessage()
        {
            Console.WriteLine("Некорректный ввод, введите целое положительное число");
        }

        while (true)
        {
            string inputFuelAmount = EnterFuelAmount();
            int fuelAmount = CheckCorrectInput(inputFuelAmount);

            if (fuelAmount == 0)
            {
                IncorrectFuelAmountInpurErrorMessage();
                continue;

            }
            else
                return fuelAmount;
        }
    }
    public static Station GetStation(List<Station> availableStations) // done 
    {
        string chosenStationName;
        while (true)
        {
            chosenStationName = EnterStationName();

            if (IsStationNameInStationList(availableStations, chosenStationName))
            {
                return FindStationByStationName(availableStations, chosenStationName);
            }
            else
            {
                IncorrectFuelInputErrorMessage();
                continue;
            }
        }

        static void IncorrectFuelInputErrorMessage()
        {
            Console.WriteLine();
            Console.WriteLine(
                    "Введенной станции нет в списке! \n" +
                    "Попробуйте снова \n"
                );
        }

        static string EnterStationName()
        {
            string chosenStationName;
            Console.Write("Ввод: ");
            chosenStationName = Console.ReadLine().ToUpper().Trim();

            return chosenStationName;
        }

        static bool IsStationNameInStationList(List<Station> availableStations, string chosenStationName)
        {
            foreach (Station station in availableStations)
            {
                if (station.name.ToUpper() == chosenStationName)
                    return true;
            }
            return false;
        }

        static Station FindStationByStationName(List<Station> availableStations, string chosenStationName)
        {
            Station tmpStation = new Station();
            foreach (Station station in availableStations)
            {
                if (station.name.ToUpper() == chosenStationName)
                    return station;
            }
            return null;
        }

    }
    public static bool IsGasAvailable(string myFuelType, int fuelAmount, Station gasStation) // проверка станции на наличие данного количества и типа топлива // done
    {
        bool availability = false;
        if (gasStation.gasPrice.ContainsKey(myFuelType))
        {
            int localFuelAmount = gasStation.gasReserve[myFuelType];
            if (localFuelAmount >= fuelAmount)
            {
                availability = true;
            }
        }
        return availability;
    }
    public static List<Station>  GetAvailableStations(List<Station> gasStations, string myFuelType, int fuelAmount) // выбор подходящий станции их всего списка станций // done
    {
        List<Station> availableStations = new List<Station>();
        foreach (var station in gasStations)
        {
            if (IsGasAvailable(myFuelType, fuelAmount, station))
            {
                availableStations.Add(station);
            }
        }
        return availableStations;
    }
    public static void PrintStationsWithPrice(string myFuelType, int fuelAmount, List<Station> availableStations) // done
    {
        Console.WriteLine($"Вот доступные заправки для ваших критериев: {myFuelType,5} {fuelAmount,5}л");
        foreach (Station station in availableStations)
        {
            Console.Write(
                    $"{station.Name}    {station.GasPrice[myFuelType]}р за 1л\n"
                );
        }
    }
    public static (Station chosenStation, string chosenFuel, int fuelAmount) OrderByGasList(List<string> allGasList, List<Station> stationList)
    {
        while (true)
        {
            string chosenFuel = GetFuelType(allGasList);
            int fuelAmount = GetFuelAmount();
            List<Station> availableStations = GetAvailableStations(stationList, chosenFuel, fuelAmount);
            if (availableStations.Count == 0)
            {
                NoAvailableStationsMessage();
                continue;
            }
            else
            {
                PrintStationsWithPrice(chosenFuel, fuelAmount, availableStations);
                Station chosenStation = GetStation(availableStations);
                return (chosenStation, chosenFuel, fuelAmount);
            }

            static void NoAvailableStationsMessage()
            {
                Console.WriteLine(
                        "По вашим критериям не удалось найти подходящие заправки\n" +
                        "Попробуйуте указать другой тип или объем топлива"
                    );
            }
        }
    }
    public static (Station chosenStation, string chosenFuel, int fuelAmount) OrderByStationList(List<Station> stationList)
    {
        Station chosenStation = GetGasStation(stationList);
        chosenStation.PrintInfo();
        string chosenFuel = GetFuelType(chosenStation.gas);
        int fuelAmount = GetFuelAmount();

        while (true)
        {
            if (!IsFuelAmountAvailableOnSelectedStationAndFuelType(chosenStation, chosenFuel, fuelAmount))
            {
                FuelAmountErrorMessage();
                fuelAmount = GetFuelAmount();
            }
            else
                return (chosenStation, chosenFuel, fuelAmount);
        }

        static bool IsFuelAmountAvailableOnSelectedStationAndFuelType(Station chosenStation, string chosenFuel, int fuelAmount)
        {
            if (chosenStation.gasReserve[chosenFuel] < fuelAmount)
                return false;
            else
                return true;
        }

        static void FuelAmountErrorMessage()
        {
            Console.WriteLine("Ошибка ввода!" +
                "Столько топлива нет на станции" +
                "Попробуйте снова");
        }
    }
    public static void PrintPreOrderCheque((Station chosenStation, string chosenFuel, int fuelAmount) purchaseInformation, Dictionary<int, int> discounts)
    {
        Station chosenStation = purchaseInformation.Item1;
        string chosenFuel = purchaseInformation.Item2;
        int fuelAmount = purchaseInformation.Item3;
        int priceOfSelectedStation = chosenStation.gasPrice[chosenFuel];
        int totalPrice = CountTotalPrice(priceOfSelectedStation, fuelAmount);
        int discount = GetDiscount(discounts, fuelAmount);
        double finalPriceWithDiscount = CountDiscountPrice(totalPrice, discount); // итоговая сумма со скидкой скидки

        Console.WriteLine(CreatePreOrderCheque(chosenStation, chosenFuel, fuelAmount, discounts));

        static string CreatePreOrderCheque(Station chosenStation, string chosenFuel, int fuelAmount, Dictionary<int, int> discounts)
        {
            int priceOfSelectedStation = chosenStation.gasPrice[chosenFuel];
            int totalPrice = CountTotalPrice(priceOfSelectedStation, fuelAmount);
            int discount = GetDiscount(discounts, fuelAmount);
            double finalPriceWithDiscount = CountDiscountPrice(totalPrice, discount);
            double discountAmount = CountDiscount(totalPrice, finalPriceWithDiscount);
            string cheque = "";
            cheque += $"Ваш заказ\n" +
                $"АЗС: {chosenStation.name}, ул. {chosenStation.address}\n" +
                $"{chosenFuel}   {chosenStation.gasPrice[chosenFuel]}р X {fuelAmount}л = {totalPrice}р\n" +
                $"Скидка составила: {discountAmount}р ({discount}%)\n" +
                $"Итого: {finalPriceWithDiscount}р";
            return cheque;
        }

        static double CountDiscount(int totalPriceWithoutDiscount, double finalPriceWithDiscount)
        {
            return Math.Round((totalPriceWithoutDiscount - finalPriceWithDiscount), 2);
        } //сумма скидки

        static int CountTotalPrice(int priceOfSelectedFuelOnStation, int fuelAmount) 
        {
            int totalPrice = priceOfSelectedFuelOnStation * fuelAmount;
            return totalPrice;
        } // сумма без скидки

        static double CountDiscountPrice(int totalPrice, int discount)
        {
            double discountPrice = Convert.ToDouble(totalPrice) * (1 - (Convert.ToDouble(discount) / 100));
            return discountPrice;
        } // сумма со скидкой

        static int GetDiscount(Dictionary<int, int> discounts, int fuelAmount)
        {
            int discount = 0;
            foreach (KeyValuePair<int, int> kvp in discounts)
            {
                if (fuelAmount > kvp.Key)
                    discount = kvp.Value;
            }
            return discount;
        }
    }
    public static void foo(List<string> allGasList, List<Station> stationList, Dictionary<int, int> discounts)
    {
        while (true)
        {
            if (ChooseToPrintFuelOrStationList() == "2")
            {
                (Station chosenStation, string chosenFuel, int fuelAmount) orderInfo = OrderByGasList(allGasList, stationList);
                PrintPreOrderCheque(orderInfo, discounts);
                if (ConfirmOrder() == "1")
                {
                    string path = @"D:\vitek\C#\Технология программирования\АЗС\чек.txt";
                    Console.WriteLine("Ваш заказ готов!");
                    if (RestartOrder() == "1")
                        continue;
                    else
                    {
                        ChangeStationData(stationList, orderInfo.Item1.name, orderInfo.Item2, orderInfo.Item3);
                        CreateCheck(orderInfo.Item1, orderInfo.Item2, orderInfo.Item3, discounts);
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
            else
            {
                (Station chosenStation, string chosenFuel, int fuelAmount) orderInfo = OrderByStationList(stationList);
                PrintPreOrderCheque(orderInfo, discounts);
                if (ConfirmOrder() == "1")
                {
                    string path = @"D:\vitek\C#\Технология программирования\АЗС\чек.txt";
                    Console.WriteLine("Ваш заказ готов!");
                    if (RestartOrder() == "1")
                        continue;
                    else
                    {
                        ChangeStationData(stationList, orderInfo.Item1.name, orderInfo.Item2, orderInfo.Item3);
                        CreateCheck(orderInfo.Item1, orderInfo.Item2, orderInfo.Item3, discounts);
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
    }
    public static string ConfirmOrder()
    {
        string answer = GetAnswer();
        return answer;

        static string GetAnswer()
        {
            while (true)
            {
                Console.WriteLine(
                        "Вы подтверждаете ваш заказ?\n" +
                        "1-Да 2-Нет"
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
    }
    public static string RestartOrder()
    {
        string answer = GetAnswer();
        return answer;

        static string GetAnswer()
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
    }
    public static void ChangeStationData(List<Station> stations, string selectedStationName, string myFuelType, int fuelAmount)
    {
        Station localStation = new Station();
        foreach (Station station in stations)
        {
            if (station.name == selectedStationName)
                station.gasReserve[myFuelType] = station.gasReserve[myFuelType] - fuelAmount;
        }
    }
    public static string ChooseToPrintFuelOrStationList()
    {
        string answer = GetAnswer();
        return answer;

        static string GetAnswer()
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
    public static void PrintStationList(List<Station> stationList)
    {
        int counter = 0;
        foreach (Station station in stationList)
            Console.WriteLine($"{station.name}");
        Console.WriteLine();
    }
    public static int CheckStationInStatlionList(List<Station> stationList, string selectedStationName)
    {
        foreach (Station station in stationList)
            if (station.name.ToUpper() == selectedStationName.ToUpper())
                return 1;
        return 2;
    }
    public static Station GetGasStationByName(List<Station> stationList, string stationName)
    {
        Station tempStation = new Station();
        foreach (Station station in stationList)
            if (station.name.ToUpper() == stationName)//найти станцию ?
                tempStation = station;
        return tempStation;
    }
    public static Station GetGasStation(List<Station> stationList)
    {
        string selectedStationName;

        while (true)
        {
            PrintStationList(stationList);
            selectedStationName = EnterStationName();
            if (CheckStationInStatlionList(stationList, selectedStationName) == 1)
                return GetGasStationByName(stationList, selectedStationName);
            else
                ErrorMessage();
                continue;
        }

        static void ErrorMessage()
        {
            Console.WriteLine("Данной станции нет в списке, проверьте ввод и попробуйте снова");
        }

        static string EnterStationName()
        {
            string selectedStationName;
            Console.WriteLine("Выберите одну из станций выше ");
            Console.Write("Ввод: ");
            selectedStationName = Console.ReadLine().ToUpper().Trim();
            return selectedStationName;
        }

    }
    public static void CreateCheck(
            Station chosenStation, string myFuelType, int fuelAmount, Dictionary<int, int> discounts
        )
    {
        string text = CreatePreOrderCheque(chosenStation, myFuelType, fuelAmount, discounts);
        WriteCheque(text);

        static string CreatePreOrderCheque(Station chosenStation, string chosenFuel, int fuelAmount, Dictionary<int, int> discounts)
        {
            int priceOfSelectedStation = chosenStation.gasPrice[chosenFuel];
            int totalPrice = CountTotalPrice(priceOfSelectedStation, fuelAmount);
            int discount = GetDiscount(discounts, fuelAmount);
            double finalPriceWithDiscount = CountDiscountPrice(totalPrice, discount);
            double discountAmount = CountDiscount(totalPrice, finalPriceWithDiscount);
            string cheque = "";
            cheque = string.Format($"Ваш заказ\n" +
                $"АЗС: {chosenStation.name}, ул. {chosenStation.address}\n" +
                $"{chosenFuel}   {chosenStation.gasPrice[chosenFuel]}р X {fuelAmount}л = {totalPrice}р\n" +
                $"Скидка составила: {discountAmount}р ({discount}%)\n" +
                $"Итого: {finalPriceWithDiscount}р");
            return cheque;
        }

        static double CountDiscount(int totalPriceWithoutDiscount, double finalPriceWithDiscount)
        {
            return Math.Round((totalPriceWithoutDiscount - finalPriceWithDiscount), 2);
        } //сумма скидки

        static int CountTotalPrice(int priceOfSelectedFuelOnStation, int fuelAmount)
        {
            int totalPrice = priceOfSelectedFuelOnStation * fuelAmount;
            return totalPrice;
        } // сумма без скидки

        static double CountDiscountPrice(int totalPrice, int discount)
        {
            double discountPrice = Convert.ToDouble(totalPrice) * (1 - (Convert.ToDouble(discount) / 100));
            return discountPrice;
        } // сумма со скидкой

        static int GetDiscount(Dictionary<int, int> discounts, int fuelAmount)
        {
            int discount = 0;
            foreach (KeyValuePair<int, int> kvp in discounts)
            {
                if (fuelAmount > kvp.Key)
                    discount = kvp.Value;
            }
            return discount;
        }

        static void WriteCheque(string text)
        {

            using (StreamWriter SW = new StreamWriter("./Check.txt", false))
            {
                SW.WriteLine(text);
            }
        }
    }
    private static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("\nФайла с таким именем не существует или файл заполнен некорректно");
            return;
        }

        string stationsFilePath = args[0];
        if (!File.Exists(stationsFilePath))
        {
            Console.WriteLine("\nФайла с таким именем не существует");
            return;
        }

        string gasTypesFilePath = args[1];
        if (!File.Exists(gasTypesFilePath))
        {
            Console.WriteLine("\nФайла с таким именем не существует");
            return;
        }
        string[] allGasTypesTextFile = File.ReadAllLines(gasTypesFilePath);
        string[] TextFile = File.ReadAllLines(stationsFilePath);

        (List<string> allGasList, Dictionary<int, int> discounts) allGasTypesAndDiscounts = ReadGasInfo(allGasTypesTextFile);

        List<Station> stationList = ReadStationsInfo(TextFile);

        static (List<string>, Dictionary<int, int> ) ReadGasInfo(string[] allGasTypesTextFile)
        {
            int counterGasTypes = 0;
            List<string> allGasList = new List<string>();
            Dictionary<int, int> discounts = new Dictionary<int, int>();

            for (int i = 0; i < allGasTypesTextFile.Length; i++)
            {
                if (allGasTypesTextFile[i] == "")
                {
                    counterGasTypes++;
                    continue;
                }
                else if (counterGasTypes == 0)
                {
                    string[] tempAllGasTypes = allGasTypesTextFile[i].Split(";");
                    for (int j = 0; j < tempAllGasTypes.Length; j++)
                        allGasList.Add(tempAllGasTypes[j]);
                }
                else if (counterGasTypes == 1)
                {
                    string[] tempDiscount = allGasTypesTextFile[i].Split(";");
                    discounts.Add(Convert.ToInt32(tempDiscount[0]), Convert.ToInt32(tempDiscount[1]));
                }
            }
            return (allGasList, discounts);
        }

        static List<Station> ReadStationsInfo(string[] TextFile)
        {
            int counter = 0;
            string[] nameAddress = new string[] { };
            List<string> localStationGasList = new List<string>();
            Dictionary<string, int> gasPrice = new Dictionary<string, int>();
            Dictionary<string, int> gasAmount = new Dictionary<string, int>();
            List<Station> stationList = new List<Station>();

            for (int i = 0; i < TextFile.Length; i++)
            {
                if (TextFile[i] != "-|-")
                {
                    if (TextFile[i] == "")
                    {
                        counter++;
                        continue;
                    }
                    else if (counter == 0)
                    {
                        nameAddress = TextFile[i].Split(";");
                    }
                    else if (counter == 1)
                    {
                        string[] gas = TextFile[i].Split(";");
                        for (int j = 0; j < gas.Length; j++)
                            localStationGasList.Add(gas[j]);

                    }
                    else if (counter == 2)
                    {
                        string[] tempFuelPrice = TextFile[i].Split(";");
                        gasPrice.Add(tempFuelPrice[0], Convert.ToInt32(tempFuelPrice[1]));
                    }
                    else if (counter == 3)
                    {
                        string[] tempFuelAmount = TextFile[i].Split(";");
                        gasAmount.Add(tempFuelAmount[0], Convert.ToInt32(tempFuelAmount[1]));
                    }
                }
                else
                {
                    counter = 0;
                    stationList.Add(Station.Create(nameAddress, localStationGasList, gasPrice, gasAmount));
                    nameAddress = new string[] { };
                    localStationGasList = new List<string>();
                    gasPrice = new Dictionary<string, int>();
                    gasAmount = new Dictionary<string, int>();
                }
            }
            return stationList;
        }

        static void PrintWelcomeMessage()
        {
            Console.WriteLine("Добро пожаловать в Гортопливо!");
            Console.WriteLine();
            Console.WriteLine("В данной системе вы можете оформить заказ топлива в одной из АЗС города!");
            Console.WriteLine();
        }

        PrintWelcomeMessage();
        foo(allGasTypesAndDiscounts.Item1, stationList, allGasTypesAndDiscounts.Item2);
    }



}