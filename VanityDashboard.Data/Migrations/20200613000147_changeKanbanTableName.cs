using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace VanityDashboard.Data.Migrations
{
    public partial class changeKanbanTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_KanbanBoard_KanbanBoardId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "KanbanBoard");

            migrationBuilder.DropIndex(
                name: "IX_Orders_KanbanBoardId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "KanbanBoardId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "KanbanColumnId",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "KanbanColumns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ColumnName = table.Column<string>(nullable: false),
                    ColumnLock = table.Column<bool>(nullable: false),
                    ColumnPosition = table.Column<int>(nullable: false),
                    IsCompleteColumn = table.Column<bool>(nullable: false),
                    IsStartColumn = table.Column<bool>(nullable: false),
                    Color = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KanbanColumns", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_KanbanColumnId",
                table: "Orders",
                column: "KanbanColumnId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_KanbanColumns_KanbanColumnId",
                table: "Orders",
                column: "KanbanColumnId",
                principalTable: "KanbanColumns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_KanbanColumns_KanbanColumnId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "KanbanColumns");

            migrationBuilder.DropIndex(
                name: "IX_Orders_KanbanColumnId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "KanbanColumnId",
                table: "Orders");

            migrationBuilder.AddColumn<int>(
                name: "KanbanBoardId",
                table: "Orders",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "KanbanBoard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Color = table.Column<string>(type: "text", nullable: true),
                    ColumnLock = table.Column<bool>(type: "boolean", nullable: false),
                    ColumnName = table.Column<string>(type: "text", nullable: false),
                    ColumnPosition = table.Column<int>(type: "integer", nullable: false),
                    IsCompleteColumn = table.Column<bool>(type: "boolean", nullable: false),
                    IsStartColumn = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KanbanBoard", x => x.Id);
                });

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
    }
}
