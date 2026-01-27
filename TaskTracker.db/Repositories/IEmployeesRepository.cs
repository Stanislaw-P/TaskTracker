using TaskTracker.db.Models;

namespace TaskTracker.db.Repositories
{
    public interface IEmployeesRepository
    {
        Task AddAsync(Employee employee);
        Task DeleteAsync(Employee employee);
        Task<List<Employee>> GetAllAsync();
        Task<Employee?> TryGetByIdAsync(int id);
        Task UpdateAsync(Employee employee);
    }
}