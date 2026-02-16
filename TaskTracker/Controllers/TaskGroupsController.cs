using Microsoft.AspNetCore.Mvc;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
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
                return Ok(new { newGroupId = newGroup.Id });
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

        [HttpGet("{id}/pdf")]
        public async Task<IActionResult> GetGroupPdf(int id)
        {
            var existingGroup = await _groupRepository.TryGetByIdAsync(id);
            if (existingGroup == null)
                return NotFound(new
                {
                    Title = "Группа не найдена",
                    Detail = $"Группа задач с Id {id} не существует."
                });

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(1, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(10));

                    // Заголовок отчета
                    page.Header().Row(row =>
                    {
                        row.RelativeItem().Column(col =>
                        {
                            col.Item().Text($"Отчет по группе задач: {existingGroup.Name}").FontSize(20).SemiBold().FontColor(Colors.Blue.Medium);
                            col.Item().Text($"Дата выгрузки: {DateTime.Now:dd.MM.yyyy HH:mm}");
                        });
                    });

                    page.Content().PaddingVertical(10).Column(column =>
                    {
                        if (!existingGroup.Tasks.Any())
                        {
                            column.Item().Text("В данной группе пока нет задач.").Italic();
                            return;
                        }

                        foreach (var task in existingGroup.Tasks)
                        {
                            column.Item().PaddingBottom(15).Border(1).Padding(5).Column(taskCol =>
                            {
                                taskCol.Item().Row(r =>
                                {
                                    r.RelativeItem().Text($"Задача: {task.Title}").FontSize(14).Bold();
                                    r.ConstantItem(100).AlignRight().Text($"{task.Status}").Italic();
                                });

                                taskCol.Item().Text(t => {
                                    t.Span("Проект: ").Bold();
                                    t.Span(task.Project?.Name ?? "Не привязан");
                                });

                                taskCol.Item().PaddingTop(5).Text("Описание:").Underline();
                                taskCol.Item().Text(task.Description);

                                taskCol.Item().Row(r =>
                                {
                                    r.RelativeItem().Column(c =>
                                    {
                                        c.Item().PaddingTop(5).Text("Исполнители:").Bold();
                                        foreach (var exec in task.Executors)
                                            c.Item().Text($"• {exec.Employee.LastName} {exec.Employee.FirstName}");
                                    });

                                    r.RelativeItem().Column(c =>
                                    {
                                        c.Item().PaddingTop(5).Text("Наблюдатели:").Bold();
                                        foreach (var obs in task.Watchers)
                                            c.Item().Text($"• {obs.Employee.LastName} {obs.Employee.FirstName}");
                                    });
                                });

                                taskCol.Item().PaddingTop(5).AlignRight().Text($"Приоритет: {task.Priority}").FontSize(9);
                            });
                        }
                    });

                    page.Footer().AlignCenter().Text(x =>
                    {
                        x.Span("Страница ");
                        x.CurrentPageNumber();
                    });
                });
            });

            byte[] pdfBytes = document.GeneratePdf();
            return File(pdfBytes, "application/pdf", $"Group_Report_{id}.pdf");
        }
    }
}
