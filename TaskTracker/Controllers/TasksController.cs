using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskTracker.db.Helpers;
using TaskTracker.db.Models;
using TaskTracker.db.Repositories;
using TaskTracker.Models;

namespace TaskTracker.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TasksController : Controller
    {
        readonly ITaskItemRepository _taskItemRepository;
        readonly ITaskExecutorRepository _executorRepository;
        readonly ITaskWatcherRepository _watcherRepository;

        public TasksController(ITaskItemRepository taskItemRepository, ITaskExecutorRepository executorRepository, ITaskWatcherRepository watcherRepository)
        {
            _taskItemRepository = taskItemRepository;
            _executorRepository = executorRepository;
            _watcherRepository = watcherRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int? employeeId, int? projectId, int? taskGroupId)
        {
            try
            {
                var tasks = await _taskItemRepository.GetAllAsync(employeeId, taskGroupId, projectId);

                var response = tasks.Select(t => new TaskItemResponse
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    ProjectId = t.ProjectId,
                    TaskGroupId = t.TaskGroupId,
                    Deadline = t.Deadline,
                    CreatedAt = t.CreatedAt,
                    Status = t.Status,
                    Priority = t.Priority,
                    ExecutorIds = t.Executors.Select(e => e.EmployeeId).ToList(),
                    WatcherIds = t.Watchers.Select(w => w.EmployeeId).ToList()
                });
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var task = await _taskItemRepository.TryGetByIdAsync(id);
                if (task == null)
                {
                    return NotFound();
                }

                var response = new TaskItemResponse
                {
                    Id = task.Id,
                    Title = task.Title,
                    Description = task.Description,
                    ProjectId = task.ProjectId,
                    TaskGroupId = task.TaskGroupId,
                    Deadline = task.Deadline,
                    CreatedAt = task.CreatedAt,
                    Status = task.Status,
                    Priority = task.Priority,
                    ExecutorIds = task.Executors.Select(e => e.EmployeeId).ToList(),
                    WatcherIds = task.Watchers.Select(w => w.EmployeeId).ToList()
                };
                return Ok(response);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateTaskItemRequest taskItem)
        {
            if (taskItem.Status != TaskItemStatus.Backlog &&
                taskItem.Status != TaskItemStatus.Current)
            {
                return BadRequest("При создании задача может быть только в статусе Backlog или Current");
            }

            try
            {
                var newTaskItem = new TaskItem(
                    taskItem.Title,
                    taskItem.Description,
                    taskItem.ProjectId,
                    taskItem.TaskGroupId,
                    taskItem.Deadline,
                    taskItem.Status,
                    taskItem.Priority);

                await _taskItemRepository.AddAsync(newTaskItem);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, UpdateTaskItemRequest taskItem)
        {
            try
            {
                var existingTask = await _taskItemRepository.TryGetByIdAsync(id);
                if (existingTask == null)
                    return NotFound();

                existingTask.Title = taskItem.Title;
                existingTask.Description = taskItem.Description;
                existingTask.Deadline = taskItem.Deadline;
                existingTask.Priority = taskItem.Priority;
                await _taskItemRepository.UpdateAsync(existingTask);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("{taskId}/executors/{employeeId}")]
        public async Task<IActionResult> AddExecutorAsync(int taskId, int employeeId)
        {
            try
            {
                var existingingExecutor = await _executorRepository.ExistsAsync(taskId, employeeId);
                if (existingingExecutor)
                    return BadRequest("Сотрудник уже является исполнителем задачи");

                var executor = new TaskExecutor
                {
                    TaskItemId = taskId,
                    EmployeeId = employeeId
                };

                await _executorRepository.AddAsync(executor);
                
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("{taskId}/watchers/{employeeId}")]
        public async Task<IActionResult> AddWatcherAsync(int taskId, int employeeId)
        {
            try
            {
                var existingingWather = await _watcherRepository.ExistsAsync(taskId, employeeId);
                if (existingingWather)
                    return BadRequest("Сотрудник уже является наблюдателем задачи");

                var watcher = new TaskWatcher
                {
                    TaskItemId = taskId,
                    EmployeeId = employeeId
                };

                await _watcherRepository.AddAsync(watcher);

                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
