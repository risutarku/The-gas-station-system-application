
using Microsoft.Graph.Models.TermStore;
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
using АЗС.BuisnessLogic;

namespace Gas
{
    /// <summary>
    /// Interaction logic for OrderSelectStationControll.xaml
    /// </summary>
    public partial class OrderSelectStationControll : UserControl
    {
        NetworkStation MyNet;
        Station myStation;
        public OrderSelectStationControll(NetworkStation net)
        {
            InitializeComponent();
            MyNet = net;
        }
        private void Select_Click(object sender, RoutedEventArgs e)
        {
            myStation = MyNet.Stations[0];
            OrderShowStationInfo1 userControl = new OrderShowStationInfo1(MyNet, myStation);
            contentControl.Content = userControl;
        }
        private void Select_Click1(object sender, RoutedEventArgs e)
        {

            myStation = MyNet.Stations[1];
            OrderShowStationInfo2Control userControl = new OrderShowStationInfo2Control(MyNet, myStation);
            contentControl.Content = userControl;
        }
    }
}
