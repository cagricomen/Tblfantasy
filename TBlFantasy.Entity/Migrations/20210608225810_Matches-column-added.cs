using Microsoft.EntityFrameworkCore.Migrations;

namespace TBlFantasy.Entity.Migrations
{
    public partial class Matchescolumnadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Winner",
                table: "Matches",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Winner",
                table: "Matches");
        }
    }
}
