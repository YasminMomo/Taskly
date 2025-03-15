using TasklyApp.ViewModels;
using System.Threading.Tasks;
using System.Windows;
using TasklyApp.Views;

namespace TasklyApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Existing method for adding a task
        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            AddTaskWindow addTaskWindow = new AddTaskWindow();
            addTaskWindow.Show();
        }

        // New method for restarting the application
        private async void RestartButton_Click(object sender, RoutedEventArgs e)
        {
            // Disable the button to prevent multiple clicks during restart
            RestartButton.IsEnabled = false;

            // Wait a brief moment to ensure UI updates before restarting
            await Task.Delay(500);

            // Execute restart logic in a background thread using Task.Run
            await Task.Run(() =>
            {
                // Get the current app path and restart it
                string appPath = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;

                // Shutdown the application on the UI thread
                Dispatcher.Invoke(() =>
                {
                    Application.Current.Shutdown();  // Shutdown the application
                });

                // Relaunch the application
                System.Diagnostics.Process.Start(appPath);
            });
        }

    }
}
