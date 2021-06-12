using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TBlFantasy.Web.Controllers
{
    [Authorize]
    public class TeamStatsController : ApiController
    {

        public async Task<IActionResult> Get()
        {
            var list = await Db.FakeUserMatches.Where(x => x.UserId == UserId).OrderBy(x => x.Weeks).ToListAsync();
            return Success(null, list);
        }
    }
}
