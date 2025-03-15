using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using TasklyApp.Models;
using TasklyApp.Services;

namespace TasklyApp.Views
{
    public partial class AddTaskModal : UserControl, INotifyPropertyChanged
    {
        // Private fields for selections
        private string selectedCourseCode;
        private string taskDescription;
        private string selectedCategory;
        private DateTime? selectedDate;
        private string selectedTime;
        private string selectedProgress = "Not Started";

        // Button color properties
        private string progressButtonColor = "#37CA26";
        private string courseButtonColor = "#37CA26";
        private string categoryButtonColor = "#37CA26";

        // Properties for Course, Category, Progress, and DateTime

        public string SelectedCourseCode
        {
            get { return selectedCourseCode; }
            set
            {
                if (selectedCourseCode != value)
                {
                    selectedCourseCode = value;
                    OnPropertyChanged(nameof(SelectedCourseCode));
                }
            }
        }

        public string TaskDescription
        {
            get => taskDescription;
            set
            {
                if (taskDescription != value)
                {
                    taskDescription = value;
                    OnPropertyChanged(nameof(TaskDescription)); // Notify UI of the change
                }
            }
        }

        public string SelectedCategory
        {
            get { return selectedCategory; }
            set
            {
                if (selectedCategory != value)
                {
                    selectedCategory = value;
                    OnPropertyChanged(nameof(SelectedCategory));
                }
            }
        }

        public DateTime? SelectedDate
        {
            get => selectedDate;
            set
            {
                selectedDate = value;
                OnPropertyChanged(nameof(SelectedDate));
                UpdateCombinedDatetime();
            }
        }

        public string SelectedTime
        {
            get => selectedTime;
            set
            {
                selectedTime = value;
                OnPropertyChanged(nameof(SelectedTime));
                UpdateCombinedDatetime();
            }
        }

        private string selectedDatetimeDisplay;
        public string SelectedDatetimeDisplay
        {
            get => selectedDatetimeDisplay;
            private set
            {
                selectedDatetimeDisplay = value;
                OnPropertyChanged(nameof(SelectedDatetimeDisplay));
            }
        }

        private void UpdateCombinedDatetime()
        {
            if (SelectedDate.HasValue)
            {
                string normalizedTime = SelectedTime.Trim().ToLower();
                if (!normalizedTime.EndsWith("am") && !normalizedTime.EndsWith("pm"))
                {
                    normalizedTime += "am"; // Default to AM if no AM/PM is specified
                }

                if (DateTime.TryParseExact(normalizedTime, new[] { "h:mm tt", "h:mm", "hh:mm tt", "hh:mm", "h tt", "hh tt" }, null, System.Globalization.DateTimeStyles.None, out var time))
                {
                    var formattedTime = time.ToString("HH:mm");
                    var combined = SelectedDate.Value.Date.Add(time.TimeOfDay);

                    // Debug output
                    Debug.WriteLine($"Combined DateTime: {combined}");

                    SelectedDatetimeDisplay = combined.ToString("yyyy-MM-dd HH:mm:ss");
                }
                else
                {
                    SelectedDatetimeDisplay = "Invalid date or time";
                }
            }
            else
            {
                SelectedDatetimeDisplay = "Invalid date or time";
            }
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

        public string CourseButtonColor
        {
            get => courseButtonColor;
            set
            {
                if (courseButtonColor != value)
                {
                    courseButtonColor = value;
                    OnPropertyChanged(nameof(CourseButtonColor));
                }
            }
        }

        public string CategoryButtonColor
        {
            get => categoryButtonColor;
            set
            {
                if (categoryButtonColor != value)
                {
                    categoryButtonColor = value;
                    OnPropertyChanged(nameof(CategoryButtonColor));
                }
            }
        }

        public AddTaskModal()
        {
            InitializeComponent();
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region Course Code Dropdown Functions

        private void OpenCourseCodeDropdown(object sender, RoutedEventArgs e)
        {
            CourseCodePopup.IsOpen = !CourseCodePopup.IsOpen;
        }

        private void CourseCodeSelected(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                SelectedCourseCode = button.Content.ToString();
                Debug.WriteLine($"Selected Course Code: {SelectedCourseCode}");

                CourseButtonColor = SelectedCourseCode switch
                {
                    "COAL" => "#37CA26",
                    "PPL" => "#FE761C",
                    "ADET" => "#FE321C",
                    _ => "#37CA26"
                };

                CourseCodePopup.IsOpen = false;
            }
        }

        #endregion

        #region Category Dropdown Functions

        private void OpenCategoryDropdown(object sender, RoutedEventArgs e)
        {
            CategoryPopup.IsOpen = !CategoryPopup.IsOpen;
        }

        private void CategorySelected(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                SelectedCategory = button.Content.ToString();
                Debug.WriteLine($"Selected Category: {SelectedCategory}");

                CategoryButtonColor = SelectedCategory switch
                {
                    "ACT" => "#37CA26",
                    "GRP" => "#FE761C",
                    "MEET" => "#FE321C",
                    "ORG" => "#37CA26",
                    "PROJ" => "#FE761C",
                    "QUIZ" => "#FE321C",
                    "TEST" => "#37CA26",
                    _ => "#37CA26"
                };

                CategoryPopup.IsOpen = false;
            }
        }

        #endregion

        #region Progress Dropdown Functions

        private void OpenProgressDropdown(object sender, RoutedEventArgs e)
        {
            ProgressPopup.IsOpen = !ProgressPopup.IsOpen;
        }

        private void ProgressSelected(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                SelectedProgress = button.Content.ToString();

                ProgressButtonColor = SelectedProgress switch
                {
                    "Not Started" => "#37CA26",
                    "In Progress" => "#FE761C",
                    "Completed" => "#FE321C",
                    _ => "#37CA26"
                };

                ProgressPopup.IsOpen = false;
            }
        }

        #endregion
        private async void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SelectedCourseCode) || string.IsNullOrEmpty(taskDescription) || string.IsNullOrEmpty(SelectedCategory) || !SelectedDate.HasValue || string.IsNullOrEmpty(SelectedProgress))
            {
                MessageBox.Show("Please fill in all required fields.");
                return;
            }

            if (string.IsNullOrEmpty(SelectedTime) || !DateTime.TryParse(SelectedTime, out var parsedTime))
            {
                MessageBox.Show("Please provide a valid time.");
                return;
            }

            // Combine the selected date and time
            DateTime combinedDateTime = SelectedDate.Value.Date.Add(parsedTime.TimeOfDay);

            // Create the task item
            TaskItem newTask = new TaskItem
            {
                CourseCode = SelectedCourseCode,
                CategoryCode = SelectedCategory,
                TaskDesc = taskDescription,
                Progress = SelectedProgress,
                Deadline = combinedDateTime
            };

            Debug.WriteLine("Created Task Item:");
            Debug.WriteLine($"Course Code: {newTask.CourseCode}");
            Debug.WriteLine($"Category Code: {newTask.CategoryCode}");
            Debug.WriteLine($"Description: {newTask.TaskDesc}");
            Debug.WriteLine($"Progress: {newTask.Progress}");
            Debug.WriteLine($"Combined DateTime: {combinedDateTime.ToString("yyyy-MM-dd HH:mm:ss")}");

            // Saving the task item to the database
            var databaseService = new DatabaseService();
            bool isSaved = await databaseService.SaveTaskItemAsync(newTask);
            // Simulate saving to the database (remove when connected to actual DB)
            isSaved = true;

            if (isSaved)
            {
                MessageBox.Show("Task saved successfully!");
            }
            else
            {
                MessageBox.Show("Failed to save task.");
            }
        }
    }
}
