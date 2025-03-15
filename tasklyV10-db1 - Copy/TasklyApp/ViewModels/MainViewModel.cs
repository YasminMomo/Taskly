using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using AddTaskModal.ViewModels;

namespace TasklyApp.ViewModels
{
    public class MainViewModel
    {

        public CurrentDateModel CurrentDateModel { get; set; }
        public TaskOverviewModel TaskOverviewModel { get; set; }
        public SubjectScheduleModel SubjectScheduleModel { get; set; }
        public AddTaskModel AddTaskModel { get; set; }


        public MainViewModel()
        {
            CurrentDateModel = new CurrentDateModel();
            TaskOverviewModel = new TaskOverviewModel();
            SubjectScheduleModel = new SubjectScheduleModel();
            AddTaskModel = new AddTaskModel();
        }
    }

}