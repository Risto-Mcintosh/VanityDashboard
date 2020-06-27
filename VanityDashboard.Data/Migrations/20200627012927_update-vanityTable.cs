using Microsoft.EntityFrameworkCore.Migrations;

namespace VanityDashboard.Data.Migrations
{
    public partial class updatevanityTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "BaseMaterialPP",
                table: "Vanity",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MirrorPP",
                table: "Vanity",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "TablePP",
                table: "Vanity",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BaseMaterialPP",
                table: "Vanity");

            migrationBuilder.DropColumn(
                name: "MirrorPP",
                table: "Vanity");

            migrationBuilder.DropColumn(
                name: "TablePP",
                table: "Vanity");
        }
    }
}
