using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.db.Models
{
    public class Project
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public int ProjectLeadId { get; set; }
        public Employee ProjectLead { get; set; } = null!;

        public int ProjectManagerId { get; set; }
        public Employee ProjectManager { get; set; } = null!;

        public List<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
}
