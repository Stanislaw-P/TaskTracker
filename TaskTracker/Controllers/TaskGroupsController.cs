using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskTracker.db.Helpers;
using TaskTracker.db.Models;
using TaskTracker.db.Repositories;
using TaskTracker.Models;

namespace TaskTracker.Controllers
{
    [ApiController]
    [Route("api/task-groups")]
    public class TaskGroupsController : Controller
    {
        readonly ITaskGroupRepository _groupRepository;

        public TaskGroupsController(ITaskGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var groups = await _groupRepository.GetAllAsync();
                var response = groups.Select(g => new TaskGroupResponse
                {
                    Id = g.Id,
                    Name = g.Name
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
                var group = await _groupRepository.TryGetByIdAsync(id);
                if (group == null)
                    return NotFound($"Группа задач с id={id} не найдена");

                var response = new TaskGroupResponse
                {
                    Id = group.Id,
                    Name = group.Name
                };
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(TaskGroupRequest request)
        {
            try
            {
                var newGroup = new TaskGroup
                {
                    Name = request.Name
                };

                await _groupRepository.AddAsync(newGroup);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, TaskGroupRequest request)
        {
            var existingGroup = await _groupRepository.TryGetByIdAsync(id);
            if (existingGroup == null)
                return NotFound($"Группа задач с id={id} не найдена");

            try
            {
                existingGroup.Name = request.Name;
                await _groupRepository.UpdateAsync(existingGroup);
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
            var existingGroup = await _groupRepository.TryGetByIdAsync(id);
            if (existingGroup == null)
                return NotFound($"Группа задач с id={id} не найдена");

            try
            {
                if (existingGroup.Tasks.Any(t => t.Status != TaskItemStatus.Cancelled))
                    return BadRequest("Нельзя удалить группу, содержащую активные задачи");

                await _groupRepository.DeleteAsync(existingGroup);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
