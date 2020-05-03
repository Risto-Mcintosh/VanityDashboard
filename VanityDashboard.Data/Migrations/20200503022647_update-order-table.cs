using Microsoft.EntityFrameworkCore.Migrations;

namespace VanityDashboard.Data.Migrations
{
    public partial class updateordertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double precision");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Total",
                table: "Orders",
                type: "double precision",
                nullable: false,
                oldClrType: typeof(decimal));
        }
    }
}
