using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System;
using System.Linq;
using TasklyApp.Models; // Ensure the TaskCardItem model is included
using TasklyApp.Services;
using System.Diagnostics; // Ensure DatabaseService is included

namespace TasklyApp.ViewModels
{
    public class TasksDueTodayViewModel : INotifyPropertyChanged
    {
        private readonly DatabaseService _databaseService;

        private ObservableCollection<TaskCardItem> _tasksDueToday;

        public ObservableCollection<TaskCardItem> TasksDueToday
        {
            get { return _tasksDueToday; }
            set
            {
                _tasksDueToday = value;
                OnPropertyChanged(nameof(TasksDueToday));
            }
        }

        // Constructor
        public TasksDueTodayViewModel()
        {
            _databaseService = new DatabaseService(); // Ensure DatabaseService has a parameterless constructor
            TasksDueToday = new ObservableCollection<TaskCardItem>();

            LoadTasksDueTodayAsync();
            PopulateDummyData();
        }

        // Method to load tasks that are due today asynchronously
        private async void LoadTasksDueTodayAsync()
        {
            try
            {
                // Fetch tasks due today from the database
                var tasksDueToday = await _databaseService.GetTasksDueTodayAsync();

                // Clear the collection before adding new data
                TasksDueToday.Clear();

                // Add the tasks to the collection
                foreach (var task in tasksDueToday)
                {
                    // Map the data from TaskCardItem if necessary (currently assumed to be already properly mapped)
                    TasksDueToday.Add(task);
                }

                // Debug: Print tasks due today
                Debug.WriteLine("Tasks Due Today: ");
                foreach (var task in TasksDueToday)
                {
                    Debug.WriteLine($"- {task.CourseCode}, {task.TaskDescription}, {task.TaskProgress}, Due: {task.Deadline}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching tasks due today: {ex.Message}");
                // Handle errors (possibly populate with dummy data)
            }
        }


        // Notify UI when data changes
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        // Method to populate dummy data
        private void PopulateDummyData()
        {
            Debug.WriteLine("----------------------- POPULATE TODAY'S TASKS -----------------------");

            var taskItems = new List<TaskCardItem>
            {
                new TaskCardItem
                {
                    CourseCode = "FOR",
                    CategoryCode = "QUIZ",
                    TaskDescription = "Prepare for the upcoming topic presentation.",
                    TaskProgress = TaskProgressState.NotStarted,
                    TaskCategory = "QUIZ",
                    Deadline = new DateTime(2025, 2, 1, 9, 0, 0)
                },
                new TaskCardItem
                {
                    CourseCode = "FOR",
                    CategoryCode = "PROJ",
                    TaskDescription = "Do the IMRAD.",
                    TaskProgress = TaskProgressState.NotStarted,
                    TaskCategory = "PROJ",
                    Deadline = new DateTime(2025, 2, 1, 17, 0, 0)
                },
                new TaskCardItem
                {
                    CourseCode = "APPDEV",
                    CategoryCode = "PROJ",
                    TaskDescription = "Project presentation.",
                    TaskProgress = TaskProgressState.NotStarted,
                    TaskCategory = "PROJ",
                    Deadline = new DateTime(2025, 2, 1, 8, 0, 0)
                },
                new TaskCardItem
                {
                    CourseCode = "ELEC",
                    CategoryCode = "ACT",
                    TaskDescription = "Exercise #9.",
                    TaskProgress = TaskProgressState.InProgress,
                    TaskCategory = "ACT",
                    Deadline = new DateTime(2025, 2, 1, 23, 59, 0)
                },
                new TaskCardItem
                {
                    CourseCode = "HCI",
                    CategoryCode = "ACT",
                    TaskDescription = "Do the activity.",
                    TaskProgress = TaskProgressState.InProgress,
                    TaskCategory = "ACT",
                    Deadline = new DateTime(2025, 2, 1, 14, 0, 0)
                },
                new TaskCardItem
                {
                    CourseCode = "APPDEV",
                    CategoryCode = "PROJ",
                    TaskDescription = "Project.",
                    TaskProgress = TaskProgressState.InProgress,
                    TaskCategory = "PROJ",
                    Deadline = new DateTime(2025, 2, 1, 17, 0, 0)
                }
            };
            // Add ALL tasks to TasksDueToday
            TasksDueToday.Clear();  // Clear existing data
            foreach (var task in taskItems)
            {
                TasksDueToday.Add(task);
            }

            // Debugging the collection
            Debug.WriteLine("Populated Tasks Due Today:");
            foreach (var task in TasksDueToday)
            {
                Debug.WriteLine($"- {task.CourseCode}, {task.TaskDescription}, {task.TaskProgress}, Due: {task.Deadline}");
            }
        }

    }
}
