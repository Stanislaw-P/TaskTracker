using TaskTracker.db.Helpers;

namespace TaskTracker.Models
{
    public class EmployeeRequest
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? MiddleName { get; set; }

        public string UserName { get; set; } = null!;

        public EmployeeRole Role { get; set; }
    }
}
