using TaskTracker.db.Helpers;

namespace TaskTracker.Models
{
    public class TaskItemResponse
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int ProjectId { get; set; }
        public int TaskGroupId { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime CreatedAt { get; set; }
        public TaskItemStatus Status { get; set; }
        public TaskPriority Priority { get; set; }
        public uint RowVersion { get; set; }

        public List<int> ExecutorIds { get; set; } = new List<int>();
        public List<int> WatcherIds { get; set; } = new List<int>();
    }

}
