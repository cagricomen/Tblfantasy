using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TBlFantasy.Entity;

namespace TBlFantasy.Web.Controllers
{
    [Authorize]
    public class BasketballerController : ApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await Db.Basketballers.Where(x => x.PirValue > 0).OrderByDescending(x => x.PirValue).ToListAsync();
            return Success(null, list);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TBLTeam value)
        {
            if (string.IsNullOrEmpty(value.Name))
            {
                return Error("Name is required.");
            }
            var checkTeam = await Db.Teams.AnyAsync(x => x.UserId == UserId);
            if (checkTeam)
            {
                return Error("You have already team.");
            }
            var dataObject = new TBLTeam
            {
                UserId = UserId,
                Name = value.Name,
                TeamId = Guid.NewGuid(),
                CreatedDate = DateTime.Now,
                TeamNumber = 0
            };
            Db.Add(dataObject);
            var data = new TBLLeague
            {
                LeagueId = Guid.NewGuid(),
                TeamId = dataObject.TeamId,
                ligId = Guid.NewGuid(),
                UserId = UserId,
                Name = "TBLFANTASY LEAGUE"
            };
            Db.Leagues.Add(data);
            var random = new Random();
            int skipNumber = random.Next(70);
            var fakeUser = await Db.FakeUsers.Skip(skipNumber).Take(9).ToListAsync();
            int tmp = 1;
            foreach (var fake in fakeUser)
            {
                var fakeTeam = new TBLTeam
                {
                    TeamId = Guid.NewGuid(),
                    UserId = fake.FakeId,
                    Name = fake.TeamName,
                    CreatedDate = DateTime.Now,
                    TeamNumber = tmp
                };
                var fakeData = new TBLLeague
                {
                    LeagueId = data.LeagueId,
                    TeamId = fakeTeam.TeamId,
                    ligId = Guid.NewGuid(),
                    UserId = fake.FakeId,
                    Name = "TBLFANTASY LEAGUE"
                };
                Db.Teams.Add(fakeTeam);
                Db.Leagues.Add(fakeData);
                tmp++;
            }
            var result = await Db.SaveChangesAsync();
            if (result > 0)
                return Success("Team name saved");
            else
                return Error("Somethings wrong.");
        }
    }
}
