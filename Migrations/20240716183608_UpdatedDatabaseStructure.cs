using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimeLogger.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedDatabaseStructure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Weeks_WeekId",
                table: "Logs");

            migrationBuilder.DropIndex(
                name: "IX_Logs_WeekId",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "WeekId",
                table: "Logs");

            migrationBuilder.RenameColumn(
                name: "DayCategory",
                table: "Logs",
                newName: "DayId");

            migrationBuilder.AddColumn<int>(
                name: "Year",
                table: "Weeks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Day",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    DayOfWeek = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WeekId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Day", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Day_Weeks_WeekId",
                        column: x => x.WeekId,
                        principalTable: "Weeks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Logs_DayId",
                table: "Logs",
                column: "DayId");

            migrationBuilder.CreateIndex(
                name: "IX_Day_WeekId",
                table: "Day",
                column: "WeekId");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Day_DayId",
                table: "Logs",
                column: "DayId",
                principalTable: "Day",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Day_DayId",
                table: "Logs");

            migrationBuilder.DropTable(
                name: "Day");

            migrationBuilder.DropIndex(
                name: "IX_Logs_DayId",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Weeks");

            migrationBuilder.RenameColumn(
                name: "DayId",
                table: "Logs",
                newName: "DayCategory");

            migrationBuilder.AddColumn<DateOnly>(
                name: "Date",
                table: "Logs",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<string>(
                name: "Duration",
                table: "Logs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "WeekId",
                table: "Logs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Logs_WeekId",
                table: "Logs",
                column: "WeekId");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Weeks_WeekId",
                table: "Logs",
                column: "WeekId",
                principalTable: "Weeks",
                principalColumn: "Id");
        }
    }
}
