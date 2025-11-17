using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TaskManager
{
    public class User
    {
        private static int _nextId = 1;
        private static List<User> _allUsers = new List<User>();

        public int Id { get; }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Trim().Length < 3)
                {
                    _name = "invalid name";
                }
                else
                {
                    _name = value.Trim();
                }
            }
        }

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                if (string.IsNullOrWhiteSpace(value) || !value.Contains("@") || !value.Contains("."))
                {
                    _email = "invalid email";
                }
                else
                {
                    _email = value.Trim();
                }
            }
        }

        public List<TaskApp> Tasks { get; }

        public User(string name, string email)
        {
            Id = _nextId++;
            Tasks = new List<TaskApp>();
            Name = name;
            Email = email;
        }

        public static void AddUser(User user)
        {
            if (user != null)
            {
                _allUsers.Add(user);
            }
        }

        public void AddUserTask(TaskApp task)
        {
            if (task != null)
            {
                Tasks.Add(task);
            }
        }

        public void RemoveUserTask(int taskId)
        {
            TaskApp taskToRemove = null;

            foreach (var task in Tasks)
            {
                if (task.Id == taskId)
                {
                    taskToRemove = task;
                    break;
                }
            }

            if (taskToRemove != null)
            {
                Tasks.Remove(taskToRemove);
            }
        }

        public List<TaskApp> GetActiveUserTasks()
        {
            var activeTasks = new List<TaskApp>();

            foreach (var task in Tasks)
            {
                if (task.Status != TaskState.Done)
                {
                    activeTasks.Add(task);
                }
            }

            return activeTasks;
        }

        public override string ToString()
        {
            return $"User {Id}: {Name} ({Email}) | Tasks: {Tasks.Count}";
        }
    }
}