
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

        public uint RowVersion { get; private set; }

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

        public void ChangeStatus(TaskItemStatus newStatus)
        {
            if (!IsValidTransition(Status, newStatus))
                throw new InvalidOperationException(
                    $"Недопустимый переход статуса: {Status} → {newStatus}");

            Status = newStatus;
        }

        private static bool IsValidTransition(TaskItemStatus current, TaskItemStatus next)
        {
            return current switch
            {
                TaskItemStatus.Backlog => next is
                    TaskItemStatus.Current or
                    TaskItemStatus.Cancelled,

                TaskItemStatus.Current => next is
                    TaskItemStatus.Active or
                    TaskItemStatus.Cancelled,

                TaskItemStatus.Active => next is
                    TaskItemStatus.Testing or
                    TaskItemStatus.Cancelled,

                TaskItemStatus.Testing => next is
                    TaskItemStatus.Active or
                    TaskItemStatus.Done or
                    TaskItemStatus.Cancelled,

                _ => false // Done, Cancelled — конечные
            };
        }
    }
}
