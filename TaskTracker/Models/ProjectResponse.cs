using TaskTracker.db.Models;

namespace TaskTracker.Models
{
    public class ProjectResponse
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public int ProjectLeadId { get; set; }

        public int ProjectManagerId { get; set; }

        public List<int> TasksIds { get; set; } = new List<int>();
    }
}
