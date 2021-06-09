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
            var list = await Db.Matches.Where(x => x.UserId == UserId).OrderBy(x => x.Weeks).ToListAsync();
            return Success(null, list);
        }

        [HttpGet("teamstats/{id}")]
        public async Task<IActionResult> TeamStats(Guid id)
        {
            var user = await Db.Teams.FirstOrDefaultAsync(x => x.UserId == UserId);
            //var list = await Db.TeamPlayers.Where(x => x.TeamId == Guid.Parse("9a4baf79-ef29-4e5e-ae3d-f473e4dfeb77")).ToListAsync();
            var list = await Db.TeamPlayers.Join(Db.Basketballers, x=>x.BasketballerId, y=>y.BasketballerId, (x,y) => new {
                Name = y.Name,
                Points = y.Points,
                Assists = y.Assists,
                Rebounds = y.Rebounds,
                Blocks = y.Blocks,
                Steals = y.Steals,
                Turnovers = y.Turnovers,
                TwoPoint = y.TwoPointShot,
                ThreePoint = y.ThreePointShot,
                FreeThrown = y.freeThrown
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
                    BasketballerId = player.BasketballerId
                };
                Db.TeamPlayers.Add(data);
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
