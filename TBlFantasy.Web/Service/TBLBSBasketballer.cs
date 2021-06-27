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
                using (var scope = Services.CreateScope())
                {
                    var Db = scope.ServiceProvider.GetRequiredService<TBLDContext>();
                    var players = new List<BasketballPlayer>();
                    var matchAdress = new List<string>
                    { "https://www.mackolik.com/basketbol/mac/petkim-spor-kul%C3%BCb%C3%BC-vs-gaziantep-basketbol/83vx7erv9cxxyagg3dhm7b6s4", "https://www.mackolik.com/basketbol/mac/b%C3%BCy%C3%BCk%C3%A7ekmece-vs-fenerbah%C3%A7e/843w4o2uxdkkgqaoi68xx6uqc", "https://www.mackolik.com/basketbol/mac/anadolu-efes-spor-kul%C3%BCb%C3%BC-vs-p%C4%B1nar-kar%C5%9F%C4%B1yaka-spor-kul%C3%BCb%C3%BC/849guk47wuicunb38mt26n1n8", "https://www.mackolik.com/basketbol/mac/meksa-yat%C4%B1r%C4%B1m-afyon-belediyespor-vs-frutti-extra-bursaspor/83qnclwwkcgeorqsolyf4bmdw" , "https://www.mackolik.com/basketbol/mac/t%C3%BCrk-telekom-basketbol-kul%C3%BCb%C3%BC-vs-ogm-orman-spor-kul%C3%BCb%C3%BC/84ep84pgbd90f01qy0awxkx78", "https://www.mackolik.com/basketbol/mac/tofa%C5%9F-spor-kul%C3%BCb%C3%BC-vs-fethiye-belediye-basketbol-kul%C3%BCb%C3%BC/84knww2h5fnbxwg1ywcxul3bo", "https://www.mackolik.com/basketbol/mac/bah%C3%A7e%C5%9Fehir-koleji-spor-kul%C3%BCb%C3%BC-vs-galatasaray/84qbo1cvbkpfxoecmboqlvtw4" ,"https://www.mackolik.com/basketbol/mac/dar%C3%BC%C5%9F%C5%9Fafaka-spor-kul%C3%BCb%C3%BC-vs-be%C5%9Fikta%C5%9F-icrypex/84w5swmnuobkj5udlxiwi27tg" };
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
        // public int No;
        // public string Name;
        // public string Position;
        // public int Height;
        // public int Age;
        // public int Match;
        // public string Matchtime;
        // public decimal AverageP;
        // public decimal AverageA;
        // public decimal AverageR;
    }
}
