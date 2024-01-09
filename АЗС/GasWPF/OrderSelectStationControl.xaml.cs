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
    /// Interaction logic for OrderSelectStationControl.xaml
    /// </summary>
    public partial class OrderSelectStationControl : UserControl
    {
        public OrderSelectStationControl()
        {
            InitializeComponent();
        }
        private void Select_Click(object sender, RoutedEventArgs e)
        {
            OrderShowStationInfoControl userControl = new OrderShowStationInfoControl();
            contentControl.Content = userControl;
        }
    }
}
