using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskTracker.db.Models;
using TaskTracker.db.Repositories;
using TaskTracker.Models;

namespace TaskTracker.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeeController : Controller
    {
        readonly IEmployeesRepository _employeesRepository;

        public EmployeeController(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var employees = await _employeesRepository.GetAllAsync();
                if (employees == null)
                    return NotFound();

                return Ok(employees);
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
                var employee = await _employeesRepository.TryGetByIdAsync(id);
                if (employee == null)
                    return NotFound();

                return Ok(employee);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(EmployeeRequest employee)
        {
            if (employee == null)
                return BadRequest();

            try
            {
                var newEmployee = new Employee
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    MiddleName = employee.MiddleName,
                    UserName = employee.UserName,
                    Role = employee.Role
                };

                await _employeesRepository.AddAsync(newEmployee);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, EmployeeRequest employee)
        {
            if (employee == null)
                return BadRequest();

            try
            {
                var existingEmployee = await _employeesRepository.TryGetByIdAsync(id);

                if (existingEmployee == null)
                    return NotFound();

                existingEmployee.FirstName = employee.FirstName;
                existingEmployee.LastName = employee.LastName;
                existingEmployee.MiddleName = employee.MiddleName;
                existingEmployee.UserName = employee.UserName;
                existingEmployee.Role = employee.Role;

                await _employeesRepository.UpdateAsync(existingEmployee);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var existingEmployee = await _employeesRepository.TryGetByIdAsync(id);

                if (existingEmployee == null)
                    return NotFound();

                await _employeesRepository.DeleteAsync(existingEmployee);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
