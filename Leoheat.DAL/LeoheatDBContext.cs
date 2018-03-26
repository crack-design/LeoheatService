using Leoheat.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using LeoheatService.Infrastructure;

namespace Leoheat.DAL
{
    public class LeoheatDbContext : IdentityDbContext<ApplicationUser>
    {
        public LeoheatDbContext(DbContextOptions<LeoheatDbContext> options) : base(options)
        {
        }

        public DbSet<LeoheatObject> LeoheatObjects { get; set; }
    }
}

