using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskTracker.db.Helpers;
using TaskTracker.db.Models;
using TaskTracker.db.Repositories;
using TaskTracker.Models;

namespace TaskTracker.Controllers
{
    [ApiController]
    [Route("api/projects")]
    public class ProjectsController : Controller
    {
        readonly IProjectsRepository _projectsRepository;

        public ProjectsController(IProjectsRepository projectsRepository)
        {
            _projectsRepository = projectsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var projects = await _projectsRepository.GetAllAsync();
                var response = projects.Select(p => new ProjectResponse
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    ProjectLeadId = p.ProjectLeadId,
                    ProjectManagerId = p.ProjectManagerId,
                    TasksIds = p.Tasks.Select(t => t.Id).ToList()
                });
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var project = await _projectsRepository.TryGetByIdAsync(id);
                if (project == null)
                    return NotFound($"Проекта с id={id} не существует");

                var response = new ProjectResponse
                {
                    Id = project.Id,
                    Name = project.Name,
                    Description = project.Description,
                    ProjectLeadId = project.ProjectLeadId,
                    ProjectManagerId = project.ProjectManagerId,
                    TasksIds = project.Tasks.Select(t => t.Id).ToList()
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(ProjectRequest request)
        {
            try
            {
                var newProject = new Project
                {
                    Name = request.Name,
                    Description = request.Description,
                    ProjectLeadId = request.ProjectLeadId,
                    ProjectManagerId = request.ProjectManagerId,
                };

                await _projectsRepository.AddAsync(newProject);
                return Ok(new { newProjectId = newProject.Id });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, ProjectRequest request)
        {
            try
            {
                var existingProject = await _projectsRepository.TryGetByIdAsync(id);
                if (existingProject == null)
                    return NotFound($"Проекта с id={id} не существует");

                existingProject.Name = request.Name;
                existingProject.Description = request.Description;
                existingProject.ProjectLeadId = request.ProjectLeadId;
                existingProject.ProjectManagerId = request.ProjectManagerId;

                await _projectsRepository.UpdateAsync(existingProject);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var existingProject = await _projectsRepository.TryGetByIdAsync(id);
                if (existingProject == null)
                    return NotFound($"Проекта с id={id} не существует");

                if (existingProject.Tasks.Any(t => t.Status != TaskItemStatus.Cancelled))
                    return Conflict("Нельзя удалить проект, содержащий активные задачи");


                await _projectsRepository.DeleteAsync(existingProject);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
