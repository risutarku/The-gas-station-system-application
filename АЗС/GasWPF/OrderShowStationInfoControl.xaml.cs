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

namespace GasWPF
{
    /// <summary>
    /// Interaction logic for OrderShowStationInfoControl.xaml
    /// </summary>
    public partial class OrderShowStationInfoControl : UserControl
    {
        public OrderShowStationInfoControl()
        {
            InitializeComponent();
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            OrderShowStationInfoControl userControl = new OrderShowStationInfoControl();
            contentControl.Content = userControl;
        }
    }
}
