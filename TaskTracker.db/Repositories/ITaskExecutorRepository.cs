using TaskTracker.db.Models;

namespace TaskTracker.db.Repositories
{
    public interface ITaskExecutorRepository
    {
        Task AddAsync(TaskExecutor taskExecutor);
        Task DeleteAsync(TaskExecutor taskExecutor);
        Task<bool> ExistsAsync(int taskItemId, int employeeId);
    }
}