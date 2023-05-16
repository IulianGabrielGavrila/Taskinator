using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskinatorDAL.Migrations
{
    /// <inheritdoc />
    public partial class Sixth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Task_id",
                table: "Boards");

            migrationBuilder.RenameColumn(
                name: "creation_Date",
                table: "Tasks",
                newName: "Creation_Date");

            migrationBuilder.AddColumn<int>(
                name: "BoardID",
                table: "Tasks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Creator",
                table: "Boards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_BoardID",
                table: "Tasks",
                column: "BoardID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Boards_BoardID",
                table: "Tasks",
                column: "BoardID",
                principalTable: "Boards",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Boards_BoardID",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_BoardID",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "BoardID",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Creator",
                table: "Boards");

            migrationBuilder.RenameColumn(
                name: "Creation_Date",
                table: "Tasks",
                newName: "creation_Date");

            migrationBuilder.AddColumn<int>(
                name: "Task_id",
                table: "Boards",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
