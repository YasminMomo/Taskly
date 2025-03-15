using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TasklyApp.Views
{
    /// <summary>
    /// Interaction logic for Timer.xaml
    /// </summary>
    public partial class Timer : UserControl
    {
        const string _StartTimeDisplay = "00:00:00";
        private Stopwatch _stopwatch;
        private System.Timers.Timer _timer;

        public Timer()
        {
            InitializeComponent();
            TimeDisplay.Text = _StartTimeDisplay;

            _stopwatch = new Stopwatch();
            _timer = new System.Timers.Timer(1000);

            _timer.Elapsed += OnTimerElapse;
        }

        private void OnTimerElapse(object? sender, ElapsedEventArgs e)
        {
            Application.Current.Dispatcher.Invoke(() =>
            {
                TimeDisplay.Text = _stopwatch.Elapsed.ToString(@"hh\:mm\:ss");
            });

        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            _stopwatch.Start();
            _timer.Start();
            Reset.IsEnabled = false;
        }
        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            _stopwatch.Stop();
            _timer.Stop();
            Reset.IsEnabled = true;

        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            _stopwatch.Reset();
            TimeDisplay.Text = "00:00:00";
        }
    }
}
