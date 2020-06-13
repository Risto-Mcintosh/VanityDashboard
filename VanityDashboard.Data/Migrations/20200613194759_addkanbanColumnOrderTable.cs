using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace VanityDashboard.Data.Migrations
{
    public partial class addkanbanColumnOrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColumnPosition",
                table: "KanbanColumns");

            migrationBuilder.CreateTable(
                name: "KanbanColumnOrder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Order = table.Column<string[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KanbanColumnOrder", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KanbanColumnOrder");

            migrationBuilder.AddColumn<int>(
                name: "ColumnPosition",
                table: "KanbanColumns",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
