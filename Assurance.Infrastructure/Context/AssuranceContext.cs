using Microsoft.EntityFrameworkCore;
using  Assurance.ApplicationCore.Entites;

namespace Assurance.Infrastructure.Context
{
    public class AssuranceContext : DbContext
    {
        public AssuranceContext(DbContextOptions<AssuranceContext> options) : base(options)
        {
        }

        public DbSet<AssuranceClient> Assurance { get; set; }
    }
}
