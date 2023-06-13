using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskinatorDAL.Migrations
{
    /// <inheritdoc />
    public partial class TaskName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Tasks",
                newName: "TaskName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TaskName",
                table: "Tasks",
                newName: "Name");
        }
    }
}
