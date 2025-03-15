using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasklyApp.Models
{
    public class TaskItem
    {
        public string CourseCode { get; set; }
        public string CategoryCode { get; set; }
        public string TaskDesc { get; set; }
        public string Progress { get; set; } // You can also use an enum here
        public DateTime Deadline { get; set; }
    }

    // Enum for Progress
    public enum Progress
    {
        NotStarted,
        InProgress,
        Completed
    }
}
