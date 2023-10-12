using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;
using System.Collections.Generic;
using АЗС;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;

internal class Program
{
    public static void ShowFuelList(List<string> fuel) //вывод списка топлива
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

    public static string EnterFuelType(List<string> fuel)
    {
        string chosenFuel;
        while (true)
        {
            ShowFuelList(fuel);
            Console.Write("Ввод: ");
            chosenFuel = Console.ReadLine().ToUpper();

            if (!(fuel.Contains(chosenFuel)))
            {
                Console.WriteLine();
                Console.WriteLine(
                        "Выбранного типа топлива нет в списке! \n" +
                        "Попробуйте снова \n"
                    );
                continue;
            }
            else
                break;
        }
        return chosenFuel;
    }
    

    public static int EnterFuelAmount() // ввод литров топлива
    {
        Console.WriteLine();
        Console.WriteLine("Введите объём топлива (в литрах)");
        Console.Write("Ввод: ");
        string fuelAmount = Console.ReadLine().Trim();
        if (int.TryParse(fuelAmount, out int amount))
        {
            if (amount > 0)
            {
                Console.WriteLine("Вы ввели {0}л", amount);
                return amount;
            }
            else
            {
                Console.WriteLine("Некорректный ввод, попробуйте снова");
                return EnterFuelAmount();
            }
        }
        else 
        {
            Console.WriteLine("Некорректный ввод, попробуйте снова");
            return EnterFuelAmount();
        }
        return 0;
    }

    public static bool IsGasAvailable(string myFuelType, int fuelAmount, Station gasStation) // проверка станции на наличие данного количества и типа топлива
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

    public static List<Station>  GetAvailableStations(List<Station> gasStations, string myFuelType, int fuelAmount) // выбор подходящий станции их всего списка станций
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

    public static void PrintStationsWithPrice(string myFuelType, int fuelAmount, List<Station> availableStations)
    {
        Console.WriteLine($"Вот доступные заправки для ваших критериев: {myFuelType,5} {fuelAmount,5}л");// todo вынести вывод в отдельный метод
        foreach (Station station in availableStations)
        {
            Console.Write(
                    $"{availableStations.IndexOf(station) + 1}. {station.Name}    {station.GasPrice[myFuelType]}р за 1л\n"
                );
        }
    }

    public static void ShowAvailableStationsWithPrice(ref List<Station> availableStations, List<Station> gasStations, ref string myFuelType, ref int fuelAmount, List<string> fuel)
    {
        if (availableStations.Count == 0)
        {
            Console.WriteLine(
                    "По вашим критериям не удалось найти подходящие заправки\n" +
                    "Попробуйуте указать другой тип или объем топлива"
                );
            while (availableStations.Count == 0)
            {
                myFuelType = EnterFuelType(fuel);
                fuelAmount = EnterFuelAmount();
                availableStations = GetAvailableStations(gasStations, myFuelType, fuelAmount);
            }
            PrintStationsWithPrice(myFuelType, fuelAmount, availableStations);
        }
        else
        {
            PrintStationsWithPrice(myFuelType, fuelAmount, availableStations);
        }
    }

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

    public static double CountDiscountPrice(int totalPrice, int discount)
    {
        double discountPrice = Convert.ToDouble(totalPrice) * (1 - (Convert.ToDouble(discount) / 100));
        return discountPrice;
    }

    public static int CheckDiscount(Dictionary<int, int> discounts, int fuelAmount)
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

    public static int  ChooseToPrintFuelOrStationList(List<Station> stationList, List<string> fuel)
    {
        Console.WriteLine(
                "Выберите из списка станций или из списка топлива\n" +
                "1-показать список станций 2-показать список топлива"
            );
        Console.Write("Ввод: ");

        string answer = Console.ReadLine();
        while (answer != "1" && answer != "2")
        {
            Console.WriteLine("Неправильный ввод! Попробуйте снова");
            answer = Console.ReadLine();
        }
        if (answer == "1")
            return 1;
        else
            return 2;
    }

    public static void PrintStationList(List<Station> stationList)
    {
        int counter = 0;
        foreach (Station station in stationList)
        {   
            //counter++;
            //Console.WriteLine($"{counter}. {station.name}"); 
            Console.WriteLine($"{station.name}");
        }
    }

    public static Station EnterGasStation(List<Station> stationList)
    {
        string selectedStationName;
        List<string> stationNames = new List<string>(); //как преобразовать можно???

        Station tempStation = new Station();

        foreach (Station station in stationList)
            stationNames.Add(station.name.ToUpper());

        while (true)
        {
            PrintStationList(stationList); // метод вызывает вывод списка станций и возвращает введенную станцию, нужно ли это разделять и как????

            Console.Write("Ввод: ");
            selectedStationName = Console.ReadLine().ToUpper();


            foreach (Station station in stationList)
            {
                if (station.name.ToUpper() == selectedStationName)//найти станцию ?
                {
                    tempStation = station;
                    break;    
                }
            }
            if (tempStation.name.ToUpper() != selectedStationName.ToUpper())// сообщить об ошибке
            {
                Console.WriteLine();
                Console.WriteLine(
                        "Введенной станции нет в списке! \n" +
                        "Попробуйте снова \n"
                    );
                continue;
            }
            else
                break;
        }
            return tempStation;
    }

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
        
        
        //int choiceBtwStationListOrFuelList = ChooseToPrintFuelOrStationList(stationList, allGasList); // 1 - список станций 

        //string myFuelType = "";
        //Station  selectedGasStation;

        //if (choiceBtwStationListOrFuelList == 1)
        //{
        //    selectedGasStation = EnterGasStation(stationList);
        //    Console.WriteLine("Вы выбрали:");
        //    selectedGasStation.PrintInfo();
        //    myFuelType = EnterFuelType(selectedGasStation.gas);
        //    // PrintStationInfoByName(stationList, selectedGasStation);

        //}
        //else
        //    myFuelType = EnterFuelType(allGasList);
        
        
        while (true)
        {
            Order(allGasList, stationList, discounts);
            Console.WriteLine();
            string answer = RestartOrder();
            if (answer == "1")
                continue;
            else if (answer == "2")
                break;
        }
    }

    public static void Order(List<string> allGasList, List<Station> stationList, Dictionary<int, int> discounts)
    {
        while (true)
        {
            int choiceBtwStationListOrFuelList = ChooseToPrintFuelOrStationList(stationList, allGasList); // 1 - список станций 

            string myFuelType = "";
            Station selectedGasStation;

            if (choiceBtwStationListOrFuelList == 1)
            {
                selectedGasStation = EnterGasStation(stationList);
                selectedGasStation.PrintInfo();
                myFuelType = EnterFuelType(selectedGasStation.gas); 
                
                int fuelAmount = EnterFuelAmount();
                //List<Station> availableStations = GetAvailableStations(stationList, myFuelType, fuelAmount);
                //ShowAvailableStationsWithPrice(ref availableStations, stationList, ref myFuelType, ref fuelAmount, allGasList);

                int priceOfSelectedStation = selectedGasStation.gasPrice[myFuelType];
                int totalPrice = priceOfSelectedStation * fuelAmount;
                int discount = CheckDiscount(discounts, fuelAmount);
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
                    answer = RestartOrder();
                    if (answer == "1")
                    {
                        Console.WriteLine();
                        continue;
                    }
                    else if (answer == "2")
                    {
                        break;
                    }
                }
            }
            else
            {
                myFuelType = EnterFuelType(allGasList);
                int fuelAmount = EnterFuelAmount();
                List<Station> availableStations = GetAvailableStations(stationList, myFuelType, fuelAmount);
                ShowAvailableStationsWithPrice(ref availableStations, stationList, ref myFuelType, ref fuelAmount, allGasList);

                int selectedNumberOfGasStation = CheckSelectedStationNumber(availableStations);
                Console.WriteLine(
                        $"Вы выбрали: {availableStations[selectedNumberOfGasStation - 1].Name}"
                    );
                string selectedStationName = availableStations[selectedNumberOfGasStation - 1].Name;
                string selectedStationAddress = availableStations[selectedNumberOfGasStation - 1].Address;
                int priceOfSelectedStation = availableStations[selectedNumberOfGasStation - 1].gasPrice[myFuelType];
                int totalPrice = priceOfSelectedStation * fuelAmount;
                int discount = CheckDiscount(discounts, fuelAmount);
                double finalPriceWithDiscount = CountDiscountPrice(totalPrice, discount);
                Console.WriteLine(
                        $"Ваш заказ\n" +
                        $"АЗС: {selectedStationName}, ул. {selectedStationAddress}\n" +
                        $"{myFuelType}   {priceOfSelectedStation}р X {fuelAmount}л = {totalPrice}р\n" +
                        $"Скидка составила: {Math.Round((totalPrice - finalPriceWithDiscount), 2)}р ({discount}%)\n" +
                        $"Итого: {finalPriceWithDiscount}р"
                    );
                string answer = ConfirmOrder();

                if (answer == "1")
                {
                    string path = @"D:\vitek\C#\Технология программирования\АЗС\чек.txt";
                    Console.WriteLine("Ваш заказ готов!");
                    CreateCheck(selectedStationName, selectedStationAddress, myFuelType, priceOfSelectedStation, fuelAmount, totalPrice, finalPriceWithDiscount, discount);

                    ChangeStationData(stationList, selectedStationName, myFuelType, fuelAmount);

                    break;
                }
                else if (answer == "2")
                {
                    answer = RestartOrder();
                    if (answer == "1")
                    {
                        Console.WriteLine();
                        continue;
                    }
                    else if (answer == "2")
                    {
                        break;
                    }
                }
            }

            
        }
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