using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    public class StudyTask : TaskApp
    {
        public string Subject { get; set; }

        public StudyTask(string title, string description, DateTime? dueDate, string subject)
            : base(title, description, dueDate)
        {
            Subject = subject;
        }

        public override string ToString()
        {
            return base.ToString() + $" | Subject: {Subject}";
        }
    }
}
