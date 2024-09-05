using Microsoft.EntityFrameworkCore;
using  Assurance.ApplicationCore.Entites;

namespace Assurance.Infrastructure.Context
{
    public class AssuranceContext : DbContext
    {
        public AssuranceContext(DbContextOptions<AssuranceContext> options) : base(options)
        {
        }

        public DbSet<AssuranceTardi> Assurance { get; set; }
    }
}
