using TaskTracker.db.Models;

namespace TaskTracker.db.Repositories
{
    public interface IProjectsRepository
    {
        Task AddAsync(Project project);
        Task DeleteAsync(Project project);
        Task<List<Project>> GetAllAsync();
        Task<Project?> TryGetByIdAsync(int id);
        Task UpdateAsync(Project project);
    }
}