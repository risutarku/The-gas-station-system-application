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
using АЗС.UserInterface;
using АЗС.DataAccess;
using АЗС.BuisnessLogic;
using System.IO;


namespace Gas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        NetworkStation net;
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            string gasTypesPath = "D:\\vitek\\C#\\Технология программирования\\Gas-station-app\\АЗС\\Gas\\Files\\GasTypes.txt";
            string stationsInfoPath = "D:\\vitek\\C#\\Технология программирования\\Gas-station-app\\АЗС\\Gas\\Files\\Stations.txt";

            string[] allGasTypesTextFile = File.ReadAllLines(gasTypesPath);
            string[] TextFile = File.ReadAllLines(stationsInfoPath);

            net = FileWorker.MakeStationsNetwork(FileWorker.ReadStationsInfo(TextFile), FileWorker.ReadGasInfo(allGasTypesTextFile));
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            HomePageControl userControl = new HomePageControl();
            contentControl.Content = userControl;   
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            OrderSelectStationControll usercontrol = new OrderSelectStationControll(net);
            contentControl.Content = usercontrol;
        }

        private void Info_Click(object sender, RoutedEventArgs e)
        {

            InfoControll usercontrol = new InfoControll();
            contentControl.Content = usercontrol;
        }
    }
}
