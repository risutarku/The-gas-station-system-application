using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace АЗС
{
    internal class FileWork
    {
        public static void WriteCheque(string text)
        {
            using (StreamWriter SW = new StreamWriter("./Check.txt", false))
            {
                SW.WriteLine(text);
            }
        }
        public static (List<string>, Dictionary<int, int>) ReadGasInfo(string[] allGasTypesTextFile)
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
        public static List<Station> ReadStationsInfo(string[] TextFile)
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
                    stationList.Add(new Station(nameAddress, localStationGasList, gasPrice, gasAmount));
                    //stationList.Add(Station.Create(nameAddress, localStationGasList, gasPrice, gasAmount));
                    nameAddress = new string[] { };
                    localStationGasList = new List<string>();
                    gasPrice = new Dictionary<string, int>();
                    gasAmount = new Dictionary<string, int>();
                }
            }
            return stationList;
        }

        public static NetworkStation MakeStationsNetwork(List<Station> stations, Dictionary<int, int> discounts)
        {
            return new NetworkStation(stations, discounts);
        }
    }
}
