namespace TasklyApp.Models
{
    public class TaskCardItem
    {
        public int TaskID { get; set; }
        public string TaskDescription { get; set; }
        public TaskProgressState TaskProgress { get; set; } // Renamed enum
        public string CourseCode { get; set; } // New property for CourseCode
        public string CategoryCode { get; set; } // New property for CategoryCode
        public string TaskDesc { get; set; } // Duplicate property, consider removing it if not needed

        public string TaskCategory { get; set; } // Duplicate property, consider removing it if not needed

        public DateTime Deadline { get; set; } // New property for Deadline
    }

    // Enum for task progress states
    public enum TaskProgressState
    {
        NotStarted,
        InProgress,
        Completed
    }
}
