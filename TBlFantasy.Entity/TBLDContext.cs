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
    }
}