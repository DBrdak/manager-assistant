using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkSchedule.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkingMonths",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    MonthName = table.Column<string>(type: "text", nullable: true),
                    MonthStartDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    MonthEndDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingMonths", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkingDays",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Date = table.Column<DateTime>(type: "DATE", nullable: false),
                    OpenHour = table.Column<string>(type: "text", nullable: true),
                    CloseHour = table.Column<string>(type: "text", nullable: true),
                    WorkingMonthId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkingDays_WorkingMonths_WorkingMonthId",
                        column: x => x.WorkingMonthId,
                        principalTable: "WorkingMonths",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Shifts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    EmployeeName = table.Column<string>(type: "text", nullable: true),
                    Note = table.Column<string>(type: "text", nullable: true),
                    StartHour = table.Column<string>(type: "text", nullable: true),
                    EndHour = table.Column<string>(type: "text", nullable: true),
                    WorkingDayId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shifts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shifts_WorkingDays_WorkingDayId",
                        column: x => x.WorkingDayId,
                        principalTable: "WorkingDays",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shifts_WorkingDayId",
                table: "Shifts",
                column: "WorkingDayId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingDays_WorkingMonthId",
                table: "WorkingDays",
                column: "WorkingMonthId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shifts");

            migrationBuilder.DropTable(
                name: "WorkingDays");

            migrationBuilder.DropTable(
                name: "WorkingMonths");
        }
    }
}
