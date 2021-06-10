using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TBlFantasy.Entity;

namespace TBlFantasy.Web.Controllers
{
    public class TeamController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await Db.Teams.ToListAsync();
            return Success(null, list);
        }

        [HttpGet("{id?}")]
        public async Task<IActionResult> TeamGet([FromRoute] Guid? id)
        {
            var list = await Db.FakeUserMatches.Where(x => x.UserId == UserId).OrderBy(x => x.Weeks).ToListAsync();
            return Success(null, list);
        }

        [HttpGet("teamstats/{id}")]
        public async Task<IActionResult> TeamStats(Guid id)
        {
            var user = await Db.Teams.FirstOrDefaultAsync(x => x.UserId == UserId);
            //var list = await Db.TeamPlayers.Where(x => x.TeamId == Guid.Parse("9a4baf79-ef29-4e5e-ae3d-f473e4dfeb77")).ToListAsync();
            var list = await Db.TeamPlayers.Where(x => x.TeamId == user.TeamId).Join(Db.Basketballers, x => x.BasketballerId, y => y.BasketballerId, (x, y) => new
            {
                Name = y.Name,
                Points = y.Points,
                Assists = y.Assists,
                Rebounds = y.Rebounds,
                Blocks = y.Blocks,
                Steals = y.Steals,
                Turnovers = y.Turnovers,
                TwoPoint = y.TwoPointShot,
                ThreePoint = y.ThreePointShot,
                FreeThrown = y.freeThrown,
            }).ToListAsync();


            return Success(null, list);
        }

        [HttpPost]
        public async Task<IActionResult> TeamPost([FromBody] List<TBLBasketballer> basketballers)
        {
            TBLTeamPlayer data = null;
            foreach (var basketballer in basketballers)
            {
                var player = await Db.Basketballers.FirstOrDefaultAsync(x => x.BasketballerId == basketballer.BasketballerId);
                if (player == null) return Error("Basketballer not found.");
                var teams = await Db.Teams.FirstOrDefaultAsync(x => x.UserId == UserId);
                data = new TBLTeamPlayer
                {
                    TeamId = teams.TeamId,
                    BasketballerId = player.BasketballerId,
                    TeamNumber = 0
                };
                Db.TeamPlayers.Add(data);
            }
            var realUser = await Db.Teams.FirstOrDefaultAsync(x => x.UserId == UserId);
            var fakeUser = await Db.Teams.Where(x => x.UserId != UserId).ToListAsync();
            for (int i = 0; i < 9; i++)
            {
                var matchData = new TBLMatches
                {
                    MatchId = Guid.NewGuid(),
                    UserId = UserId,
                    FakeId = fakeUser[i].UserId,
                    UserTeam = realUser.Name,
                    FakeTeam = fakeUser[i].Name,
                    Weeks = i,
                    Week = $"{i + 1}.Week"
                };
                Db.Matches.Add(matchData);
            }
            FakeUserMatches fakeMatch = null;
            var userTeam = await Db.Teams.FirstOrDefaultAsync(x => x.UserId == UserId);
            for (int i = 1; i < 10; i++)
            {
                if (i == 1)
                {
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = UserId,
                        FakeId = fakeUser[0].UserId,
                        UserTeam = userTeam.Name,
                        FakeTeam = fakeUser[0].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = fakeUser[1].UserId,
                        FakeId = fakeUser[2].UserId,
                        UserTeam = fakeUser[1].Name,
                        FakeTeam = fakeUser[2].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = fakeUser[3].UserId,
                        FakeId = fakeUser[4].UserId,
                        UserTeam = fakeUser[3].Name,
                        FakeTeam = fakeUser[4].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = fakeUser[5].UserId,
                        FakeId = fakeUser[6].UserId,
                        UserTeam = fakeUser[5].Name,
                        FakeTeam = fakeUser[6].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = fakeUser[7].UserId,
                        FakeId = fakeUser[8].UserId,
                        UserTeam = fakeUser[7].Name,
                        FakeTeam = fakeUser[8].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                }
                if (i == 2)
                {
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = UserId,
                        FakeId = fakeUser[1].UserId,
                        UserTeam = userTeam.Name,
                        FakeTeam = fakeUser[1].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = fakeUser[0].UserId,
                        FakeId = fakeUser[2].UserId,
                        UserTeam = fakeUser[0].Name,
                        FakeTeam = fakeUser[2].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = fakeUser[3].UserId,
                        FakeId = fakeUser[5].UserId,
                        UserTeam = fakeUser[3].Name,
                        FakeTeam = fakeUser[5].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = fakeUser[4].UserId,
                        FakeId = fakeUser[7].UserId,
                        UserTeam = fakeUser[4].Name,
                        FakeTeam = fakeUser[7].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = fakeUser[6].UserId,
                        FakeId = fakeUser[8].UserId,
                        UserTeam = fakeUser[6].Name,
                        FakeTeam = fakeUser[8].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                }
                if (i == 3)
                {
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = UserId,
                        FakeId = fakeUser[2].UserId,
                        UserTeam = userTeam.Name,
                        FakeTeam = fakeUser[2].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = fakeUser[0].UserId,
                        FakeId = fakeUser[3].UserId,
                        UserTeam = fakeUser[0].Name,
                        FakeTeam = fakeUser[3].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = fakeUser[1].UserId,
                        FakeId = fakeUser[4].UserId,
                        UserTeam = fakeUser[1].Name,
                        FakeTeam = fakeUser[4].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = fakeUser[5].UserId,
                        FakeId = fakeUser[8].UserId,
                        UserTeam = fakeUser[5].Name,
                        FakeTeam = fakeUser[8].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = fakeUser[6].UserId,
                        FakeId = fakeUser[7].UserId,
                        UserTeam = fakeUser[6].Name,
                        FakeTeam = fakeUser[7].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                }
                if (i == 4)
                {
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = UserId,
                        FakeId = fakeUser[3].UserId,
                        UserTeam = userTeam.Name,
                        FakeTeam = fakeUser[3].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = fakeUser[0].UserId,
                        FakeId = fakeUser[4].UserId,
                        UserTeam = fakeUser[0].Name,
                        FakeTeam = fakeUser[4].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = fakeUser[1].UserId,
                        FakeId = fakeUser[8].UserId,
                        UserTeam = fakeUser[1].Name,
                        FakeTeam = fakeUser[8].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = fakeUser[2].UserId,
                        FakeId = fakeUser[6].UserId,
                        UserTeam = fakeUser[2].Name,
                        FakeTeam = fakeUser[6].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = fakeUser[5].UserId,
                        FakeId = fakeUser[7].UserId,
                        UserTeam = fakeUser[5].Name,
                        FakeTeam = fakeUser[7].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                }
                if (i == 5)
                {
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = UserId,
                        FakeId = fakeUser[4].UserId,
                        UserTeam = userTeam.Name,
                        FakeTeam = fakeUser[4].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = fakeUser[0].UserId,
                        FakeId = fakeUser[5].UserId,
                        UserTeam = fakeUser[0].Name,
                        FakeTeam = fakeUser[5].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = fakeUser[1].UserId,
                        FakeId = fakeUser[7].UserId,
                        UserTeam = fakeUser[1].Name,
                        FakeTeam = fakeUser[7].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = fakeUser[2].UserId,
                        FakeId = fakeUser[8].UserId,
                        UserTeam = fakeUser[2].Name,
                        FakeTeam = fakeUser[8].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = fakeUser[3].UserId,
                        FakeId = fakeUser[6].UserId,
                        UserTeam = fakeUser[3].Name,
                        FakeTeam = fakeUser[6].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                }
                if (i == 6)
                {
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = UserId,
                        FakeId = fakeUser[5].UserId,
                        UserTeam = userTeam.Name,
                        FakeTeam = fakeUser[5].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = fakeUser[0].UserId,
                        FakeId = fakeUser[6].UserId,
                        UserTeam = fakeUser[0].Name,
                        FakeTeam = fakeUser[6].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = fakeUser[1].UserId,
                        FakeId = fakeUser[3].UserId,
                        UserTeam = fakeUser[1].Name,
                        FakeTeam = fakeUser[3].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = fakeUser[2].UserId,
                        FakeId = fakeUser[7].UserId,
                        UserTeam = fakeUser[2].Name,
                        FakeTeam = fakeUser[7].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = fakeUser[4].UserId,
                        FakeId = fakeUser[8].UserId,
                        UserTeam = fakeUser[4].Name,
                        FakeTeam = fakeUser[8].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                }
                if (i == 7)
                {
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = UserId,
                        FakeId = fakeUser[6].UserId,
                        UserTeam = userTeam.Name,
                        FakeTeam = fakeUser[6].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = fakeUser[0].UserId,
                        FakeId = fakeUser[7].UserId,
                        UserTeam = fakeUser[0].Name,
                        FakeTeam = fakeUser[7].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = fakeUser[1].UserId,
                        FakeId = fakeUser[5].UserId,
                        UserTeam = fakeUser[1].Name,
                        FakeTeam = fakeUser[5].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = fakeUser[8].UserId,
                        FakeId = fakeUser[3].UserId,
                        UserTeam = fakeUser[8].Name,
                        FakeTeam = fakeUser[3].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = fakeUser[2].UserId,
                        FakeId = fakeUser[4].UserId,
                        UserTeam = fakeUser[2].Name,
                        FakeTeam = fakeUser[4].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                }
                if (i == 8)
                {
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = UserId,
                        FakeId = fakeUser[7].UserId,
                        UserTeam = userTeam.Name,
                        FakeTeam = fakeUser[7].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = fakeUser[0].UserId,
                        FakeId = fakeUser[8].UserId,
                        UserTeam = fakeUser[0].Name,
                        FakeTeam = fakeUser[8].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = fakeUser[1].UserId,
                        FakeId = fakeUser[6].UserId,
                        UserTeam = fakeUser[1].Name,
                        FakeTeam = fakeUser[6].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = fakeUser[3].UserId,
                        FakeId = fakeUser[2].UserId,
                        UserTeam = fakeUser[3].Name,
                        FakeTeam = fakeUser[2].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = fakeUser[4].UserId,
                        FakeId = fakeUser[5].UserId,
                        UserTeam = fakeUser[4].Name,
                        FakeTeam = fakeUser[5].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                }
                if (i == 9)
                {
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = UserId,
                        FakeId = fakeUser[8].UserId,
                        UserTeam = userTeam.Name,
                        FakeTeam = fakeUser[8].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = fakeUser[0].UserId,
                        FakeId = fakeUser[1].UserId,
                        UserTeam = fakeUser[0].Name,
                        FakeTeam = fakeUser[1].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = fakeUser[2].UserId,
                        FakeId = fakeUser[5].UserId,
                        UserTeam = fakeUser[2].Name,
                        FakeTeam = fakeUser[5].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = fakeUser[3].UserId,
                        FakeId = fakeUser[7].UserId,
                        UserTeam = fakeUser[3].Name,
                        FakeTeam = fakeUser[7].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                    fakeMatch = new FakeUserMatches
                    {
                        MatchId = Guid.NewGuid(),
                        UserId = fakeUser[4].UserId,
                        FakeId = fakeUser[6].UserId,
                        UserTeam = fakeUser[4].Name,
                        FakeTeam = fakeUser[6].Name,
                        Week = $"{i}.Week",
                        Weeks = i,
                    };
                    Db.FakeUserMatches.Add(fakeMatch);
                }
            }
            int tmp = 0;
            //var fakeUser = await Db.FakeUsers.Skip(skipNumber).Take(9).ToListAsync();
            TBLTeamPlayer fakeTeamData = null;
            foreach (var fake in fakeUser)
            {
                var allPlayers = await Db.Basketballers.Skip(5 + tmp).Take(10).ToListAsync();
                foreach (var player in allPlayers)
                {
                    fakeTeamData = new TBLTeamPlayer
                    {
                        TeamId = fake.TeamId,
                        BasketballerId = player.BasketballerId,
                        TeamNumber = fake.TeamNumber
                    };
                    Db.TeamPlayers.Add(fakeTeamData);
                }
                tmp++;
            }

            var result = await Db.SaveChangesAsync();
            if (result > 0)
                return Success("Team saved successfully.", new
                {
                    Id = data.TeamId
                });
            else
                return Error("Something wrong.");
        }
    }
}
