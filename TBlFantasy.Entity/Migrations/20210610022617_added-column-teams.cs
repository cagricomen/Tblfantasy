using Microsoft.EntityFrameworkCore.Migrations;

namespace TBlFantasy.Entity.Migrations
{
    public partial class addedcolumnteams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamNumber",
                table: "Team",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TeamNumber",
                table: "Team");
        }
    }
}
