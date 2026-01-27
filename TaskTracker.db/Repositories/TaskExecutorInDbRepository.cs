using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.db.Models;

namespace TaskTracker.db.Repositories
{
    public class TaskExecutorInDbRepository : ITaskExecutorRepository
    {
        readonly DatabaseContext _databaseContext;

        public TaskExecutorInDbRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<bool> ExistsAsync(int taskItemId, int employeeId)
        {
            return await _databaseContext.TaskExecutors
                .AnyAsync(ex => ex.EmployeeId == employeeId && ex.TaskItemId == taskItemId);
        }

        public async Task AddAsync(TaskExecutor taskExecutor)
        {
            await _databaseContext.TaskExecutors.AddAsync(taskExecutor);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TaskExecutor taskExecutor)
        {
            _databaseContext.TaskExecutors.Remove(taskExecutor);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
