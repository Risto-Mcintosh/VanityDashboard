using Microsoft.EntityFrameworkCore.Migrations;

namespace VanityDashboard.Data.Migrations
{
    public partial class addKanbanBoardForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "KanbanColumnId",
                table: "Orders",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "KanbanColumnId",
                table: "Orders",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
