using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager
{
    public class HomeTask : TaskApp
    {
        public string Room { get; set; }

        public HomeTask(string title, string description, DateTime? dueDate, string room)
            : base(title, description, dueDate)
        {
            Room = room;
        }

        public override string ToString()
        {
            return base.ToString() + $" | Room: {Room}";
        }
    }
}
