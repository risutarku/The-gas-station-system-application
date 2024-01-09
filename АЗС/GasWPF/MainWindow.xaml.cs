using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Security.Policy;


namespace GasWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            string stationsDataPath = "D:\\vitek\\C#\\Технология программирования\\Gas-station-app\\АЗС\\GasWPF\\Files\\Stations.txt";
            string gasTypesDataPath = "D:\\vitek\\C#\\Технология программирования\\Gas-station-app\\АЗС\\GasWPF\\Files\\GasTypes.txt";

            string[] TextFile = File.ReadAllLines(stationsDataPath);
            string[] allGasTypesTextFile = File.ReadAllLines(gasTypesDataPath);

            NetworkStation net = FileWorker.MakeStationsNetwork(FileWorker.ReadStationsInfo(TextFile), FileWorker.ReadGasInfo(allGasTypesTextFile));
            MainController.StartApplication(net);
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            OrderSelectStationControl userControl = new OrderSelectStationControl();
            contentControl.Content = userControl;
        }
    }
}
