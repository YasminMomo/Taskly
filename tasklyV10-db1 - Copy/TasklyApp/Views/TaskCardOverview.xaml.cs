using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using TasklyApp.ViewModels;
using TasklyApp.Models;
using System.Diagnostics; // Ensure you have the TaskCardItem model

namespace TasklyApp.Views
{
    public partial class TaskCardOverview : UserControl
    {
        public TaskCardViewModel TaskCardViewModel { get; set; }

        public TaskCardOverview()
        {
            InitializeComponent();

            TaskCardViewModel = new TaskCardViewModel();
            this.DataContext = TaskCardViewModel;

            DebugTaskCollections();

            // After initializing, manually add TaskCardItems to each StackPanel
            AddTasksToCategories();
        }

        private void AddTasksToCategories()
        {
            // Clear any existing TaskCards
            NotStartedStackPanel.Children.Clear();
            InProgressStackPanel.Children.Clear();
            CompletedStackPanel.Children.Clear();

            // Add TaskCards for Not Started tasks
            foreach (var task in TaskCardViewModel.NotStartedTasks)
            {
                var taskCard = new TaskCard
                {
                    Task = task
                };
                NotStartedStackPanel.Children.Add(taskCard);
            }

            // Add TaskCards for In Progress tasks
            foreach (var task in TaskCardViewModel.InProgressTasks)
            {
                var taskCard = new TaskCard
                {
                    Task = task
                };
                InProgressStackPanel.Children.Add(taskCard);
            }

            // Add TaskCards for Completed tasks
            foreach (var task in TaskCardViewModel.CompletedTasks)
            {
                var taskCard = new TaskCard
                {
                    Task = task
                };
                CompletedStackPanel.Children.Add(taskCard);
            }
        }

        private void DebugTaskCollections()
        {
            Debug.WriteLine("------------------------------------------ COLLECTIONS PRINTING HERE V2");
            Debug.WriteLine("Debugging Task Collections:");

            Debug.WriteLine("NotStartedTasks:");
            foreach (var task in TaskCardViewModel.NotStartedTasks)
            {
                Debug.WriteLine($"- {task.CourseCode}, {task.TaskDescription}, {task.TaskProgress}, {task.Deadline}");
            }

            Debug.WriteLine("InProgressTasks:");
            foreach (var task in TaskCardViewModel.InProgressTasks)
            {
                Debug.WriteLine($"- {task.CourseCode}, {task.TaskDescription}, {task.TaskProgress}, {task.Deadline}");
            }

            Debug.WriteLine("CompletedTasks:");
            foreach (var task in TaskCardViewModel.CompletedTasks)
            {
                Debug.WriteLine($"- {task.CourseCode}, {task.TaskDescription}, {task.TaskProgress}, {task.Deadline}");
            }
        }

        private void AddTask_Click(object sender, RoutedEventArgs e)
        {
            AddTaskWindow addTaskWindow = new AddTaskWindow();
            addTaskWindow.Show();
        }

    }
}
