using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.db.Models
{
    public class TaskGroup
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public List<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
}
