using TaskTracker.db.Helpers;

namespace TaskTracker.Models
{
    public class UpdateTaskItemRequest
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        public DateTime Deadline { get; set; }

        public TaskPriority Priority { get; set; }
    }
}
