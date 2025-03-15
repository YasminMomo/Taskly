using System;
using System.Collections.Generic;
using System.ComponentModel;
using TasklyApp.Commands;
using TasklyApp.Models;
using TasklyApp.Services;

namespace TasklyApp.ViewModels
{
    public class TaskViewModel : INotifyPropertyChanged
    {
        // Private fields
        private string courseCode;
        private string categoryCode;
        private string taskDescription;
        private Progress progress;
        private DateTime deadline;

        private readonly DatabaseService databaseService;

        // Constructor
        public TaskViewModel()
        {
            databaseService = new DatabaseService();
            SubmitCommand = new RelayCommand(async () => await SubmitTaskAsync(), CanSubmitTask);
        }

        // Properties for data binding
        public string CourseCode
        {
            get => courseCode;
            set
            {
                courseCode = value;
                OnPropertyChanged(nameof(CourseCode));
            }
        }

        public string CategoryCode
        {
            get => categoryCode;
            set
            {
                categoryCode = value;
                OnPropertyChanged(nameof(CategoryCode));
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
                    OnPropertyChanged(nameof(TaskDescription));
                }
            }
        }

        public Progress Progress
        {
            get => progress;
            set
            {
                progress = value;
                OnPropertyChanged(nameof(Progress));
            }
        }

        public DateTime Deadline
        {
            get => deadline;
            set
            {
                deadline = value;
                OnPropertyChanged(nameof(Deadline));
            }
        }

        // Command for submitting the task
        public RelayCommand SubmitCommand { get; }

        // Submit Task method
        private async Task SubmitTaskAsync()
        {
            var taskItem = new TaskItem
            {
                CourseCode = this.CourseCode,
                CategoryCode = this.CategoryCode,
                TaskDesc = this.TaskDescription,
                Progress = this.Progress.ToString(), // Assuming Progress is an enum
                Deadline = this.Deadline
            };

            // Call the DatabaseService to save the task to the database
            bool success = await databaseService.SaveTaskItemAsync(taskItem);
            if (success)
            {
                // Optionally notify user that task has been saved
                // For example, you could use a message box, or update a UI element
            }
            else
            {
                // Handle failure
            }
        }

        // CanSubmitTask logic for validation before enabling the Submit button
        private bool CanSubmitTask()
        {
            // Here you can return true or false based on your conditions for the submit button to be enabled.
            // For example, check if all required fields are filled out or valid.
            return !string.IsNullOrEmpty(CourseCode) && !string.IsNullOrEmpty(CategoryCode) && !string.IsNullOrEmpty(TaskDescription);
        }

        // Event for INotifyPropertyChanged to update the UI when properties change
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}