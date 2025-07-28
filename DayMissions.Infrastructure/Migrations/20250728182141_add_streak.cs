using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DayMissions.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class add_streak : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentStreak",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastCompletedDate",
                table: "Tasks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LongestStreak",
                table: "Tasks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentStreak",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "LastCompletedDate",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "LongestStreak",
                table: "Tasks");
        }
    }
}
