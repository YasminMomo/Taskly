using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TasklyApp.Services;

namespace TasklyApp.Models
{
    public class TaskOverviewManager
    {
        private static readonly DatabaseService _dbService = new DatabaseService();
        public static ObservableCollection<TaskOverview> _DatabaseTasks = new ObservableCollection<TaskOverview>();

        // Fetch the latest task statistics from the database
        public static async Task<ObservableCollection<TaskOverview>> GetTasksAsync()
        {
            var overview = await _dbService.GetTaskOverviewAsync();
            _DatabaseTasks.Clear();
            _DatabaseTasks.Add(overview);
            return _DatabaseTasks;
        }
    }
}
