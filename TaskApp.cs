using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    public enum TaskState
    {
        Pending,
        InProgress,
        Done
    }

    public class TaskApp
    {
        private static int _nextId = 1;
        private static List<TaskApp> _allTasks = new List<TaskApp>();

        public int Id { get; }

        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _title = "NO TITLE";
                }
                else
                {
                    _title = value.Trim();
                }
            }
        }

        public string Description { get; set; }

        public DateTime? DueDate { get; private set; }

        public TaskState Status { get; private set; }

        public TaskApp(string title, string description, DateTime? dueDate)
        {
            Id = _nextId++;
            Title = title;
            Description = description;
            SetDueDate(dueDate);
            Status = TaskState.Pending;
        }

        public void SetDueDate(DateTime? date)
        {
            if (date.HasValue && date.Value.Date >= DateTime.Today)
            {
                DueDate = date.Value.Date;
            }
            else
            {
                DueDate = null;
            }
        }

        public bool MarkAsDone()
        {
            if (Status == TaskState.Done)
            {
                return false;
            }

            Status = TaskState.Done;
            return true;
        }

        public string GetFormattedDueDate()
        {
            if (DueDate == null)
                return "No due date";

            return DueDate.Value.ToString("dd-MM-yyyy");
        }

        public override string ToString()
        {
            return $"[{Id}] {Title} | {Status} | {GetFormattedDueDate()}";
        }

        public static List<TaskApp> AddTask(TaskApp task)
        {
            if (task != null)
            {
                _allTasks.Add(task);
            }

            return ListAllTasks();
        }

        public static List<TaskApp> ListAllTasks()
        {
            return new List<TaskApp>(_allTasks);
        }

        public static List<TaskApp> SearchByTitle(string titlePart)
        {
            var results = new List<TaskApp>();

            if (string.IsNullOrWhiteSpace(titlePart))
                return results;

            string pattern = titlePart.Trim().ToLowerInvariant();

            foreach (var task in _allTasks)
            {
                if (task.Title != null &&
                    task.Title.ToLowerInvariant().Contains(pattern))
                {
                    results.Add(task);
                }
            }

            return results;
        }

        public static List<TaskApp> SearchByStatus(TaskState status)
        {
            var results = new List<TaskApp>();

            foreach (var task in _allTasks)
            {
                if (task.Status == status)
                {
                    results.Add(task);
                }
            }

            return results;
        }
    }
}
