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
   

    private static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            InfoMessage.FileNotExistsMessage();
            return;
        }

        string stationsFilePath = args[0];
        if (!File.Exists(stationsFilePath))
        {
            InfoMessage.FileNameNotExistsMessage();
            return;
        }

        string gasTypesFilePath = args[1];
        if (!File.Exists(gasTypesFilePath))
        {
            InfoMessage.FileNameNotExistsMessage();
            return;
        }
        
        string[] allGasTypesTextFile = File.ReadAllLines(gasTypesFilePath);
        string[] TextFile = File.ReadAllLines(stationsFilePath);
        (List<string> allGasList, Dictionary<int, int> discounts) allGasTypesAndDiscounts = FileWork.ReadGasInfo(allGasTypesTextFile);
        List<Station> stationList = FileWork.ReadStationsInfo(TextFile);
        InfoMessage.PrintWelcomeMessage();
        SomeProcess.BuyProcess(allGasTypesAndDiscounts.Item1, stationList, allGasTypesAndDiscounts.Item2);
    }



}