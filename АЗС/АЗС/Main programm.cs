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
            Print.FileNotExistsMessage();
            return;
        }

        string stationsFilePath = args[0];
        if (!File.Exists(stationsFilePath))
        {
            Print.FileNameNotExistsMessage();
            return;
        }

        string gasTypesFilePath = args[1];
        if (!File.Exists(gasTypesFilePath))
        {
            Print.FileNameNotExistsMessage();
            return;
        }

        string[] allGasTypesTextFile = File.ReadAllLines(gasTypesFilePath);
        string[] TextFile = File.ReadAllLines(stationsFilePath);

        NetworkStation net = FileWork.MakeStationsNetwork(FileWork.ReadStationsInfo(TextFile), FileWork.ReadGasInfo(allGasTypesTextFile).Item2);
        SomeProcess.Process(net);

    }


}