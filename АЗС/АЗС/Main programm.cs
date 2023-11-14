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

        //экземпляр класса?
        string stationsFilePath = args[0];
        if (!File.Exists(stationsFilePath))
        {
            InfoMessage.FileNameNotExistsMessage();
            return;
        }

        //экземпляр класса?
        string gasTypesFilePath = args[1];
        if (!File.Exists(gasTypesFilePath))
        {
            InfoMessage.FileNameNotExistsMessage();
            return;
        }

        //экземпляр класса?
        string[] allGasTypesTextFile = File.ReadAllLines(gasTypesFilePath);
        //экземпляр класса?
        string[] TextFile = File.ReadAllLines(stationsFilePath);
        //экземпляр класса?
        (List<string> allGasList, Dictionary<int, int> discounts) allGasTypesAndDiscounts = FileWork.ReadGasInfo(allGasTypesTextFile);
        //экземпляр класса?
        List<Station> stationList = FileWork.ReadStationsInfo(TextFile);
        InfoMessage.PrintWelcomeMessage();
        SomeProcess.BuyProcess(allGasTypesAndDiscounts.Item1, stationList, allGasTypesAndDiscounts.Item2);
    }



}