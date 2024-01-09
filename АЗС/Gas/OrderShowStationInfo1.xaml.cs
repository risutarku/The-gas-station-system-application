
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using АЗС.BuisnessLogic;

namespace Gas
{
    /// <summary>
    /// Interaction logic for OrderShowStationInfo1.xaml
    /// </summary>
    public partial class OrderShowStationInfo1 : UserControl
    {
        Station myStation;
        ObservableCollection<Table> Benzin;
        NetworkStation myNet;
        public OrderShowStationInfo1(NetworkStation net, Station station)
        {
            InitializeComponent();
            myStation = station;
            myNet = net;
            Loaded += FillStationInfo;
        }

        private void FillStationInfo(object sender, RoutedEventArgs e)
        {

            stationInfoText.Text = myStation.Name + ", " + myStation.Address;
            Benzin = new ObservableCollection<Table>();
            station1InfoTable.ItemsSource = Benzin;
            foreach(KeyValuePair<string, int> kvp in myStation.GasPrice)
            {
                Benzin.Add(new Table() { One = kvp.Key, Two = kvp.Value, Three = myStation.GasReserve[kvp.Key]});
            }

        }

        private void startOrder_click(object sender, RoutedEventArgs e)
        {
            SelectPurchasedetailsControl userControl = new SelectPurchasedetailsControl(myNet, myStation);
            contentControl.Content = userControl;
        }



    }
}
