using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace TBlFantasy.Web.Controllers
{
    public class FakeController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> TeamGet()
        {
            var list = await Db.FakeUserMatches.Where(x => x.Weeks !=0).OrderBy(x => x.Weeks).ToListAsync();
            return Success(null, list);
        }
    }
}
