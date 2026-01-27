using Microsoft.EntityFrameworkCore;
using TaskTracker.db.Models;

namespace TaskTracker.db.Repositories
{
    public class EmployeesInDbRepository : IEmployeesRepository
    {
        readonly DatabaseContext _databaseContext;

        public EmployeesInDbRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<List<Employee>> GetAllAsync()
        {
            var employees = await _databaseContext.Employees.ToListAsync();
            return employees;
        }

        public async Task<Employee?> TryGetByIdAsync(int id)
        {
            return await _databaseContext.Employees.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AddAsync(Employee employee)
        {
            await _databaseContext.Employees.AddAsync(employee);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Employee employee)
        {
            _databaseContext.Employees.Update(employee);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Employee employee)
        {
            _databaseContext.Employees.Remove(employee);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
