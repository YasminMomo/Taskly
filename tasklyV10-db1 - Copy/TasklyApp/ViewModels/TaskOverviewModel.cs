using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using TasklyApp.Models;

namespace TasklyApp.ViewModels
{
    public class TaskOverviewModel : INotifyPropertyChanged
    {
        private ObservableCollection<TaskOverview> _tasks;

        // The Tasks property that binds to the UI
        public ObservableCollection<TaskOverview> Tasks
        {
            get { return _tasks; }
            set
            {
                if (_tasks != value)
                {
                    _tasks = value;
                    OnPropertyChanged();  // Notify the UI about the change
                }
            }
        }

        // Refresh the task overview
        public async Task RefreshTaskOverviewAsync()
        {
            // Fetch the latest tasks and update the collection
            var tasks = await TaskOverviewManager.GetTasksAsync();
            Tasks = new ObservableCollection<TaskOverview>(tasks);  // Update ObservableCollection
        }

        // Constructor that loads tasks asynchronously
        public TaskOverviewModel()
        {
            LoadTasksAsync();  // Load tasks on initialization
        }

        // Load tasks asynchronously
        private async void LoadTasksAsync()
        {
            var tasks = await TaskOverviewManager.GetTasksAsync();
            Tasks = new ObservableCollection<TaskOverview>(tasks);  // Initialize the ObservableCollection
        }

        // Notify UI when the data has changed
        public event PropertyChangedEventHandler PropertyChanged;

        // Raise the PropertyChanged event to notify the UI
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
