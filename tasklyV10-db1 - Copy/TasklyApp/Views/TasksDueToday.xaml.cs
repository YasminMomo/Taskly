using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using TasklyApp.ViewModels;
using TasklyApp.Models;

namespace TasklyApp.Views
{
    public partial class TasksDueToday : UserControl
    {
        public TasksDueTodayViewModel TasksDueTodayViewModel { get; set; }

        public TasksDueToday()
        {
            InitializeComponent();

            // Initialize the ViewModel and set it as the DataContext
            TasksDueTodayViewModel = new TasksDueTodayViewModel();
            this.DataContext = TasksDueTodayViewModel;

            DebugTaskCollection();
            AddTasksToStackPanel();
        }

        private void AddTasksToStackPanel()
        {
            // Clear any existing TaskCards
            TasksDueTodayStackPanel.Children.Clear();

            // Add TaskCards for each task in the ViewModel
            foreach (var task in TasksDueTodayViewModel.TasksDueToday)
            {
                var taskCard = new TaskCard
                {
                    Task = task
                };
                TasksDueTodayStackPanel.Children.Add(taskCard);
            }
        }

        private void DebugTaskCollection()
        {
            Debug.WriteLine("------------------------------------------ TODAY'S COLLECTION PRINTING HERE V2");
            Debug.WriteLine("Debugging Task Collections:");

            foreach (var task in TasksDueTodayViewModel.TasksDueToday)
            {
                Debug.WriteLine($"- {task.CourseCode}, {task.TaskDescription}, {task.TaskProgress}, Due: {task.Deadline}");
            }
        }
    }
}
