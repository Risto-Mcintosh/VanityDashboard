using Microsoft.EntityFrameworkCore.Migrations;

namespace VanityDashboard.Data.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:Enum:sizes", "small,medium,large")
                .OldAnnotation("Npgsql:Enum:vanity_color", "white,black,pink");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:sizes", "small,medium,large")
                .Annotation("Npgsql:Enum:vanity_color", "white,black,pink");
        }
    }
}
