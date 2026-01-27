using TaskTracker.db.Models;

namespace TaskTracker.db.Repositories
{
    public interface ITaskWatcherRepository
    {
        Task AddAsync(TaskWatcher taskWatcher);
        Task DeleteAsync(TaskWatcher taskWatcher);
        Task<bool> ExistsAsync(int taskItemId, int employeeId);
    }
}