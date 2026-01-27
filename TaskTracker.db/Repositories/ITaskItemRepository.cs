using TaskTracker.db.Models;

namespace TaskTracker.db.Repositories
{
    public interface ITaskItemRepository
    {
        Task AddAsync(TaskItem taskItem);
        Task DeleteAsync(TaskItem taskItem);
        Task<List<TaskItem>> GetAllAsync(int? employeeId, int? taskGroupId, int? projectId);
        Task<TaskItem?> TryGetByIdAsync(int id);
        Task UpdateAsync(TaskItem taskItem);
    }
}