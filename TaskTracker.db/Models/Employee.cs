using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.db.Helpers;

namespace TaskTracker.db.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? MiddleName { get; set; }

        public string UserName { get; set; } = null!;

        public EmployeeRole Role { get; set; }
    }
}
