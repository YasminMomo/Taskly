using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasklyApp.Services;

namespace TasklyApp.Models.SubjectSchedule
{
    public class SubjectScheduleManager
    {
        private static ObservableCollection<SubjectSchedule> _DatabaseTasks = new ObservableCollection<SubjectSchedule>();

        public static async Task<ObservableCollection<SubjectSchedule>> GetScheduleAsync()
        {
            // Fetch schedules asynchronously from DatabaseService
            var databaseService = new DatabaseService();
            var schedules = await databaseService.GetSubjectSchedulesAsync();

            // Clear existing data and add new schedules
            _DatabaseTasks.Clear();
            foreach (var schedule in schedules)
            {
                _DatabaseTasks.Add(schedule);
            }

            // Return the updated collection
            return _DatabaseTasks;
        }
    }

}
