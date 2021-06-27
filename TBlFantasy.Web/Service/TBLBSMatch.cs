using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TBlFantasy.Entity;

namespace TBlFantasy.Web
{
    public class TBLBSMatch : IHostedService, IDisposable
    {
        public IServiceProvider Services { get; }
        private CancellationToken _token;

        public TBLBSMatch(IServiceProvider services)
        {
            Services = services;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _token = cancellationToken;
            DoWork();
            return Task.CompletedTask;
        }

        private async void DoWork()
        {
            var week = 3;
                using (var scope = Services.CreateScope())
                {
                    var Db = scope.ServiceProvider.GetRequiredService<TBLDContext>();
                    for (int i = 0; i < 10; i++)
                    {
                        var teamScore = await Db.Teams.FirstOrDefaultAsync(x => x.TeamNumber == i);
                        var lists = await Db.TeamPlayers.Where(x => x.TeamNumber == i).Join(Db.Basketballers, x => x.BasketballerId, y => y.BasketballerId, (x, y) => new
                        {
                            FantasyScore = y.FantasyScore
                        }).ToListAsync();
                        decimal scores = 0m;
                        foreach (var list in lists)
                        {
                            scores += list.FantasyScore;
                        }
                        teamScore.FantasyScore = Convert.ToInt32(scores/2.8m);

                    }
                    var winnerCheck = await Db.FakeUserMatches.Where(x => x.Weeks == week).ToListAsync();
                    foreach (var check in winnerCheck)
                    {
                        var sorgu = await Db.Teams.FirstOrDefaultAsync(x => x.UserId == check.UserId);
                        sorgu.GamesPlayed = week;
                        check.UserScore = Convert.ToInt32(sorgu.FantasyScore);
                        var sorgu2 = await Db.Teams.FirstOrDefaultAsync(x => x.UserId == check.FakeId);
                        sorgu2.GamesPlayed = week;
                        check.FakeScore = Convert.ToInt32(sorgu2.FantasyScore);
                        if (check.UserScore > check.FakeScore)
                        {
                            check.Winner = check.UserTeam;
                            sorgu.Points = (sorgu.Win * 2) + (sorgu.Lose * 1);
                            sorgu2.Points = (sorgu2.Win * 2) + (sorgu2.Lose * 1);
                            sorgu.Win = sorgu.GamesPlayed - sorgu.Lose;
                            sorgu2.Lose = sorgu2.GamesPlayed - sorgu2.Win;
                        }
                        else if (check.UserScore < check.FakeScore)
                        {
                            check.Winner = check.FakeTeam;
                            sorgu.Points = (sorgu.Win * 2) + (sorgu.Lose * 1);
                            sorgu2.Points = (sorgu2.Win * 2) + (sorgu2.Lose * 1);
                            sorgu2.Win = sorgu2.GamesPlayed - sorgu2.Lose;
                            sorgu.Lose = sorgu.GamesPlayed - sorgu.Win;
                        }
                        else
                        {
                            check.Winner = "The match has not been played yet.";
                        }
                    }
                    await Db.SaveChangesAsync(_token);
                }

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
