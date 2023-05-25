using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskinatorDAL.Migrations
{
    /// <inheritdoc />
    public partial class Task_TableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BoardName",
                table: "Tasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BoardName",
                table: "Tasks");
        }
    }
}
