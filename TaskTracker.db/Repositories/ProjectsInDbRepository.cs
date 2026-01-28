using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.db.Models;

namespace TaskTracker.db.Repositories
{
    public class ProjectsInDbRepository : IProjectsRepository
    {
        readonly DatabaseContext _databaseContext;

        public ProjectsInDbRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<List<Project>> GetAllAsync()
        {
            return await _databaseContext.Projects
                .Include(p => p.Tasks)
                .ToListAsync();
        }

        public async Task<Project?> TryGetByIdAsync(int id)
        {
            return await _databaseContext.Projects
                .Include(p => p.Tasks)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Project project)
        {
            await _databaseContext.Projects.AddAsync(project);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Project project)
        {
            _databaseContext.Projects.Update(project);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Project project)
        {
            _databaseContext.Projects.Remove(project);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
