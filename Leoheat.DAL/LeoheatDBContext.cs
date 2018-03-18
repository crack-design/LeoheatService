using Leoheat.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

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

namespace Leoheat.DAL
{
    public class ApplicationUser : IdentityUser
    {
    }
}