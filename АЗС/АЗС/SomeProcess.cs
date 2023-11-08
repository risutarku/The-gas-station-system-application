﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АЗС
{
    internal class SomeProcess
    {
        public static string ChooseToPrintFuelOrStationList()
        {
            string answer = EnterInfo.EnterChooseToPrintFuelOrStationListAnswer();
            return answer;
        }
        public static string ConfirmOrder()
        {
            string answer = EnterInfo.EnterConfirmOrderAnswer();
            return answer;
        }
        public static string RestartOrder()
        {
            string answer = EnterInfo.EnterRestatrtOrderAnswer();
            return answer;
        }
        public static (Station chosenStation, string chosenFuel, int fuelAmount) OrderByGasList(List<string> allGasList, List<Station> stationList)
        {
            while (true)
            {
                string chosenFuel = GetClass.GetFuelType(allGasList);
                int fuelAmount = GetClass.GetFuelAmount();
                List<Station> availableStations = GetClass.GetAvailableStations(stationList, chosenFuel, fuelAmount);
                if (availableStations.Count == 0)
                {
                    InfoMessage.NoAvailableStationsMessage();
                    continue;
                }
                else
                {
                    Print.PrintStationsWithPrice(chosenFuel, fuelAmount, availableStations);
                    Station chosenStation = GetClass.GetStation(availableStations);
                    return (chosenStation, chosenFuel, fuelAmount);
                }
            }
        }
        public static (Station chosenStation, string chosenFuel, int fuelAmount) OrderByStationList(List<Station> stationList)
        {
            Print.PrintStationList(stationList);
            Station chosenStation = GetClass.GetStation(stationList);
            chosenStation.PrintInfo();
            string chosenFuel = GetClass.GetFuelType(chosenStation.gas);
            int fuelAmount = GetClass.GetFuelAmount();

            while (true)
            {
                if (!Check.IsFuelAmountAvailableOnSelectedStationAndFuelType(chosenStation, chosenFuel, fuelAmount))
                {
                    InfoMessage.FuelAmountErrorMessage();
                    fuelAmount = GetClass.GetFuelAmount();
                }
                else
                    return (chosenStation, chosenFuel, fuelAmount);
            }

        }
        public static void BuyProcess(List<string> allGasList, List<Station> stationList, Dictionary<int, int> discounts) // todo
        {
            (Station chosenStation, string chosenFuel, int fuelAmount) orderInfo;
            while (true)
            {
                if (SomeProcess.ChooseToPrintFuelOrStationList() == "2")
                {

                    orderInfo = SomeProcess.OrderByGasList(allGasList, stationList);
                }
                else
                {
                    orderInfo = SomeProcess.OrderByStationList(stationList);

                }
                Print.PrintPreOrderCheque(orderInfo, discounts);
                if (SomeProcess.ConfirmOrder() == "1")
                {
                    if (SomeProcess.RestartOrder() == "1")
                        continue;
                    else
                    {
                        ChangeData.ChangeStationData(stationList, orderInfo.Item1.name, orderInfo.Item2, orderInfo.Item3);
                        NoIdea.CreateCheque(orderInfo.Item1, orderInfo.Item2, orderInfo.Item3, discounts);
                        break;
                    }
                }
                else
                {
                    if (SomeProcess.RestartOrder() == "1")
                        continue;
                    else
                        break;
                }

            }
        }
    }
}
