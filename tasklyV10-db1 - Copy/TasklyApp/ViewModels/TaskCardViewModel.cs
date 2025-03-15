using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System;
using TasklyApp.Models; // Ensure the TaskCardItem model is included
using TasklyApp.Services;
using System.Diagnostics; // Ensure DatabaseService is included

namespace TasklyApp.ViewModels
{
    public class TaskCardViewModel : INotifyPropertyChanged
    {
        private readonly DatabaseService _databaseService;

        private ObservableCollection<TaskCardItem> _notStartedTasks;
        private ObservableCollection<TaskCardItem> _inProgressTasks;
        private ObservableCollection<TaskCardItem> _completedTasks;

        public ObservableCollection<TaskCardItem> NotStartedTasks
        {
            get { return _notStartedTasks; }
            set
            {
                _notStartedTasks = value;
                OnPropertyChanged(nameof(NotStartedTasks));
            }
        }

        public ObservableCollection<TaskCardItem> InProgressTasks
        {
            get { return _inProgressTasks; }
            set
            {
                _inProgressTasks = value;
                OnPropertyChanged(nameof(InProgressTasks));
            }
        }

        public ObservableCollection<TaskCardItem> CompletedTasks
        {
            get { return _completedTasks; }
            set
            {
                _completedTasks = value;
                OnPropertyChanged(nameof(CompletedTasks));
            }
        }

        // Constructor
        public TaskCardViewModel()
        {
            _databaseService = new DatabaseService(); // Ensure DatabaseService has a parameterless constructor
            NotStartedTasks = new ObservableCollection<TaskCardItem>();
            InProgressTasks = new ObservableCollection<TaskCardItem>();
            CompletedTasks = new ObservableCollection<TaskCardItem>();

            LoadTasksAsync();
            PopulateDummyData();
            PrintCollections();
        }


        // Method to load tasks asynchronously
        private async void LoadTasksAsync()
        {
            try
            {
                // Fetch tasks from the database
                var notStartedTasks = await _databaseService.GetNotStartedTasksAsync();
                var inProgressTasks = await _databaseService.GetInProgressTasksAsync();
                var completedTasks = await _databaseService.GetCompletedTasksAsync();

                // Clear all collections before adding new data
                NotStartedTasks.Clear();
                InProgressTasks.Clear();
                CompletedTasks.Clear();

                // Convert and add tasks to the corresponding collections
                foreach (var task in notStartedTasks)
                {
                    var taskCardItem = new TaskCardItem
                    {
                        CourseCode = task.CourseCode,
                        CategoryCode = task.CategoryCode,
                        TaskDescription = task.TaskDesc,
                        TaskProgress = task.TaskProgress,
                        Deadline = task.Deadline
                    };
                    NotStartedTasks.Add(taskCardItem);
                }

                foreach (var task in inProgressTasks)
                {
                    var taskCardItem = new TaskCardItem
                    {
                        CourseCode = task.CourseCode,
                        CategoryCode = task.CategoryCode,
                        TaskDescription = task.TaskDesc,
                        TaskProgress = task.TaskProgress,
                        Deadline = task.Deadline
                    };
                    InProgressTasks.Add(taskCardItem);
                }

                foreach (var task in completedTasks)
                {
                    var taskCardItem = new TaskCardItem
                    {
                        CourseCode = task.CourseCode,
                        CategoryCode = task.CategoryCode,
                        TaskDescription = task.TaskDesc,
                        TaskProgress = task.TaskProgress,
                        Deadline = task.Deadline
                    };
                    CompletedTasks.Add(taskCardItem);
                }

                // Debug: Print collections after loading data
                Debug.WriteLine("NotStartedTasks: ");
                foreach (var task in NotStartedTasks)
                {
                    Debug.WriteLine($"- {task.CourseCode}, {task.TaskDescription}, {task.TaskProgress}");
                }

                Debug.WriteLine("InProgressTasks: ");
                foreach (var task in InProgressTasks)
                {
                    Debug.WriteLine($"- {task.CourseCode}, {task.TaskDescription}, {task.TaskProgress}");
                }

                Debug.WriteLine("CompletedTasks: ");
                foreach (var task in CompletedTasks)
                {
                    Debug.WriteLine($"- {task.CourseCode}, {task.TaskDescription}, {task.TaskProgress}");
                }
            }
            catch (Exception ex)
            {
                // Handle errors by populating with dummy data
                Console.WriteLine($"DENARDDDDD Error fetching tasks: {ex.Message}");
                PopulateDummyData();
            }
        }


        // Method to populate dummy data
        private void PopulateDummyData()
        {
            Debug.WriteLine("-----------------------POPULATE IS CALLED");
            var taskItems = new List<TaskCardItem>
            {
                new TaskCardItem
                {
                    CourseCode = "HCI",
                    CategoryCode = "PROJ",
                    TaskDescription = "Complete the assets for the game group project.",
                    TaskProgress = TaskProgressState.InProgress,
                    TaskCategory = "PROJ",
                    Deadline = new DateTime(2025, 1, 28, 17, 0, 0)
                },
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
                    CourseCode = "APPDEV",
                    CategoryCode = "TEST",
                    TaskDescription = "Finish the reviewer for the midterm test.",
                    TaskProgress = TaskProgressState.Completed,
                    TaskCategory = "TEST",
                    Deadline = new DateTime(2025, 1, 25, 23, 59, 59)
                },
                new TaskCardItem
                {
                    CourseCode = "COAL",
                    CategoryCode = "ACT",
                    TaskDescription = "Do the lab activities in Proteus.",
                    TaskProgress = TaskProgressState.NotStarted,
                    TaskCategory = "ACT",
                    Deadline = new DateTime(2025, 2, 5, 12, 0, 0)
                },
                new TaskCardItem
                {
                    CourseCode = "ALT",
                    CategoryCode = "MEET",
                    TaskDescription = "Meet with the team for brainstorming.",
                    TaskProgress = TaskProgressState.InProgress,
                    TaskCategory = "MEET",
                    Deadline = new DateTime(2025, 1, 30, 10, 0, 0)
                },
                new TaskCardItem
                {
                    CourseCode = "PPL",
                    CategoryCode = "QUIZ",
                    TaskDescription = "Prepare for the quiz on BNF.",
                    TaskProgress = TaskProgressState.NotStarted,
                    TaskCategory = "QUIZ",
                    Deadline = new DateTime(2025, 2, 8, 10, 0, 0)
                },
                new TaskCardItem
                {
                    CourseCode = "FOR",
                    CategoryCode = "TEST",
                    TaskDescription = "Complete the test on research methodology.",
                    TaskProgress = TaskProgressState.NotStarted,
                    TaskCategory = "TEST",
                    Deadline = new DateTime(2025, 2, 3, 15, 0, 0)
                },
                new TaskCardItem
                {
                    CourseCode = "APPDEV",
                    CategoryCode = "PROJ",
                    TaskDescription = "Finalize project report on applications development.",
                    TaskProgress = TaskProgressState.InProgress,
                    TaskCategory = "PROJ",
                    Deadline = new DateTime(2025, 2, 5, 17, 0, 0)
                },
                new TaskCardItem
                {
                    CourseCode = "ALT",
                    CategoryCode = "GRP",
                    TaskDescription = "Finalize the last phase of the project.",
                    TaskProgress = TaskProgressState.NotStarted,
                    TaskCategory = "GRP",
                    Deadline = new DateTime(2025, 1, 27, 12, 0, 0)
                },
                new TaskCardItem
                {
                    CourseCode = "HCI",
                    CategoryCode = "ACT",
                    TaskDescription = "Do the website rating activity.",
                    TaskProgress = TaskProgressState.Completed,
                    TaskCategory = "ACT",
                    Deadline = new DateTime(2025, 1, 26, 18, 0, 0)
                },
                new TaskCardItem
                {
                    CourseCode = "ELEC",
                    CategoryCode = "ACT",
                    TaskDescription = "Prepare the presentation for the elective project.",
                    TaskProgress = TaskProgressState.NotStarted,
                    TaskCategory = "ACT",
                    Deadline = new DateTime(2025, 1, 29, 10, 0, 0)
                },
                new TaskCardItem
                {
                    CourseCode = "COAL",
                    CategoryCode = "QUIZ",
                    TaskDescription = "Review for long quiz",
                    TaskProgress = TaskProgressState.NotStarted,
                    TaskCategory = "QUIZ",
                    Deadline = new DateTime(2025, 2, 4, 15, 0, 0)
                },
                new TaskCardItem
                {
                    CourseCode = "PPL",
                    CategoryCode = "QUIZ",
                    TaskDescription = "Do the group project.",
                    TaskProgress = TaskProgressState.InProgress,
                    TaskCategory = "QUIZ",
                    Deadline = new DateTime(2025, 2, 5, 13, 0, 0)
                },
                new TaskCardItem
                {
                    CourseCode = "COAL",
                    CategoryCode = "ACT",
                    TaskDescription = "Do the activity.",
                    TaskProgress = TaskProgressState.NotStarted,
                    TaskCategory = "ACT",
                    Deadline = new DateTime(2025, 2, 6, 23, 59, 0)
                },
                new TaskCardItem
                {
                    CourseCode = "PPL",
                    CategoryCode = "MEET",
                    TaskDescription = "Meet with the team.",
                    TaskProgress = TaskProgressState.NotStarted,
                    TaskCategory = "MEET",
                    Deadline = new DateTime(2025, 2, 3, 14, 0, 0)
                },
                new TaskCardItem
                {
                    CourseCode = "COAL",
                    CategoryCode = "MEET",
                    TaskDescription = "Do cohort.",
                    TaskProgress = TaskProgressState.Completed,
                    TaskCategory = "MEET",
                    Deadline = new DateTime(2025, 1, 25, 13, 0, 0)
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
                    CategoryCode = "TEST",
                    TaskDescription = "Answer the long test.",
                    TaskProgress = TaskProgressState.Completed,
                    TaskCategory = "TEST",
                    Deadline = new DateTime(2025, 1, 11, 14, 0, 0)
                },
                new TaskCardItem
                {
                    CourseCode = "ALT",
                    CategoryCode = "ACT",
                    TaskDescription = "Do the home activity 8.",
                    TaskProgress = TaskProgressState.InProgress,
                    TaskCategory = "ACT",
                    Deadline = new DateTime(2025, 2, 3, 20, 0, 0)
                },
                new TaskCardItem
                {
                    CourseCode = "HCI",
                    CategoryCode = "PROJ",
                    TaskDescription = "Record the gameplay for the project.",
                    TaskProgress = TaskProgressState.Completed,
                    TaskCategory = "PROJ",
                    Deadline = new DateTime(2025, 1, 29, 23, 59, 0)
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
                    CourseCode = "ALT",
                    CategoryCode = "ACT",
                    TaskDescription = "Do Home Act 4.",
                    TaskProgress = TaskProgressState.Completed,
                    TaskCategory = "ACT",
                    Deadline = new DateTime(2025, 1, 9, 18, 0, 0)
                },
                new TaskCardItem
                {
                    CourseCode = "APPDEV",
                    CategoryCode = "MEET",
                    TaskDescription = "Meet with group.",
                    TaskProgress = TaskProgressState.Completed,
                    TaskCategory = "MEET",
                    Deadline = new DateTime(2025, 1, 6, 15, 0, 0)
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
                },
                new TaskCardItem
                {
                    CourseCode = "ALT",
                    CategoryCode = "ACT",
                    TaskDescription = "Home act 7.",
                    TaskProgress = TaskProgressState.Completed,
                    TaskCategory = "ACT",
                    Deadline = new DateTime(2025, 1, 18, 6, 0, 0)
                },
                new TaskCardItem
                {
                    CourseCode = "PPL",
                    CategoryCode = "ORG",
                    TaskDescription = "Test 123.",
                    TaskProgress = TaskProgressState.NotStarted,
                    TaskCategory = "ORG",
                    Deadline = new DateTime(2025, 3, 1, 7, 0, 0)
                }
            };

            // Split the dummy tasks across categories based on progress
            foreach (var task in taskItems)
            {
                switch (task.TaskProgress)
                {
                    case TaskProgressState.NotStarted:
                        NotStartedTasks.Add(task);
                        break;
                    case TaskProgressState.InProgress:
                        InProgressTasks.Add(task);
                        break;
                    case TaskProgressState.Completed:
                        CompletedTasks.Add(task);
                        break;
                }

                // Debugging: Print task details to console
                Debug.WriteLine($"Added Sample Task: {task.CourseCode}, {task.CategoryCode}, {task.TaskDescription}, {task.TaskProgress}, {task.Deadline}");
            }
        }

        // Notify UI when data changes
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        private void PrintCollections()
        {
            Debug.WriteLine("-----------------------PRINT IS CALLED");
            Debug.WriteLine("Not Started Tasks:");
            foreach (var task in NotStartedTasks)
            {
                Debug.WriteLine($"CourseCode: {task.CourseCode}, Name: {task.TaskDesc}, Progress: {task.TaskProgress}, DueDate: {task.Deadline}");
            }

            Debug.WriteLine("In Progress Tasks:");
            foreach (var task in InProgressTasks)
            {
                Debug.WriteLine($"CourseCode: {task.CourseCode}, Name: {task.TaskDesc}, Progress: {task.TaskProgress}, DueDate: {task.Deadline}");
            }

            Debug.WriteLine("Completed Tasks:");
            foreach (var task in CompletedTasks)
            {
                Console.WriteLine($"CourseCode: {task.CourseCode}, Name: {task.TaskDesc}, Progress: {task.TaskProgress}, DueDate: {task.Deadline}");
            }
        }
    }
}
