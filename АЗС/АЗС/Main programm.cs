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
    public static bool IsAvailableStationsEmpty(List<Station> availableStations)
    {
        bool empty = availableStations.Count == 0;
        return empty;
    }
    public static Station PurchaseByChoosingFromTheFuelList(List<Station> gasStations, string chosenFuel1, int fuelAmount1, List<string> fuel) // процесс покупки через вывод списка топлива
    {
        ShowFuelList(fuel);
        string chosenFuel = GetFuelType(fuel);
        int fuelAmount = GetFuelAmount();
        List<Station> availableStations = GetAvailableStations(gasStations, chosenFuel, fuelAmount);

        if (availableStations.Count == 0)
        {
            NoAvailableStationsMessage();
            return null;
        }
        else
        {
            PrintStationsWithPrice(chosenFuel, fuelAmount, availableStations);
            Station chosenStation = GetStation(availableStations);
            return chosenStation;
        }

        static void NoAvailableStationsMessage()
        {
            Console.WriteLine(
                    "По вашим критериям не удалось найти подходящие заправки\n" +
                    "Попробуйуте указать другой тип или объем топлива"
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
        double finalPriceWithDiscount = CountDiscountPrice(totalPrice, discount);

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

        static double CountDiscount(int totalPrice, double finalPriceWithDiscount)
        {
            return Math.Round((totalPrice - finalPriceWithDiscount), 2);
        }

        static int CountTotalPrice(int priceOfSelectedFuelOnStation, int fuelAmount)
        {
            int totalPrice = priceOfSelectedFuelOnStation * fuelAmount;
            return totalPrice;
        }
    }

    public static void foo(List<string> allGasList, List<Station> stationList, Dictionary<int, int> discounts)
    {
        while (true)
        {
            if (ChooseToPrintFuelOrStationList() == 2)
            {
                PrintPreOrderCheque(OrderByGasList(allGasList, stationList), discounts);
                if (ConfirmOrder() == "1")
                {
                    string path = @"D:\vitek\C#\Технология программирования\АЗС\чек.txt";
                    Console.WriteLine("Ваш заказ готов!");
                    if (RestartOrder() == "1")
                        continue;
                    else
                        break;
                    //CreateCheck(selectedGasStation.name, selectedGasStation.name, myFuelType, priceOfSelectedStation, fuelAmount, totalPrice, finalPriceWithDiscount, discount);

                    //ChangeStationData(stationList, selectedGasStation.name, myFuelType, fuelAmount);
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
                PrintPreOrderCheque(OrderByStationList(stationList), discounts);

                if (ConfirmOrder() == "1")
                {
                    string path = @"D:\vitek\C#\Технология программирования\АЗС\чек.txt";
                    Console.WriteLine("Ваш заказ готов!");
                    if (RestartOrder() == "1")
                        continue;
                    else
                        break;
                    //CreateCheck(selectedGasStation.name, selectedGasStation.name, myFuelType, priceOfSelectedStation, fuelAmount, totalPrice, finalPriceWithDiscount, discount);

                    //ChangeStationData(stationList, selectedGasStation.name, myFuelType, fuelAmount);
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
    /*
    public static void Order(List<string> allGasList, List<Station> stationList, Dictionary<int, int> discounts)
    {
        string chosenFuel = "";
        int fuelAmount = 0;

        while (true)
        {
            int choiceBtwStationListOrFuelList = ChooseToPrintFuelOrStationList(); // 1 - список станций 

            Station selectedGasStation;

            if (choiceBtwStationListOrFuelList == 1)
            {
                selectedGasStation = GetGasStation(stationList);
                selectedGasStation.PrintInfo();
                var myFuelType = GetFuelType(selectedGasStation.gas);

                fuelAmount = GetFuelAmount();
                //List<Station> availableStations = GetAvailableStations(stationList, myFuelType, fuelAmount);
                //ShowAvailableStationsWithPrice(ref availableStations, stationList, ref myFuelType, ref fuelAmount, allGasList);

                int priceOfSelectedStation = selectedGasStation.gasPrice[myFuelType];
                int totalPrice = priceOfSelectedStation * fuelAmount;
                int discount = GetDiscount(discounts, fuelAmount);
                double finalPriceWithDiscount = CountDiscountPrice(totalPrice, discount);
                Console.WriteLine(
                        $"Ваш заказ\n" +
                        $"АЗС: {selectedGasStation.name}, ул. {selectedGasStation.address}\n" +
                        $"{myFuelType}   {selectedGasStation.gasPrice[myFuelType]}р X {fuelAmount}л = {totalPrice}р\n" +
                        $"Скидка составила: {Math.Round((totalPrice - finalPriceWithDiscount), 2)}р ({discount}%)\n" +
                        $"Итого: {finalPriceWithDiscount}р"
                    );

                string answer = ConfirmOrder();

                if (answer == "1")
                {
                    string path = @"D:\vitek\C#\Технология программирования\АЗС\чек.txt";
                    Console.WriteLine("Ваш заказ готов!");
                    CreateCheck(selectedGasStation.name, selectedGasStation.name, myFuelType, priceOfSelectedStation, fuelAmount, totalPrice, finalPriceWithDiscount, discount);

                    ChangeStationData(stationList, selectedGasStation.name, myFuelType, fuelAmount);

                    break;
                }
                else if (answer == "2")
                {
                    //answer = RestartOrder();
                    //if (answer == "1")
                    //{
                    //    Console.WriteLine();
                    //    continue;
                    //}
                    //else if (answer == "2")
                    //{
                    //    break;
                    //}
                    break;
                }
            }
            else
            {
                //myFuelType = GetFuelType(allGasList);
                //fuelAmount = GetFuelAmount();
                //    List<Station> availableStations = GetAvailableStations(stationList, myFuelType, fuelAmount);
                //    ShowAvailableStationsWithPrice(ref availableStations, stationList, ref myFuelType, ref fuelAmount, allGasList);

                //    int selectedNumberOfGasStation = CheckSelectedStationNumber(availableStations);
                //    Console.WriteLine(
                //            $"Вы выбрали: {availableStations[selectedNumberOfGasStation - 1].Name}"
                //        );
                //    string selectedStationName = availableStations[selectedNumberOfGasStation - 1].Name;
                //    string selectedStationAddress = availableStations[selectedNumberOfGasStation - 1].Address;
                //    int priceOfSelectedStation = availableStations[selectedNumberOfGasStation - 1].gasPrice[myFuelType];
                //    int totalPrice = priceOfSelectedStation * fuelAmount;
                //    int discount = CheckDiscount(discounts, fuelAmount);
                //    double finalPriceWithDiscount = CountDiscountPrice(totalPrice, discount);
                //    Console.WriteLine(
                //            $"Ваш заказ\n" +
                //            $"АЗС: {selectedStationName}, ул. {selectedStationAddress}\n" +
                //            $"{myFuelType}   {priceOfSelectedStation}р X {fuelAmount}л = {totalPrice}р\n" +
                //            $"Скидка составила: {Math.Round((totalPrice - finalPriceWithDiscount), 2)}р ({discount}%)\n" +
                //            $"Итого: {finalPriceWithDiscount}р"
                //        );
                //    string answer = ConfirmOrder();

                //    if (answer == "1")
                //    {
                //        string path = @"D:\vitek\C#\Технология программирования\АЗС\чек.txt";
                //        Console.WriteLine("Ваш заказ готов!");
                //        CreateCheck(selectedStationName, selectedStationAddress, myFuelType, priceOfSelectedStation, fuelAmount, totalPrice, finalPriceWithDiscount, discount);

                //        ChangeStationData(stationList, selectedStationName, myFuelType, fuelAmount);

                //        break;
                //    }
                //    else if (answer == "2")
                //    {
                //        //answer = RestartOrder();
                //        //if (answer == "1")
                //        //{
                //        //    Console.WriteLine();
                //        //    continue;
                //        //}
                //        //else if (answer == "2")
                //        //{
                //        //    break;
                //        //}
                //        break;
                //    }
            }


        }
    }*/

    /*
    public static int CheckSelectedStationNumber(List<Station> availableStations)
    {
        Console.Write(
                "Выберите номер станции\n" +
                "Ввод: "
            );
        string enteredNumberOfGasStation = Console.ReadLine();
        if (int.TryParse(enteredNumberOfGasStation, out int selectedNumberOFGasStation))
        {
            if ((selectedNumberOFGasStation <= availableStations.Count) && (selectedNumberOFGasStation > 0))
            {
                return selectedNumberOFGasStation;
            }
            else
            {
                Console.WriteLine("К сожалению такого номера нет в списке, попробуйте снова");// todo вынести вывод в отдельный метод
                return CheckSelectedStationNumber(availableStations);
            }
        }
        else
        {
            Console.WriteLine("К сожалению такого номера нет в списке, попробуйте снова");
            return CheckSelectedStationNumber(availableStations);
        }
        return 0;
    }
    */

    public static double CountDiscountPrice(int totalPrice, int discount)
    {
        double discountPrice = Convert.ToDouble(totalPrice) * (1 - (Convert.ToDouble(discount) / 100));
        return discountPrice;
    }

    public static int GetDiscount(Dictionary<int, int> discounts, int fuelAmount)
    {
        int discount = 0;
        foreach(KeyValuePair<int, int> kvp in discounts)
        {
            if (fuelAmount > kvp.Key)
                discount = kvp.Value;
        }
        return discount;
    }

    public static string ConfirmOrder()
    {
        Console.WriteLine(
                    "Вы подтверждаете ваш заказ?\n" +
                    "1-Да 2-Нет"
                );

        Console.Write("Ввод: ");

        string answer = Console.ReadLine();
        if (answer == "1")
            return answer;
        else if (answer == "2")
            return answer;
        else
        {
            Console.WriteLine("Неверный ввод, попробуйте снова!");
            return ConfirmOrder();
        }
    }

    public static string RestartOrder()
    {
        Console.WriteLine();
        Console.WriteLine(
                        "Вы желаете оформить заказ заново?\n" +
                        "1-Да 2-Выйти из приложения"
                    );

        Console.Write("Ввод: ");

        string answer = Console.ReadLine();
        if (answer == "1")
            return answer;
        else if (answer == "2")
            return answer;
        else
        {
            Console.WriteLine("Неверный ввод, попробуйте снова!");
            return RestartOrder();
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

    public static  void PrintMessageChooseToPrintFuelOrStationList()
    {
        Console.WriteLine(
                "Выберите из списка станций или из списка топлива\n" +
                "1-показать список станций 2-показать список топлива"
            );

    }

    public static int CheckAnswerChooseToPrintFuelOrStationList(string answer)
    {
        if (answer != "1" && answer != "2")
            return 0;
        else if (answer == "1")
            return 1;
        else 
            return 2;
    }

    public static int ChooseToPrintFuelOrStationList()
    {
        Console.WriteLine(
                "Выберите из списка станций или из списка топлива\n" +
                "1-показать список станций 2-показать список топлива"
            );
        Console.Write("Ввод: ");

        string answer = Console.ReadLine();
        while (CheckAnswerChooseToPrintFuelOrStationList(answer) == 0)
        {
            Console.WriteLine("Неправильный ввод! Попробуйте снова");
            answer = Console.ReadLine();
        }

        return CheckAnswerChooseToPrintFuelOrStationList(answer);
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

    //public static Station GetGasStation(List<Station> stationList)
    //{
    //    string selectedStationName;
    //    List<string> stationNames = new List<string>(); //как преобразовать можно???

    //    Station tempStation = new Station();

    //    foreach (Station station in stationList)
    //        stationNames.Add(station.name.ToUpper());

    //    while (true)
    //    {
    //        PrintStationList(stationList); // метод вызывает вывод списка станций и возвращает введенную станцию, нужно ли это разделять и как????

    //        Console.Write("Ввод: ");
    //        selectedStationName = Console.ReadLine().ToUpper();


    //        foreach (Station station in stationList)
    //        {
    //            if (station.name.ToUpper() == selectedStationName)//найти станцию ?
    //            {
    //                tempStation = station;
    //                break;
    //            }
    //        }
    //        if (tempStation.name.ToUpper() != selectedStationName.ToUpper())// сообщить об ошибке
    //        {
    //            Console.WriteLine();
    //            Console.WriteLine(
    //                    "Введенной станции нет в списке! \n" +
    //                    "Попробуйте снова \n"
    //                );
    //            continue;
    //        }
    //        else
    //            break;
    //    }
    //    return tempStation;
    //}

    public static void PrintStationInfoByName(List<Station> stationList, Station selectedStation)
    {
        //Station selectedStation;
        foreach (Station station in stationList)
        {
            if (station == selectedStation)
            {
                selectedStation = station;
                Console.WriteLine();
                selectedStation.PrintInfo();
                break;
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
        Dictionary<int, int> discounts = new Dictionary<int, int>();
        string[] allGasTypes = File.ReadAllLines(gasTypesFilePath);
        string[] TextFile = File.ReadAllLines(stationsFilePath);
        string[] nameAddress = new string[] { };
        List<Station> stationList = new List<Station>();
        List<string> allGasList = new List<string>();
        List<string> localStationGasList = new List<string>();// для добавления каждой новой считанной станции в лист со всеми станциями
        Dictionary<string, int> gasPrice = new Dictionary<string, int>();
        Dictionary<string, int> gasAmount = new Dictionary<string, int>();
        int counter = 0;
        int counterGasTypes = 0;

        for (int i = 0; i<allGasTypes.Length; i++) 
        {
            if (allGasTypes[i] == "")
            {
                counterGasTypes++;
                continue;
            }
            else if (counterGasTypes == 0)
            {
                string[] tempAllGasTypes = allGasTypes[i].Split(";");
                for (int j = 0; j < tempAllGasTypes.Length; j++)
                    allGasList.Add(tempAllGasTypes[j]);
            }
            else if (counterGasTypes == 1)
            {
                string[] tempDiscount = allGasTypes[i].Split(";");
                discounts.Add(Convert.ToInt32(tempDiscount[0]), Convert.ToInt32(tempDiscount[1]));
            }
        }
        
        for (int i = 0; i<TextFile.Length; i++)
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

        Console.WriteLine("Добро пожаловать в Гортопливо!");
        Console.WriteLine();
        Console.WriteLine("В данной системе вы можете оформить заказ топлива в одной из АЗС города!");
        Console.WriteLine();

        foo(allGasList, stationList, discounts);
        ////var (chosenStation, chosenFuel, fuelamount) = OrderByGasList(allGasList, stationList);
        //(Station chosenStation, string chosenFuel, int fuelamount) orderInfo = OrderByStationList(stationList);
        //PrintPreOrderCheque(orderInfo, discounts);

        //while (true)
        //{
        //    Order(allGasList, stationList, discounts);
        //    string answer = RestartOrder();
        //    if (answer == "1")
        //        continue;
        //    else if (answer == "2")
        //        break;
        //}
    }



    public static void CreateCheck(
            string selectedStationName, string selectedStationAddress, string myFuelType, int priceOfSelectedStation, 
            int fuelAmount,int totalPrice, double finalPriceWithDiscount, int discount
        )
    {
        string text = string.Format(
                $"Ваш заказ\n" +
                $"АЗС: {selectedStationName}, ул. {selectedStationAddress}\n" +
                $"{myFuelType}   {priceOfSelectedStation}р X {fuelAmount}л = {totalPrice}р\n" +
                $"Скидка составила: {Math.Round((totalPrice - finalPriceWithDiscount), 2)}р ({discount}%)\n" +
                $"Итого: {finalPriceWithDiscount}р"
            );
        using (StreamWriter SW = new StreamWriter("./Check.txt", false))
        {
            SW.WriteLine(text);
        }
    }
}