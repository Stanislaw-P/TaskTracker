using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskTracker.db.Migrations
{
    /// <inheritdoc />
    public partial class AddEntitys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ProjectLeadId = table.Column<int>(type: "integer", nullable: false),
                    ProjectManagerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_Employees_ProjectLeadId",
                        column: x => x.ProjectLeadId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_Employees_ProjectManagerId",
                        column: x => x.ProjectManagerId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ProjectId = table.Column<int>(type: "integer", nullable: false),
                    TaskGroupId = table.Column<int>(type: "integer", nullable: false),
                    Deadline = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskItems_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskItems_TaskGroups_TaskGroupId",
                        column: x => x.TaskGroupId,
                        principalTable: "TaskGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskExecutors",
                columns: table => new
                {
                    TaskItemId = table.Column<int>(type: "integer", nullable: false),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskExecutors", x => new { x.TaskItemId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_TaskExecutors_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskExecutors_TaskItems_TaskItemId",
                        column: x => x.TaskItemId,
                        principalTable: "TaskItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskWatchers",
                columns: table => new
                {
                    TaskItemId = table.Column<int>(type: "integer", nullable: false),
                    EmployeeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskWatchers", x => new { x.TaskItemId, x.EmployeeId });
                    table.ForeignKey(
                        name: "FK_TaskWatchers_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskWatchers_TaskItems_TaskItemId",
                        column: x => x.TaskItemId,
                        principalTable: "TaskItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "FirstName", "LastName", "MiddleName", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, "Имя1", "Фамилия1", "Отчество1", 2, "user1" },
                    { 2, "Имя2", "Фамилия2", "Отчество2", 3, "user2" },
                    { 3, "Имя3", "Фамилия3", "Отчество3", 4, "user3" },
                    { 4, "Имя4", "Фамилия4", "Отчество4", 1, "user4" },
                    { 5, "Имя5", "Фамилия5", "Отчество5", 2, "user5" },
                    { 6, "Имя6", "Фамилия6", "Отчество6", 3, "user6" },
                    { 7, "Имя7", "Фамилия7", "Отчество7", 4, "user7" },
                    { 8, "Имя8", "Фамилия8", "Отчество8", 1, "user8" },
                    { 9, "Имя9", "Фамилия9", "Отчество9", 2, "user9" },
                    { 10, "Имя10", "Фамилия10", "Отчество10", 3, "user10" },
                    { 11, "Имя11", "Фамилия11", "Отчество11", 4, "user11" },
                    { 12, "Имя12", "Фамилия12", "Отчество12", 1, "user12" },
                    { 13, "Имя13", "Фамилия13", "Отчество13", 2, "user13" },
                    { 14, "Имя14", "Фамилия14", "Отчество14", 3, "user14" },
                    { 15, "Имя15", "Фамилия15", "Отчество15", 4, "user15" },
                    { 16, "Имя16", "Фамилия16", "Отчество16", 1, "user16" },
                    { 17, "Имя17", "Фамилия17", "Отчество17", 2, "user17" },
                    { 18, "Имя18", "Фамилия18", "Отчество18", 3, "user18" },
                    { 19, "Имя19", "Фамилия19", "Отчество19", 4, "user19" },
                    { 20, "Имя20", "Фамилия20", "Отчество20", 1, "user20" }
                });

            migrationBuilder.InsertData(
                table: "TaskGroups",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Группа задач 1" },
                    { 2, "Группа задач 2" },
                    { 3, "Группа задач 3" },
                    { 4, "Группа задач 4" },
                    { 5, "Группа задач 5" },
                    { 6, "Группа задач 6" },
                    { 7, "Группа задач 7" },
                    { 8, "Группа задач 8" },
                    { 9, "Группа задач 9" },
                    { 10, "Группа задач 10" },
                    { 11, "Группа задач 11" },
                    { 12, "Группа задач 12" },
                    { 13, "Группа задач 13" },
                    { 14, "Группа задач 14" },
                    { 15, "Группа задач 15" },
                    { 16, "Группа задач 16" },
                    { 17, "Группа задач 17" },
                    { 18, "Группа задач 18" },
                    { 19, "Группа задач 19" },
                    { 20, "Группа задач 20" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "Name", "ProjectLeadId", "ProjectManagerId" },
                values: new object[,]
                {
                    { 1, "Описание проекта 1", "Проект 1", 1, 3 },
                    { 2, "Описание проекта 2", "Проект 2", 2, 4 },
                    { 3, "Описание проекта 3", "Проект 3", 3, 5 },
                    { 4, "Описание проекта 4", "Проект 4", 4, 6 },
                    { 5, "Описание проекта 5", "Проект 5", 5, 7 },
                    { 6, "Описание проекта 6", "Проект 6", 6, 8 },
                    { 7, "Описание проекта 7", "Проект 7", 7, 9 },
                    { 8, "Описание проекта 8", "Проект 8", 8, 10 },
                    { 9, "Описание проекта 9", "Проект 9", 9, 11 },
                    { 10, "Описание проекта 10", "Проект 10", 10, 12 },
                    { 11, "Описание проекта 11", "Проект 11", 11, 13 },
                    { 12, "Описание проекта 12", "Проект 12", 12, 14 },
                    { 13, "Описание проекта 13", "Проект 13", 13, 15 },
                    { 14, "Описание проекта 14", "Проект 14", 14, 16 },
                    { 15, "Описание проекта 15", "Проект 15", 15, 17 },
                    { 16, "Описание проекта 16", "Проект 16", 16, 18 },
                    { 17, "Описание проекта 17", "Проект 17", 17, 19 },
                    { 18, "Описание проекта 18", "Проект 18", 18, 20 },
                    { 19, "Описание проекта 19", "Проект 19", 19, 1 },
                    { 20, "Описание проекта 20", "Проект 20", 20, 2 }
                });

            migrationBuilder.InsertData(
                table: "TaskItems",
                columns: new[] { "Id", "CreatedAt", "Deadline", "Description", "Priority", "ProjectId", "Status", "TaskGroupId", "Title" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 26, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6138), new DateTime(2026, 1, 29, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6022), "Описание задачи 1", 2, 1, 2, 1, "Задача 1" },
                    { 2, new DateTime(2026, 1, 25, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6720), new DateTime(2026, 1, 31, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6719), "Описание задачи 2", 3, 2, 1, 2, "Задача 2" },
                    { 3, new DateTime(2026, 1, 24, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6723), new DateTime(2026, 2, 2, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6723), "Описание задачи 3", 4, 3, 2, 3, "Задача 3" },
                    { 4, new DateTime(2026, 1, 23, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6725), new DateTime(2026, 2, 4, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6725), "Описание задачи 4", 5, 4, 1, 4, "Задача 4" },
                    { 5, new DateTime(2026, 1, 22, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6728), new DateTime(2026, 2, 6, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6727), "Описание задачи 5", 1, 5, 2, 5, "Задача 5" },
                    { 6, new DateTime(2026, 1, 21, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6731), new DateTime(2026, 2, 8, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6731), "Описание задачи 6", 2, 6, 1, 6, "Задача 6" },
                    { 7, new DateTime(2026, 1, 20, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6733), new DateTime(2026, 2, 10, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6733), "Описание задачи 7", 3, 7, 2, 7, "Задача 7" },
                    { 8, new DateTime(2026, 1, 19, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6735), new DateTime(2026, 2, 12, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6735), "Описание задачи 8", 4, 8, 1, 8, "Задача 8" },
                    { 9, new DateTime(2026, 1, 18, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6737), new DateTime(2026, 2, 14, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6736), "Описание задачи 9", 5, 9, 2, 9, "Задача 9" },
                    { 10, new DateTime(2026, 1, 17, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6740), new DateTime(2026, 2, 16, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6739), "Описание задачи 10", 1, 10, 1, 10, "Задача 10" },
                    { 11, new DateTime(2026, 1, 16, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6792), new DateTime(2026, 2, 18, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6792), "Описание задачи 11", 2, 11, 2, 11, "Задача 11" },
                    { 12, new DateTime(2026, 1, 15, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6794), new DateTime(2026, 2, 20, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6793), "Описание задачи 12", 3, 12, 1, 12, "Задача 12" },
                    { 13, new DateTime(2026, 1, 14, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6796), new DateTime(2026, 2, 22, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6795), "Описание задачи 13", 4, 13, 2, 13, "Задача 13" },
                    { 14, new DateTime(2026, 1, 13, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6798), new DateTime(2026, 2, 24, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6797), "Описание задачи 14", 5, 14, 1, 14, "Задача 14" },
                    { 15, new DateTime(2026, 1, 12, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6799), new DateTime(2026, 2, 26, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6799), "Описание задачи 15", 1, 15, 2, 15, "Задача 15" },
                    { 16, new DateTime(2026, 1, 11, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6801), new DateTime(2026, 2, 28, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6801), "Описание задачи 16", 2, 16, 1, 16, "Задача 16" },
                    { 17, new DateTime(2026, 1, 10, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6803), new DateTime(2026, 3, 2, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6803), "Описание задачи 17", 3, 17, 2, 17, "Задача 17" },
                    { 18, new DateTime(2026, 1, 9, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6806), new DateTime(2026, 3, 4, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6805), "Описание задачи 18", 4, 18, 1, 18, "Задача 18" },
                    { 19, new DateTime(2026, 1, 8, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6807), new DateTime(2026, 3, 6, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6807), "Описание задачи 19", 5, 19, 2, 19, "Задача 19" },
                    { 20, new DateTime(2026, 1, 7, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6809), new DateTime(2026, 3, 8, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6809), "Описание задачи 20", 1, 20, 1, 20, "Задача 20" }
                });

            migrationBuilder.InsertData(
                table: "TaskExecutors",
                columns: new[] { "EmployeeId", "TaskItemId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 1 },
                    { 2, 2 },
                    { 4, 2 },
                    { 3, 3 },
                    { 5, 3 },
                    { 4, 4 },
                    { 6, 4 },
                    { 5, 5 },
                    { 7, 5 },
                    { 6, 6 },
                    { 8, 6 },
                    { 7, 7 },
                    { 9, 7 },
                    { 8, 8 },
                    { 10, 8 },
                    { 9, 9 },
                    { 11, 9 },
                    { 10, 10 },
                    { 12, 10 },
                    { 11, 11 },
                    { 13, 11 },
                    { 12, 12 },
                    { 14, 12 },
                    { 13, 13 },
                    { 15, 13 },
                    { 14, 14 },
                    { 16, 14 },
                    { 15, 15 },
                    { 17, 15 },
                    { 16, 16 },
                    { 18, 16 },
                    { 17, 17 },
                    { 19, 17 },
                    { 18, 18 },
                    { 20, 18 },
                    { 1, 19 },
                    { 19, 19 },
                    { 2, 20 },
                    { 20, 20 }
                });

            migrationBuilder.InsertData(
                table: "TaskWatchers",
                columns: new[] { "EmployeeId", "TaskItemId" },
                values: new object[,]
                {
                    { 7, 1 },
                    { 8, 2 },
                    { 9, 3 },
                    { 10, 4 },
                    { 11, 5 },
                    { 12, 6 },
                    { 13, 7 },
                    { 14, 8 },
                    { 15, 9 },
                    { 16, 10 },
                    { 17, 11 },
                    { 18, 12 },
                    { 19, 13 },
                    { 20, 14 },
                    { 1, 15 },
                    { 2, 16 },
                    { 3, 17 },
                    { 4, 18 },
                    { 5, 19 },
                    { 6, 20 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserName",
                table: "Employees",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectLeadId",
                table: "Projects",
                column: "ProjectLeadId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectManagerId",
                table: "Projects",
                column: "ProjectManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskExecutors_EmployeeId",
                table: "TaskExecutors",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_ProjectId",
                table: "TaskItems",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_TaskGroupId",
                table: "TaskItems",
                column: "TaskGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskWatchers_EmployeeId",
                table: "TaskWatchers",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaskExecutors");

            migrationBuilder.DropTable(
                name: "TaskWatchers");

            migrationBuilder.DropTable(
                name: "TaskItems");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "TaskGroups");

            migrationBuilder.DropIndex(
                name: "IX_Employees_UserName",
                table: "Employees");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
