using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TBlFantasy.Entity.Migrations
{
    public partial class databasetableadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Basketballer",
                columns: table => new
                {
                    BasketballerId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Points = table.Column<int>(nullable: false),
                    Assists = table.Column<int>(nullable: false),
                    Rebounds = table.Column<int>(nullable: false),
                    Blocks = table.Column<int>(nullable: false),
                    Steals = table.Column<int>(nullable: false),
                    Turnovers = table.Column<int>(nullable: false),
                    Fauls = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    Age = table.Column<int>(nullable: false),
                    No = table.Column<int>(nullable: false),
                    TwoPointShot = table.Column<string>(nullable: true),
                    ThreePointShot = table.Column<string>(nullable: true),
                    freeThrown = table.Column<string>(nullable: true),
                    Position = table.Column<string>(nullable: true),
                    Matchtime = table.Column<string>(nullable: true),
                    MatchesPlayed = table.Column<int>(nullable: false),
                    TotalTime = table.Column<string>(nullable: true),
                    AveragePoints = table.Column<decimal>(nullable: false),
                    AverageAssists = table.Column<decimal>(nullable: false),
                    AverageRebounds = table.Column<decimal>(nullable: false),
                    FantasyScore = table.Column<decimal>(nullable: false),
                    PirValue = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basketballer", x => x.BasketballerId);
                });

            migrationBuilder.CreateTable(
                name: "FakeUser",
                columns: table => new
                {
                    FakeId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    TeamName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FakeUser", x => x.FakeId);
                });

            migrationBuilder.CreateTable(
                name: "League",
                columns: table => new
                {
                    ligId = table.Column<Guid>(nullable: false),
                    LeagueId = table.Column<Guid>(nullable: false),
                    TeamId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_League", x => x.ligId);
                });

            migrationBuilder.CreateTable(
                name: "Matches",
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
                    FakeScore = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.MatchId);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    TeamId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    GamesPlayed = table.Column<int>(nullable: false),
                    Win = table.Column<int>(nullable: false),
                    Lose = table.Column<int>(nullable: false),
                    Points = table.Column<int>(nullable: false),
                    FantasyScore = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.TeamId);
                });

            migrationBuilder.CreateTable(
                name: "TeamPlayer",
                columns: table => new
                {
                    tpId = table.Column<Guid>(nullable: false),
                    TeamId = table.Column<Guid>(nullable: false),
                    BasketballerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamPlayer", x => x.tpId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Basketballer");

            migrationBuilder.DropTable(
                name: "FakeUser");

            migrationBuilder.DropTable(
                name: "League");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "TeamPlayer");
        }
    }
}
