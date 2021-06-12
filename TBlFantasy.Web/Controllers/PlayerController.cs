using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TBlFantasy.Web.Controllers
{
    [Authorize]
    public class PlayerController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var user = await Db.Teams.FirstOrDefaultAsync(x => x.UserId == UserId);
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
    }
}
