using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TBlFantasy.Entity
{
    public class TBLDContext : IdentityDbContext<TBLUser, IdentityRole<Guid>, Guid>
    {
        public TBLDContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<TBLTeam> Teams { get; set; }
        public DbSet<TBLBasketballer> Basketballers { get; set; }
        public DbSet<TBLLeague> Leagues { get; set; }
        public DbSet<TBLMatches> Matches { get; set; }
        public DbSet<FakeUser> FakeUsers { get; set; }
        public DbSet<TBLTeamPlayer> TeamPlayers { get; set; }
        public DbSet<FakeUserMatches> FakeUserMatches { get; set; }
    }
}