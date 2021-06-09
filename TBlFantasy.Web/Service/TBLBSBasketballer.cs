using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TBlFantasy.Entity;

namespace TBlFantasy.Web
{
    public class TBLBSBasketballer : IHostedService, IDisposable
    {
        public IServiceProvider Services { get; }
        private CancellationToken _token;

        public TBLBSBasketballer(IServiceProvider services)
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
            var week = 0;
            while (true)
            {
                using (var scope = Services.CreateScope())
                {
                    var Db = scope.ServiceProvider.GetRequiredService<TBLDContext>();
                    var players = new List<BasketballPlayer>();
                    var matchAdress = new List<string> { "https://www.mackolik.com/basketbol/mac/anadolu-efes-spor-kul%C3%BCb%C3%BC-vs-petkim-spor-kul%C3%BCb%C3%BC/1wggp3pfzydyidokltpugj7ro", "https://www.mackolik.com/basketbol/mac/tofa%C5%9F-spor-kul%C3%BCb%C3%BC-vs-gaziantep-basketbol/1wkrn5igq7ccf7k2vq5nvjac4", "https://www.mackolik.com/basketbol/mac/p%C4%B1nar-kar%C5%9F%C4%B1yaka-spor-kul%C3%BCb%C3%BC-vs-frutti-extra-bursaspor/1wp6e5fjdtqn74eycd6qnb9xw", "https://www.mackolik.com/basketbol/mac/bah%C3%A7e%C5%9Fehir-koleji-spor-kul%C3%BCb%C3%BC-vs-ogm-orman-spor-kul%C3%BCb%C3%BC/1wtglreai6m00u8pjpiy4wg7o", "https://www.mackolik.com/basketbol/mac/t%C3%BCrk-telekom-basketbol-kul%C3%BCb%C3%BC-vs-be%C5%9Fikta%C5%9F-icrypex/6cn7kyhbkxeyb9nz0q35umhw4", "https://www.mackolik.com/basketbol/mac/dar%C3%BC%C5%9F%C5%9Fafaka-spor-kul%C3%BCb%C3%BC-vs-fethiye-belediye-basketbol-kul%C3%BCb%C3%BC/6crpw4ig4e6eozebm9eccd82c", "https://www.mackolik.com/basketbol/mac/meksa-yat%C4%B1r%C4%B1m-afyon-belediyespor-vs-fenerbah%C3%A7e/6cvultnboiwyrd8uem8tnxc0k", "https://www.mackolik.com/basketbol/mac/b%C3%BCy%C3%BCk%C3%A7ekmece-vs-galatasaray/6czw93hyamqkajq1chifgvx90", "https://www.mackolik.com/basketbol/mac/dar%C3%BC%C5%9F%C5%9Fafaka-spor-kul%C3%BCb%C3%BC-vs-fenerbah%C3%A7e/7balps97u9mm6z3cwqw6qqsr8" };
                    foreach (var adress in matchAdress)
                    {
                        var hweb = new HtmlAgilityPack.HtmlWeb();
                        HtmlAgilityPack.HtmlDocument hdoc = hweb.Load(adress);
                        var idPath = new List<int> { 1, 2 };
                        foreach (var id in idPath)
                        {
                            var tbody = hdoc.DocumentNode.SelectSingleNode($"/html/body/div[4]/div[2]/main/div/div[2]/div/div[1]/div/div[2]/div[2]/div/div[{id}]/div[2]/table/tbody");
                            if (tbody != null)
                            {
                                var tableRows = tbody.SelectNodes("//tr[@class='widget-basketball-match-box-score__row']");
                                foreach (var row in tableRows)
                                {
                                    var pp = new BasketballPlayer();
                                    var tableData = row.Elements("td");
                                    int i = 0;
                                    foreach (var data in tableData)
                                    {
                                        if (i == 0)
                                        {
                                            pp.Name = data.InnerText;
                                        }
                                        if (i == 1)
                                        {
                                            pp.TimeMatch = data.InnerText;
                                        }
                                        if (i == 2)
                                        {
                                            int num = 0;
                                            Int32.TryParse(data.InnerText, out num);
                                            pp.Points = num;
                                        }
                                        if (i == 3)
                                        {
                                            int num = 0;
                                            Int32.TryParse(data.InnerText, out num);
                                            pp.Rebounds = num;
                                        }
                                        if (i == 4)
                                        {
                                            int num = 0;
                                            Int32.TryParse(data.InnerText, out num);
                                            pp.Assists = num;
                                        }
                                        if (i == 5)
                                        {
                                            pp.TwoThrown = data.InnerText;
                                        }
                                        if (i == 6)
                                        {
                                            pp.ThreeThrown = data.InnerText;
                                        }
                                        if (i == 7)
                                        {
                                            pp.FreeThrown = data.InnerText;
                                        }
                                        if (i == 8)
                                        {
                                            int num = 0;
                                            Int32.TryParse(data.InnerText, out num);
                                            pp.Fauls = num;
                                        }
                                        if (i == 9)
                                        {
                                            int num = 0;
                                            Int32.TryParse(data.InnerText, out num);
                                            pp.Blocks = num;
                                        }
                                        if (i == 10)
                                        {
                                            int num = 0;
                                            Int32.TryParse(data.InnerText, out num);
                                            pp.Steals = num;
                                        }
                                        if (i == 11)
                                        {
                                            int num = 0;
                                            Int32.TryParse(data.InnerText, out num);
                                            pp.Turnovers = num;
                                        }
                                        i++;
                                    }
                                    players.Add(pp);
                                }
                            }
                        }
                    }
                    foreach (var player in players)
                    {
                        var playerData = await Db.Basketballers.Where(x => x.Name == player.Name).ToListAsync();
                        foreach (var data in playerData)
                        {
                            data.TotalTime = player.TimeMatch;
                            data.Points = player.Points;
                            data.Rebounds = player.Rebounds;
                            data.Assists = player.Assists;
                            data.TwoPointShot = player.TwoThrown;
                            data.ThreePointShot = player.ThreeThrown;
                            data.freeThrown = player.FreeThrown;
                            data.Fauls = player.Fauls;
                            data.Blocks = player.Blocks;
                            data.Rebounds = player.Rebounds;
                            data.Turnovers = player.Turnovers;
                            data.FantasyScore = (player.Points + 1.2m * (player.Rebounds) + 1.5m * (player.Assists) + 2m * player.Blocks + 2m * player.Steals - 3m * player.Steals);
                        }
                    }
                    var userFantasyScore = await Db.Teams.FirstOrDefaultAsync(x => x.UserId == Guid.Parse("2917abb5-0b3a-475d-b391-48cecc2122b2"));

                    var lists = await Db.Basketballers.Join(Db.TeamPlayers, x => x.BasketballerId, y => y.BasketballerId, (x, y) => new
                    {
                        FantasyScore = x.FantasyScore
                    }).ToListAsync();
                    decimal teamScore = 0m;

                    foreach (var list in lists)
                    {
                        teamScore += list.FantasyScore;
                    }

                    userFantasyScore.FantasyScore = teamScore;

                    var winnerCheck = await Db.Matches.FirstOrDefaultAsync(x => x.Weeks == week);
                    var userTeam = await Db.Teams.FirstOrDefaultAsync(x => x.UserId == Guid.Parse("2917abb5-0b3a-475d-b391-48cecc2122b2"));

                    winnerCheck.UserScore = Convert.ToInt32(userTeam.FantasyScore / 2m);
                    if (winnerCheck.UserScore > winnerCheck.FakeScore)
                    {
                        winnerCheck.Winner = winnerCheck.UserTeam;
                    }
                    else if (winnerCheck.UserScore == winnerCheck.FakeScore)
                    {
                        winnerCheck.Winner = "The match has not been played yet.";
                    }
                    else
                    {
                        winnerCheck.Winner = winnerCheck.FakeTeam;
                    }
                    var value = await Db.Teams.FirstOrDefaultAsync(x => x.UserId == Guid.Parse("2917abb5-0b3a-475d-b391-48cecc2122b2"));
                    var fakeUser = await Db.Teams.Where(x => x.UserId != Guid.Parse("2917abb5-0b3a-475d-b391-48cecc2122b2")).ToListAsync();
                    FakeUserMatches fakeMatch = null;
                    for (int i = 0; i < 1; i++)
                    {
                        if (i == 0)
                        {
                            for (int j = 0; j < 5; j++)
                            {
                                if (j == 0)
                                {
                                    fakeMatch = new FakeUserMatches
                                    {
                                        MatchId = Guid.NewGuid(),
                                        UserId = Guid.Parse("2917abb5-0b3a-475d-b391-48cecc2122b2"),
                                        FakeId = fakeUser[0].UserId,
                                        UserTeam = value.Name,
                                        FakeTeam = fakeUser[0].Name,
                                        Week = $"{i+1}.Week",
                                        Weeks = 0,
                                    };
                                }
                                if (j == 1)
                                {
                                    fakeMatch = new FakeUserMatches
                                    {
                                        MatchId = Guid.NewGuid(),
                                        UserId = fakeUser[1].UserId,
                                        FakeId = fakeUser[2].UserId,
                                        UserTeam = fakeUser[1].Name,
                                        FakeTeam = fakeUser[2].Name,
                                        Week = $"{i+1}.Week",
                                        Weeks = 0,
                                    };
                                }
                                if (j == 2)
                                {
                                    fakeMatch = new FakeUserMatches
                                    {
                                        MatchId = Guid.NewGuid(),
                                        UserId = fakeUser[3].UserId,
                                        FakeId = fakeUser[4].UserId,
                                        UserTeam = fakeUser[3].Name,
                                        FakeTeam = fakeUser[4].Name,
                                        Week = $"{i+1}.Week",
                                        Weeks = 0,
                                    };
                                }
                                if (j == 3)
                                {
                                    fakeMatch = new FakeUserMatches
                                    {
                                        MatchId = Guid.NewGuid(),
                                        UserId = fakeUser[5].UserId,
                                        FakeId = fakeUser[6].UserId,
                                        UserTeam = fakeUser[5].Name,
                                        FakeTeam = fakeUser[6].Name,
                                        Week = $"{i+1}.Week",
                                        Weeks = 0,
                                    };
                                }
                                if (j == 4)
                                {
                                    fakeMatch = new FakeUserMatches
                                    {
                                        MatchId = Guid.NewGuid(),
                                        UserId = fakeUser[7].UserId,
                                        FakeId = fakeUser[8].UserId,
                                        UserTeam = fakeUser[7].Name,
                                        FakeTeam = fakeUser[8].Name,
                                        Week = $"{i+1}.Week",
                                        Weeks = 0,
                                    };
                                }
                                Db.FakeUserMatches.Add(fakeMatch);
                            }
                        }
                    }


                    await Db.SaveChangesAsync(_token);

                }
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
    public class BasketballPlayer
    {
        public string Name;
        public string TimeMatch;
        public int Points;
        public int Rebounds;
        public int Assists;
        public string TwoThrown;
        public string ThreeThrown;
        public string FreeThrown;
        public int Fauls;
        public int Blocks;
        public int Steals;
        public int Turnovers;
    }
}
