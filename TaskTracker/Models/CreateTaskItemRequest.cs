using TaskTracker.db.Helpers;
using TaskTracker.db.Models;

namespace TaskTracker.Models
{
    public class CreateTaskItemRequest
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        public int ProjectId { get; set; }

        public int TaskGroupId { get; set; }

        public DateTime Deadline { get; set; }

        public TaskItemStatus Status { get; set; }
        public TaskPriority Priority { get; set; }
    }
}
