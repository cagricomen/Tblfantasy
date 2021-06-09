using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TBlFantasy.Entity.Migrations
{
    public partial class FakeUSerMatchtableadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FakeUserMatches",
                columns: table => new
                {
                    MatchId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    FakeId = table.Column<Guid>(nullable: false),
                    UserTeam = table.Column<string>(nullable: true),
                    FakeTeam = table.Column<string>(nullable: true),
                    Week = table.Column<string>(nullable: true),
                    Weeks = table.Column<int>(nullable: false),
                    UserScore = table.Column<int>(nullable: false),
                    FakeScore = table.Column<int>(nullable: false),
                    Winner = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FakeUserMatches", x => x.MatchId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FakeUserMatches");
        }
    }
}
