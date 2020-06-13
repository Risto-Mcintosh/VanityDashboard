using Microsoft.EntityFrameworkCore.Migrations;

namespace VanityDashboard.Data.Migrations
{
    public partial class addKanbanBoardForeignKeyFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KanbanColumnId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "KanbanBoardId",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_KanbanBoardId",
                table: "Orders",
                column: "KanbanBoardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_KanbanBoard_KanbanBoardId",
                table: "Orders",
                column: "KanbanBoardId",
                principalTable: "KanbanBoard",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_KanbanBoard_KanbanBoardId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_KanbanBoardId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "KanbanBoardId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "KanbanColumnId",
                table: "Orders",
                type: "integer",
                nullable: true);
        }
    }
}
