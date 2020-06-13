using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace VanityDashboard.Data.Migrations
{
    public partial class addKanbanBoard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vanity_BaseMaterials_BaseMaterialId",
                table: "Vanity");

            migrationBuilder.DropForeignKey(
                name: "FK_Vanity_Mirrors_MirrorId",
                table: "Vanity");

            migrationBuilder.DropForeignKey(
                name: "FK_Vanity_Tables_TableId",
                table: "Vanity");

            migrationBuilder.AlterColumn<int>(
                name: "TableId",
                table: "Vanity",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "MirrorId",
                table: "Vanity",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<int>(
                name: "BaseMaterialId",
                table: "Vanity",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "KanbanColumnId",
                table: "Orders",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "KanbanBoard",
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
                    table.PrimaryKey("PK_KanbanBoard", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Vanity_BaseMaterials_BaseMaterialId",
                table: "Vanity",
                column: "BaseMaterialId",
                principalTable: "BaseMaterials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vanity_Mirrors_MirrorId",
                table: "Vanity",
                column: "MirrorId",
                principalTable: "Mirrors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vanity_Tables_TableId",
                table: "Vanity",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vanity_BaseMaterials_BaseMaterialId",
                table: "Vanity");

            migrationBuilder.DropForeignKey(
                name: "FK_Vanity_Mirrors_MirrorId",
                table: "Vanity");

            migrationBuilder.DropForeignKey(
                name: "FK_Vanity_Tables_TableId",
                table: "Vanity");

            migrationBuilder.DropTable(
                name: "KanbanBoard");

            migrationBuilder.DropColumn(
                name: "KanbanColumnId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "TableId",
                table: "Vanity",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MirrorId",
                table: "Vanity",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BaseMaterialId",
                table: "Vanity",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vanity_BaseMaterials_BaseMaterialId",
                table: "Vanity",
                column: "BaseMaterialId",
                principalTable: "BaseMaterials",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vanity_Mirrors_MirrorId",
                table: "Vanity",
                column: "MirrorId",
                principalTable: "Mirrors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vanity_Tables_TableId",
                table: "Vanity",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
