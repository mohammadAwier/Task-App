using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    public class WorkTask : TaskApp
    {
        public string Company { get; set; }

        public WorkTask(string title, string description, DateTime? dueDate, string company)
            : base(title, description, dueDate)
        {
            Company = company;
        }

        public override string ToString()
        {
            return base.ToString() + $" | Company: {Company}";
        }
    }
}
