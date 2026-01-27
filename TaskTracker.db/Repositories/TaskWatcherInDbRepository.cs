using Microsoft.EntityFrameworkCore;
using TaskTracker.db.Models;

namespace TaskTracker.db.Repositories
{
    public class TaskWatcherInDbRepository : ITaskWatcherRepository
    {
        readonly DatabaseContext _databaseContext;

        public TaskWatcherInDbRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<bool> ExistsAsync(int taskItemId, int employeeId)
        {
            return await _databaseContext.TaskWatchers
                .AnyAsync(ex => ex.EmployeeId == employeeId && ex.TaskItemId == taskItemId);
        }

        public async Task AddAsync(TaskWatcher taskWatcher)
        {
            await _databaseContext.TaskWatchers.AddAsync(taskWatcher);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TaskWatcher taskWatcher)
        {
            _databaseContext.TaskWatchers.Remove(taskWatcher);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
