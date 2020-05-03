using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace VanityDashboard.Data.Migrations
{
    public partial class removevanity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Vanity_VanityId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Vanity");

            migrationBuilder.DropIndex(
                name: "IX_Orders_VanityId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "VanityId",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "OrderStatus",
                table: "Orders",
                type: "varchar",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Orders",
                type: "varchar",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MirrorId",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TableId",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_MirrorId",
                table: "Orders",
                column: "MirrorId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TableId",
                table: "Orders",
                column: "TableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Mirrors_MirrorId",
                table: "Orders",
                column: "MirrorId",
                principalTable: "Mirrors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Tables_TableId",
                table: "Orders",
                column: "TableId",
                principalTable: "Tables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Mirrors_MirrorId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Tables_TableId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_MirrorId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_TableId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "MirrorId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "TableId",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "OrderStatus",
                table: "Orders",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar");

            migrationBuilder.AddColumn<int>(
                name: "VanityId",
                table: "Orders",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Vanity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Color = table.Column<string>(type: "varchar", nullable: false),
                    MirrorId = table.Column<int>(type: "integer", nullable: false),
                    TableId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vanity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vanity_Mirrors_MirrorId",
                        column: x => x.MirrorId,
                        principalTable: "Mirrors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vanity_Tables_TableId",
                        column: x => x.TableId,
                        principalTable: "Tables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_VanityId",
                table: "Orders",
                column: "VanityId");

            migrationBuilder.CreateIndex(
                name: "IX_Vanity_MirrorId",
                table: "Vanity",
                column: "MirrorId");

            migrationBuilder.CreateIndex(
                name: "IX_Vanity_TableId",
                table: "Vanity",
                column: "TableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Vanity_VanityId",
                table: "Orders",
                column: "VanityId",
                principalTable: "Vanity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
