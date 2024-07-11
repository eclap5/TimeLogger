using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeLogger.Migrations
{
    /// <inheritdoc />
    public partial class SeparateTitleAndDescriptionOfLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "task",
                table: "Logs");

            migrationBuilder.RenameColumn(
                name: "startTime",
                table: "Logs",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "endTime",
                table: "Logs",
                newName: "EndTime");

            migrationBuilder.RenameColumn(
                name: "dayCategory",
                table: "Logs",
                newName: "DayCategory");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "Logs",
                newName: "Date");

            migrationBuilder.AlterColumn<string>(
                name: "StartTime",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EndTime",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "TaskDescription",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TaskTitle",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TaskDescription",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "TaskTitle",
                table: "Logs");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Logs",
                newName: "startTime");

            migrationBuilder.RenameColumn(
                name: "EndTime",
                table: "Logs",
                newName: "endTime");

            migrationBuilder.RenameColumn(
                name: "DayCategory",
                table: "Logs",
                newName: "dayCategory");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Logs",
                newName: "date");

            migrationBuilder.AlterColumn<string>(
                name: "startTime",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "endTime",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "task",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
