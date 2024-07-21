using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeLogger.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DayOfWeek",
                table: "Days",
                newName: "WeekDay");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "WeekDay",
                table: "Days",
                newName: "DayOfWeek");
        }
    }
}
