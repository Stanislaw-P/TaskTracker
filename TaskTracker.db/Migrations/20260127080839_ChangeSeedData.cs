using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskTracker.db.Migrations
{
    /// <inheritdoc />
    public partial class ChangeSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 12, 31, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 1, 3, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 12, 30, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 1, 5, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 12, 29, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 1, 7, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 12, 28, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 1, 9, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 12, 27, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 1, 11, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 12, 26, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 1, 13, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 12, 24, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 12, 23, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 1, 19, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 12, 22, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 1, 21, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 12, 21, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 1, 23, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 12, 20, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 1, 25, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 12, 19, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 1, 27, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 1, 29, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 12, 17, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 1, 31, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 12, 16, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 2, 2, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 12, 15, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 12, 14, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 12, 13, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 2, 8, 0, 0, 0, 0, DateTimeKind.Utc) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2025, 12, 12, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2026, 2, 10, 0, 0, 0, 0, DateTimeKind.Utc) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2026, 1, 26, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6138), new DateTime(2026, 1, 29, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6022) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2026, 1, 25, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6720), new DateTime(2026, 1, 31, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6719) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2026, 1, 24, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6723), new DateTime(2026, 2, 2, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6723) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2026, 1, 23, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6725), new DateTime(2026, 2, 4, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6725) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2026, 1, 22, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6728), new DateTime(2026, 2, 6, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6727) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2026, 1, 21, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6731), new DateTime(2026, 2, 8, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6731) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2026, 1, 20, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6733), new DateTime(2026, 2, 10, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6733) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2026, 1, 19, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6735), new DateTime(2026, 2, 12, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6735) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2026, 1, 18, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6737), new DateTime(2026, 2, 14, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6736) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2026, 1, 17, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6740), new DateTime(2026, 2, 16, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6739) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2026, 1, 16, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6792), new DateTime(2026, 2, 18, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6792) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2026, 1, 15, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6794), new DateTime(2026, 2, 20, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6793) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2026, 1, 14, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6796), new DateTime(2026, 2, 22, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6795) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2026, 1, 13, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6798), new DateTime(2026, 2, 24, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6797) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2026, 1, 12, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6799), new DateTime(2026, 2, 26, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6799) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2026, 1, 11, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6801), new DateTime(2026, 2, 28, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6801) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2026, 1, 10, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6803), new DateTime(2026, 3, 2, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6803) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2026, 1, 9, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6806), new DateTime(2026, 3, 4, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6805) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2026, 1, 8, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6807), new DateTime(2026, 3, 6, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6807) });

            migrationBuilder.UpdateData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedAt", "Deadline" },
                values: new object[] { new DateTime(2026, 1, 7, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6809), new DateTime(2026, 3, 8, 8, 4, 6, 648, DateTimeKind.Utc).AddTicks(6809) });
        }
    }
}
