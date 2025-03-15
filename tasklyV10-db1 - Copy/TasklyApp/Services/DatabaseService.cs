using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows; // Required for MessageBox
using TasklyApp.Models;
using TasklyApp.Models.SubjectSchedule;


namespace TasklyApp.Services
{
    public class DatabaseService
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        // Test database connection
        public async Task<bool> TestDatabaseConnectionAsync()
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to connect to the database: {ex.Message}", "Connection Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        // Get task overview (counts)
        public async Task<TaskOverview> GetTaskOverviewAsync()
        {
            TaskOverview taskOverview = new TaskOverview();

            // Ensure the database connection is available
            if (!await TestDatabaseConnectionAsync())
            {
                return taskOverview;
            }

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    string query = @"
                        SELECT 
                            SUM(CASE WHEN strProgress IN ('Not Started', 'In Progress') THEN 1 ELSE 0 END) AS Total,
                            SUM(CASE WHEN strProgress = 'Not Started' THEN 1 ELSE 0 END) AS Todo,
                            SUM(CASE WHEN strProgress = 'In Progress' THEN 1 ELSE 0 END) AS OnGoing,
                            SUM(CASE WHEN strProgress = 'Completed' THEN 1 ELSE 0 END) AS Done
                        FROM tblTasks";


                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (reader.Read())
                        {
                            taskOverview.Total = reader["Total"].ToString();
                            taskOverview.Todo = reader["Todo"].ToString();
                            taskOverview.OnGoing = reader["OnGoing"].ToString();
                            taskOverview.Done = reader["Done"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching task overview: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return taskOverview;
        }


        // Fetch tasks based on their progress
        // Fetch tasks with 'Not Started' progress
        public async Task<List<TaskCardItem>> GetNotStartedTasksAsync()
        {
            List<TaskCardItem> taskCardItems = new List<TaskCardItem>();

            if (!await TestDatabaseConnectionAsync())
            {
                Console.WriteLine("Database connection failed.");
                return taskCardItems;
            }

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    Console.WriteLine("Fetching Not Started tasks.");

                    string query = @"
                SELECT strCourseAbbre, strCategoryCode, txtTaskDesc, strProgress, dtmDeadline 
                FROM tblTasks 
                WHERE strProgress = 'Not Started'";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var task = new TaskCardItem
                                {
                                    CourseCode = reader["strCourseAbbre"].ToString(),
                                    CategoryCode = reader["strCategoryCode"].ToString(),
                                    TaskDescription = reader["txtTaskDesc"].ToString(),
                                    TaskProgress = TaskProgressState.NotStarted,
                                    Deadline = Convert.ToDateTime(reader["dtmDeadline"])
                                };

                                taskCardItems.Add(task);

                                // Debugging: Print each task fetched from the database
                                Console.WriteLine($"[DB] Task Fetched: {task.CourseCode}, {task.CategoryCode}, {task.TaskDescription}, {task.TaskProgress}, {task.Deadline}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching tasks: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return taskCardItems;
        }

        // Fetch tasks with 'In Progress' progress
        public async Task<List<TaskCardItem>> GetInProgressTasksAsync()
        {
            List<TaskCardItem> taskCardItems = new List<TaskCardItem>();

            if (!await TestDatabaseConnectionAsync())
            {
                Console.WriteLine("Database connection failed.");
                return taskCardItems;
            }

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    Console.WriteLine("Fetching In Progress tasks.");

                    string query = @"
                SELECT strCourseAbbre, strCategoryCode, txtTaskDesc, strProgress, dtmDeadline 
                FROM tblTasks 
                WHERE strProgress = 'In Progress'";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var task = new TaskCardItem
                                {
                                    CourseCode = reader["strCourseAbbre"].ToString(),
                                    CategoryCode = reader["strCategoryCode"].ToString(),
                                    TaskDescription = reader["txtTaskDesc"].ToString(),
                                    TaskProgress = TaskProgressState.InProgress,
                                    Deadline = Convert.ToDateTime(reader["dtmDeadline"])
                                };

                                taskCardItems.Add(task);

                                // Debugging: Print each task fetched from the database
                                Console.WriteLine($"[DB] Task Fetched: {task.CourseCode}, {task.CategoryCode}, {task.TaskDescription}, {task.TaskProgress}, {task.Deadline}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching tasks: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return taskCardItems;
        }

        // Fetch tasks with 'Completed' progress
        public async Task<List<TaskCardItem>> GetCompletedTasksAsync()
        {
            List<TaskCardItem> taskCardItems = new List<TaskCardItem>();

            if (!await TestDatabaseConnectionAsync())
            {
                Console.WriteLine("Database connection failed.");
                return taskCardItems;
            }

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    Console.WriteLine("Fetching Completed tasks.");

                    string query = @"
                SELECT strCourseAbbre, strCategoryCode, txtTaskDesc, strProgress, dtmDeadline 
                FROM tblTasks 
                WHERE strProgress = 'Completed'";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var task = new TaskCardItem
                                {
                                    CourseCode = reader["strCourseAbbre"].ToString(),
                                    CategoryCode = reader["strCategoryCode"].ToString(),
                                    TaskDescription = reader["txtTaskDesc"].ToString(),
                                    TaskProgress = TaskProgressState.Completed,
                                    Deadline = Convert.ToDateTime(reader["dtmDeadline"])
                                };

                                taskCardItems.Add(task);

                                // Debugging: Print each task fetched from the database
                                Console.WriteLine($"[DB] Task Fetched: {task.CourseCode}, {task.CategoryCode}, {task.TaskDescription}, {task.TaskProgress}, {task.Deadline}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching tasks: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return taskCardItems;
        }


        // Fetch Subject Schedules
        public async Task<List<SubjectSchedule>> GetSubjectSchedulesAsync()
        {
            List<SubjectSchedule> schedules = new List<SubjectSchedule>();

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    string query = "SELECT strCourseAbbre, strSchedule FROM tblSchedule";

                    using (var command = new MySqlCommand(query, connection))
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            schedules.Add(new SubjectSchedule
                            {
                                Subject = reader["strCourseAbbre"].ToString(),
                                Time = reader["strSchedule"].ToString()
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching schedules: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            return schedules;
        }

        public async Task<bool> SaveTaskItemAsync(TaskItem taskItem)
        {
            // Check the database connection first
            if (!await TestDatabaseConnectionAsync())
            {
                return false; // Exit early if the connection fails
            }

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    // SQL query to insert a task into tblTasks
                    string query = @"
                        INSERT INTO tblTasks 
                        (strCourseAbbre, strCategoryCode, txtTaskDesc, strProgress, dtmDeadline) 
                        VALUES 
                        (@CourseCode, @CategoryCode, @TaskDesc, @Progress, @Deadline)"
                    ;

                    using (var command = new MySqlCommand(query, connection))
                    {

                        // Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@CourseCode", taskItem.CourseCode);
                        command.Parameters.AddWithValue("@CategoryCode", taskItem.CategoryCode);
                        command.Parameters.AddWithValue("@TaskDesc", taskItem.TaskDesc);
                        command.Parameters.AddWithValue("@Progress", taskItem.Progress);
                        command.Parameters.AddWithValue("@Deadline", taskItem.Deadline);

                        // Execute the query
                        int result = await command.ExecuteNonQueryAsync();

                        // Return true if the query affected rows
                        return result > 0;
                    }
                }

            }
            catch (Exception ex)
            {
                // Handle exceptions (logging, displaying a message, etc.)
                MessageBox.Show($"An error occurred while saving the task: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }

        public async Task<bool> UpdateTaskProgressAsync(int taskId, TaskProgressState newProgress)
        {
            // Check the database connection
            if (!await TestDatabaseConnectionAsync())
            {
                return false;
            }

            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    await connection.OpenAsync();

                    string query = @"
                UPDATE tblTasks 
                SET strProgress = @NewProgress 
                WHERE id = @TaskId";

                    using (var command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@NewProgress", newProgress.ToString());
                        command.Parameters.AddWithValue("@TaskId", taskId);

                        int result = await command.ExecuteNonQueryAsync();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating task progress: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }



        // GET TASKS TODAY
        public async Task<List<TaskCardItem>> GetTasksDueTodayAsync()
        {
            var tasks = new List<TaskCardItem>();
            var query = "SELECT * FROM Tasks WHERE CAST(Deadline AS DATE) = CAST(GETDATE() AS DATE)"; // Adjust for your DB type

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                var command = new SqlCommand(query, connection);
                var reader = await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    tasks.Add(new TaskCardItem
                    {
                        TaskID = reader.GetInt32(reader.GetOrdinal("TaskID")),
                        TaskDescription = reader.GetString(reader.GetOrdinal("TaskDescription")),
                        TaskProgress = (TaskProgressState)Enum.Parse(typeof(TaskProgressState), reader.GetString(reader.GetOrdinal("TaskProgress"))),
                        Deadline = reader.GetDateTime(reader.GetOrdinal("Deadline")),
                        // Populate other fields as necessary
                    });
                }
            }

            return tasks;
        }

    }
}
