using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkSchedule.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DeleteBehaviorUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shifts_WorkingDays_WorkingDayId",
                table: "Shifts");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingDays_WorkingMonths_WorkingMonthId",
                table: "WorkingDays");

            migrationBuilder.AddForeignKey(
                name: "FK_Shifts_WorkingDays_WorkingDayId",
                table: "Shifts",
                column: "WorkingDayId",
                principalTable: "WorkingDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingDays_WorkingMonths_WorkingMonthId",
                table: "WorkingDays",
                column: "WorkingMonthId",
                principalTable: "WorkingMonths",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shifts_WorkingDays_WorkingDayId",
                table: "Shifts");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkingDays_WorkingMonths_WorkingMonthId",
                table: "WorkingDays");

            migrationBuilder.AddForeignKey(
                name: "FK_Shifts_WorkingDays_WorkingDayId",
                table: "Shifts",
                column: "WorkingDayId",
                principalTable: "WorkingDays",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkingDays_WorkingMonths_WorkingMonthId",
                table: "WorkingDays",
                column: "WorkingMonthId",
                principalTable: "WorkingMonths",
                principalColumn: "Id");
        }
    }
}
