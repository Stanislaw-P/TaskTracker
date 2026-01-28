using TaskTracker.db.Models;

namespace TaskTracker.db.Repositories
{
    public interface ITaskGroupRepository
    {
        Task AddAsync(TaskGroup taskGroup);
        Task DeleteAsync(TaskGroup taskGroup);
        Task<List<TaskGroup>> GetAllAsync();
        Task<TaskGroup?> TryGetByIdAsync(int id);
        Task UpdateAsync(TaskGroup taskGroup);
    }
}