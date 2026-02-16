using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.db.Models;

namespace TaskTracker.db.Repositories
{
    public class TaskGroupInDbRepository : ITaskGroupRepository
    {
        readonly DatabaseContext _databaseContext;

        public TaskGroupInDbRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<List<TaskGroup>> GetAllAsync()
        {
            return await _databaseContext.TaskGroups.ToListAsync();
        }

        public async Task<TaskGroup?> TryGetByIdAsync(int id)
        {
            return await _databaseContext.TaskGroups
                .Include(tg => tg.Tasks)
                .ThenInclude(t => t.Executors)
                .ThenInclude(w => w.Employee)
                .Include(tg => tg.Tasks)
                .ThenInclude(t => t.Watchers)
                .ThenInclude(w => w.Employee)
                .FirstOrDefaultAsync(tg => tg.Id == id);
        }

        public async Task AddAsync(TaskGroup taskGroup)
        {
            await _databaseContext.TaskGroups.AddAsync(taskGroup);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TaskGroup taskGroup)
        {
            _databaseContext.Update(taskGroup);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(TaskGroup taskGroup)
        {
            _databaseContext.TaskGroups.Remove(taskGroup);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
