using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using TasklyApp.Models;
using TasklyApp.Services;


namespace TasklyApp.Views
{
    public partial class TaskCard : UserControl, INotifyPropertyChanged
    {
        private readonly DatabaseService _databaseService;

        public static readonly DependencyProperty TaskProperty =
            DependencyProperty.Register("Task", typeof(TaskCardItem), typeof(TaskCard),
                new PropertyMetadata(null, OnTaskChanged));

        public TaskCardItem Task
        {
            get { return (TaskCardItem)GetValue(TaskProperty); }
            set { SetValue(TaskProperty, value); }
        }

        private string courseCodeText;
        private string deadlineText;
        private string taskCategoryText;
        private string taskDescText;
        private string selectedProgress = "Not Started";
        private string progressButtonColor = "#37CA26";

        public string CourseCodeText
        {
            get => courseCodeText;
            set { courseCodeText = value; OnPropertyChanged(nameof(CourseCodeText)); }
        }

        public string DeadlineText
        {
            get => deadlineText;
            set { deadlineText = value; OnPropertyChanged(nameof(DeadlineText)); }
        }

        public string TaskCategoryText
        {
            get => taskCategoryText;
            set { taskCategoryText = value; OnPropertyChanged(nameof(TaskCategoryText)); }
        }

        public string TaskDescText
        {
            get => taskDescText;
            set { taskDescText = value; OnPropertyChanged(nameof(TaskDescText)); }
        }

        public string SelectedProgress
        {
            get { return selectedProgress; }
            set
            {
                if (selectedProgress != value)
                {
                    selectedProgress = value;
                    OnPropertyChanged(nameof(SelectedProgress));
                }
            }
        }

        public string ProgressButtonColor
        {
            get => progressButtonColor;
            set
            {
                if (progressButtonColor != value)
                {
                    progressButtonColor = value;
                    OnPropertyChanged(nameof(ProgressButtonColor));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Progress Dropdown Functions

        private void OpenProgressDropdown(object sender, RoutedEventArgs e)
        {
            ProgressPopup.IsOpen = !ProgressPopup.IsOpen;
        }

        private async void ProgressSelected(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                string newProgress = button.Content.ToString();
                SelectedProgress = newProgress;

                // Display the selected progress value
                Debug.WriteLine($"------ >>> [ProgressSelected] SHOULD BE UPDATED TO: {SelectedProgress}");

                ProgressButtonColor = newProgress switch
                {
                    "Not Started" => "#37CA26",
                    "In Progress" => "#FE761C",
                    "Completed" => "#FE321C",
                    _ => "#37CA26"
                };

                ProgressPopup.IsOpen = false;

                if (Task != null)
                {
                    // Try to parse the newProgress string to TaskProgressState
                    if (Enum.TryParse<TaskProgressState>(newProgress, out TaskProgressState parsedProgress))
                    {
                        /*
                        bool isUpdated = await _databaseService.UpdateTaskProgressAsync(Task.TaskID, parsedProgress);
                        if (isUpdated)
                        {
                            Debug.WriteLine($">>> [TaskCard] Task progress updated to: {parsedProgress}");
                        }
                        else
                        {
                            Debug.WriteLine(">>> [TaskCard] Failed to update task progress.");
                        }
                        */
                    }
                    else
                    {
                        Debug.WriteLine(">>> [TaskCard] Invalid progress state.");
                    }
                }

            }
        }

        #endregion

        public TaskCard()
        {
            InitializeComponent();
            DataContext = this;
        }

        private static void OnTaskChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TaskCard taskCard && e.NewValue is TaskCardItem task)
            {
                taskCard.CourseCodeText = task.CourseCode;
                taskCard.DeadlineText = task.Deadline.ToString("MMMM dd, yyyy"); // Example format: "October 10, 2024"
                taskCard.TaskCategoryText = task.TaskCategory;
                taskCard.TaskDescText = task.TaskDescription;

                Debug.WriteLine($">>>[TaskCard] Updated Data: {task.CourseCode}, {task.TaskDescription}, {task.TaskProgress}, {task.Deadline}");
            }
            else
            {
                Debug.WriteLine("[TaskCard] Task is null!");
            }
        }
    }

    public enum Progress
    {
        NotStarted,
        InProgress,
        Completed
    }







}
