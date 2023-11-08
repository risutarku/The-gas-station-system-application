using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АЗС
{
    internal class Print
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
        public static void PrintStationList(List<Station> stationList)
        {
            foreach (Station station in stationList)
                Console.WriteLine($"{station.name}");
            Console.WriteLine();
        }
        public static void PrintPreOrderCheque(
                (Station chosenStation, string chosenFuel, int fuelAmount) purchaseInformation,
                Dictionary<int, int> discounts)
        {
            Station chosenStation = purchaseInformation.Item1;
            string chosenFuel = purchaseInformation.Item2;
            int fuelAmount = purchaseInformation.Item3;
            int priceOfSelectedStation = chosenStation.gasPrice[chosenFuel];
            int totalPrice = Calculations.CountTotalPrice(priceOfSelectedStation, fuelAmount);
            int discount = GetClass.GetDiscount(discounts, fuelAmount);
            double finalPriceWithDiscount = Calculations.CountDiscountPrice(totalPrice, discount); // итоговая сумма со скидкой скидки

            Console.WriteLine(NoIdea.CreatePreOrderCheque(chosenStation, chosenFuel, fuelAmount, discounts));

        }
    }
}
