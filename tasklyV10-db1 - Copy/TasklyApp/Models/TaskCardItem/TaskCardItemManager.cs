/*
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TasklyApp.Services;
using TasklyApp.Models;
using System;

namespace TasklyApp.Models
{
    public class TaskCardItemManager
    {
        private static readonly DatabaseService _dbService = new DatabaseService();
        public static ObservableCollection<TaskCardItem> _DatabaseTaskCards = new ObservableCollection<TaskCardItem>();

        // Fetch the latest task card items from the database or use dummy data if database is unavailable
        public static async Task<ObservableCollection<TaskCardItem>> GetTaskCardsAsync()
        {
            try
            {
                // Try to fetch from the database
                var taskCards = await _dbService.GetAllTasksAsync();
                _DatabaseTaskCards.Clear();
                foreach (var taskCard in taskCards)
                {
                    //_DatabaseTaskCards.Add(taskCard);
                    // Debugging: Print task details to console
                    Console.WriteLine($"Added task from DB: {taskCard.CourseCode}, {taskCard.CategoryCode}, {taskCard.TaskDescription}, {taskCard.TaskProgress}, {taskCard.Deadline}");
                }
            }
            catch
            {
                // Handle the error or fallback if needed
                Console.WriteLine("Failed to fetch data from database.");
            }

            return _DatabaseTaskCards;
        }
    }
}

*/