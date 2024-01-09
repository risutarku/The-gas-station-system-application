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
using System.Windows.Threading;

namespace Gas
{
    /// <summary>
    /// Interaction logic for InfoControll.xaml
    /// </summary>
    public partial class InfoControll : UserControl
    {
        public InfoControll()
        {
            InitializeComponent();
        }
        private double SetProgressBarValue(double MousePosition)
        {
            ProgressIndicator.Value = ProgressIndicator.Minimum;
            double ratio = MousePosition / ProgressIndicator.ActualWidth;
            double ProgressBarValue = ratio * ProgressIndicator.Maximum;

            return ProgressBarValue;
        }
        private void ProgressIndicator_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            double MousePosition = e.GetPosition(ProgressIndicator).X;
            ProgressIndicator.Value = SetProgressBarValue(MousePosition);
            VideoElement.Position = new TimeSpan(0, 0, 0, 0, (int)ProgressIndicator.Value);
        }
        private void BeginButton_Click(object sender, RoutedEventArgs e)
        {
            VideoElement.Play();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            VideoElement.Stop();
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            VideoElement.Pause();
        }

        private void SpeedUpButton_Click(object sender, RoutedEventArgs e)
        {
            VideoElement.SpeedRatio += 0.5;
        }

        private void SlowdownSpeedButton_Click(object sender, RoutedEventArgs e)
        {
            VideoElement.SpeedRatio -= 0.5;
        }

        private void GetNormalSpeedButton_Click(object sender, RoutedEventArgs e)
        {
            VideoElement.SpeedRatio = 1;
        }
        private void VideoElement_OnMediaOpened(object sender, RoutedEventArgs e)
        {
            ProgressIndicator.Minimum = 0;
            ProgressIndicator.Maximum = VideoElement.NaturalDuration.TimeSpan.TotalMilliseconds;
            DispatcherTimer t = new DispatcherTimer();
            t.Tick += TimerTick;
            t.Interval = TimeSpan.FromMilliseconds(10);
            t.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            string p = Math.Round(VideoElement.Position.TotalSeconds).ToString();
            ProgressIndicator.Value = VideoElement.Position.TotalMilliseconds;
            if (VideoElement.Position.TotalSeconds.ToString().Length == 1) p = "0" + p;
            TimeText.Text = "00:" + p;
        }
    }
}

