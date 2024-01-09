using Microsoft.Graph.Models.TermStore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Xml.Serialization;
using АЗС.BuisnessLogic;
using АЗС.DataAccess;


namespace Gas
{
    /// <summary>
    /// Interaction logic for SelectPurchasedetailsControl.xaml
    /// </summary>
    public partial class SelectPurchasedetailsControl : UserControl
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();

        ObservableCollection<Table> Benzin;
        Station myStation;
        NetworkStation myNet;
        public SelectPurchasedetailsControl(NetworkStation net, Station station)
        {
            InitializeComponent();
            myStation = station;
            myNet = net;
            Benzin = new ObservableCollection<Table>();
            foreach (KeyValuePair<string, int> kvp in myStation.GasPrice)
            {
                comboBox.Items.Add(kvp.Key);
            }
            mediaPlayer.Open(new Uri("D:\\vitek\\C#\\Технология программирования\\Gas-station-app\\АЗС\\Gas\\Elements\\3161a4b1f16279d.mp3", UriKind.RelativeOrAbsolute));

        }
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Проверяем, является ли введенный символ цифрой
            if (!char.IsDigit(e.Text, 0))
            {
                e.Handled = true; // Если символ не является цифрой, отменяем ввод
            }
        }

        private void goToConfirmOrderDialog_click(object sender, RoutedEventArgs e)
        {
            CurrentFuel fuelType =  new CurrentFuel(comboBox.SelectedItem.ToString().Trim());
            int fuelAmount = Convert.ToInt16(litres.Text);

            if (fuelAmount > myStation.GasReserve[fuelType.FuelTypeName])
            {
                MessageBox.Show("Столько топлива нет на станции!");
                return;
            }

            Discount myDiscount = myNet.GetDiscountSize(fuelAmount);
            Order myOrder = new Order(myStation, fuelType, fuelAmount, myDiscount);
            Cheque myCheque = myOrder.CreateCheque();
            mediaPlayer.Play();

            MessageBox.Show($"Ваш чек: \n" +
            $"{myCheque.ChequeString}");

            FileWorker.ChangeStationData(myNet.Stations, myStation.Name, fuelType.FuelTypeName, fuelAmount);
            FileWorker.WriteCheque(myCheque);
            OrderSelectStationControll usercontrol = new OrderSelectStationControll(myNet);
            contentControl.Content = usercontrol;
        }
    }
}
