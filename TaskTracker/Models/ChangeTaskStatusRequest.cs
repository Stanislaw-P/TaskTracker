using TaskTracker.db.Helpers;

namespace TaskTracker.Models
{
    public class ChangeTaskStatusRequest
    {
        public TaskItemStatus NewStatus { get; set; }
        public uint RowVersion { get; set; } 
    }
}
