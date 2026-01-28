using Microsoft.EntityFrameworkCore;
using TaskTracker.db.Helpers;
using TaskTracker.db.Models;

namespace TaskTracker.db
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<TaskGroup> TaskGroups { get; set; }
        public DbSet<TaskWatcher> TaskWatchers { get; set; }
        public DbSet<TaskExecutor> TaskExecutors { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        private static readonly DateTime SeedBaseDate =
            new DateTime(2026, 01, 01, 0, 0, 0, DateTimeKind.Utc);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaskExecutor>()
                .HasKey(x => new { x.TaskItemId, x.EmployeeId });

            modelBuilder.Entity<TaskWatcher>()
                .HasKey(x => new { x.TaskItemId, x.EmployeeId });

            modelBuilder.Entity<Employee>()
                .HasIndex(x => x.UserName)
                .IsUnique();

            modelBuilder.Entity<TaskItem>()
               .Property(e => e.RowVersion)
               .HasColumnName("xmin")
               .HasColumnType("xid")
               .IsConcurrencyToken()
               .ValueGeneratedOnAddOrUpdate();

            SeedEmployees(modelBuilder);
            SeedProjects(modelBuilder);
            SeedTaskGroups(modelBuilder);
            SeedTasks(modelBuilder);
            SeedTaskRelations(modelBuilder);
        }

        private void SeedTaskRelations(ModelBuilder modelBuilder)
        {
            var executors = new List<TaskExecutor>();
            var watchers = new List<TaskWatcher>();

            for (int taskId = 1; taskId <= 20; taskId++)
            {
                executors.Add(new TaskExecutor
                {
                    TaskItemId = taskId,
                    EmployeeId = ((taskId - 1) % 20) + 1
                });

                executors.Add(new TaskExecutor
                {
                    TaskItemId = taskId,
                    EmployeeId = ((taskId + 1) % 20) + 1
                });

                watchers.Add(new TaskWatcher
                {
                    TaskItemId = taskId,
                    EmployeeId = ((taskId + 5) % 20) + 1
                });
            }

            modelBuilder.Entity<TaskExecutor>().HasData(executors);
            modelBuilder.Entity<TaskWatcher>().HasData(watchers);
        }

        private void SeedTasks(ModelBuilder modelBuilder)
        {
            var tasks = new List<object>();

            for (int i = 1; i <= 20; i++)
            {
                tasks.Add(new
                {
                    Id = i,
                    Title = $"Задача {i}",
                    Description = $"Описание задачи {i}",
                    ProjectId = ((i - 1) % 20) + 1,
                    TaskGroupId = ((i - 1) % 20) + 1,
                    Deadline = SeedBaseDate.AddDays(i * 2),
                    CreatedAt = SeedBaseDate.AddDays(-i),
                    Status = i % 2 == 0 ? TaskItemStatus.Backlog : TaskItemStatus.Current,
                    Priority = (TaskPriority)((i % 5) + 1)
                });
            }

            modelBuilder.Entity<TaskItem>().HasData(tasks);
        }

        private void SeedTaskGroups(ModelBuilder modelBuilder)
        {
            var groups = new List<TaskGroup>();

            for (int i = 1; i <= 20; i++)
            {
                groups.Add(new TaskGroup
                {
                    Id = i,
                    Name = $"Группа задач {i}"
                });
            }

            modelBuilder.Entity<TaskGroup>().HasData(groups);
        }

        private void SeedProjects(ModelBuilder modelBuilder)
        {
            var projects = new List<Project>();

            for (int i = 1; i <= 20; i++)
            {
                projects.Add(new Project
                {
                    Id = i,
                    Name = $"Проект {i}",
                    Description = $"Описание проекта {i}",
                    ProjectLeadId = ((i - 1) % 20) + 1,
                    ProjectManagerId = ((i + 1) % 20) + 1
                });
            }

            modelBuilder.Entity<Project>().HasData(projects);
        }

        private void SeedEmployees(ModelBuilder modelBuilder)
        {
            var employees = new List<Employee>();

            for (int i = 1; i <= 20; i++)
            {
                employees.Add(new Employee
                {
                    Id = i,
                    FirstName = $"Имя{i}",
                    LastName = $"Фамилия{i}",
                    MiddleName = $"Отчество{i}",
                    UserName = $"user{i}",
                    Role = (EmployeeRole)((i % 4) + 1)
                });
            }

            modelBuilder.Entity<Employee>().HasData(employees);
        }
    }
}
