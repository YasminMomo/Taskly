using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasklyApp.Views;
using TasklyApp.Models.SubjectSchedule;


namespace TasklyApp.ViewModels
{
    public class SubjectScheduleModel
    {
        public ObservableCollection<Models.SubjectSchedule.SubjectSchedule> Schedules { get; set; }

        public SubjectScheduleModel()
        {
            // Initialize the ObservableCollection
            Schedules = new ObservableCollection<Models.SubjectSchedule.SubjectSchedule>();

            // Fetch data asynchronously
            LoadSchedulesAsync();
        }

        private async void LoadSchedulesAsync()
        {
            var schedules = await SubjectScheduleManager.GetScheduleAsync();
            Schedules.Clear();

            foreach (var schedule in schedules)
            {
                Schedules.Add(schedule);
            }
        }
    }

}
