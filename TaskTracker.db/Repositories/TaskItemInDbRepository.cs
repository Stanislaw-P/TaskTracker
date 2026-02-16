using Microsoft.EntityFrameworkCore;
using TaskTracker.db.Models;

namespace TaskTracker.db.Repositories
{
    public class TaskItemInDbRepository : ITaskItemRepository
    {
        readonly DatabaseContext _databaseContext;

        public TaskItemInDbRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<List<TaskItem>> GetAllAsync(int? employeeId, int? taskGroupId, int? projectId)
        {
            IQueryable<TaskItem> query = _databaseContext.TaskItems
                .Include(t => t.Executors)
                .Include(t => t.Watchers);

            if (employeeId.HasValue)
            {
                query = query.Where(t =>
                               t.Executors.Any(e => e.EmployeeId == employeeId.Value) ||
                               t.Watchers.Any(w => w.EmployeeId == employeeId.Value));
            }

            if (taskGroupId.HasValue)
            {
                query = query.Where(t => t.TaskGroupId == taskGroupId);
            }

            if (projectId.HasValue)
            {
                query = query.Where(t => t.ProjectId == projectId);
            }

            return await query.ToListAsync();
        }

        public async Task<TaskItem?> TryGetByIdAsync(int id)
        {
            return await _databaseContext.TaskItems
                .Include(t => t.Project)
                .Include(t => t.TaskGroup)
                .Include(t => t.Watchers)
                .ThenInclude(e => e.Employee)
                .Include(t => t.Executors)
                .ThenInclude(e => e.Employee)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddAsync(TaskItem taskItem)
        {
            await _databaseContext.TaskItems.AddAsync(taskItem);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TaskItem taskItem)
        {
            _databaseContext.TaskItems.Update(taskItem);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TaskItem taskItem)
        {
            _databaseContext.TaskItems.Remove(taskItem);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _databaseContext.SaveChangesAsync();
        }
    }
}
