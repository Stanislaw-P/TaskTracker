
using TaskTracker.db.Helpers;

namespace TaskTracker.db.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        public int ProjectId { get; private set; }
        public Project Project { get; set; } = null!;

        public int TaskGroupId { get; private set; }
        public TaskGroup TaskGroup { get; set; } = null!;

        public DateTime Deadline { get; set; }

        public DateTime CreatedAt { get; private set; }

        public TaskItemStatus Status { get; set; }
        public TaskPriority Priority { get; set; }

        public List<TaskExecutor> Executors { get; set; } = new List<TaskExecutor>();
        public List<TaskWatcher> Watchers { get; set; } = new List<TaskWatcher>();

        private TaskItem() { } // для EF

        public TaskItem(
            string title,
            string description,
            int projectId,
            int taskGroupId,
            DateTime deadline,
            TaskItemStatus status,
            TaskPriority priority)
        {
            if (status != TaskItemStatus.Backlog &&
                status != TaskItemStatus.Current)
            {
                throw new ArgumentException(
                    "При создании задача может быть только в статусе Backlog или Current");
            }

            Title = title;
            Description = description;
            ProjectId = projectId;
            TaskGroupId = taskGroupId;
            Deadline = deadline;
            Status = status;
            Priority = priority;

            CreatedAt = DateTime.UtcNow;
        }
    }
}
