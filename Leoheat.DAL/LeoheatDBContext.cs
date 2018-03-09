using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leoheat.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Leoheat.DAL
{
    public class LeoheatDbContext : DbContext
    {
        public LeoheatDbContext(DbContextOptions<LeoheatDbContext> options) : base(options)
        {
        }

        public DbSet<LeoheatObject> LeoheatObjects { get; set; }
    }
}
