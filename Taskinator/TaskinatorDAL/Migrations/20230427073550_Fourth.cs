using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskinatorDAL.Migrations
{
    /// <inheritdoc />
    public partial class Fourth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BoardID",
                table: "Tasks",
                type: "int",
                nullable: true);

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
    }
}
