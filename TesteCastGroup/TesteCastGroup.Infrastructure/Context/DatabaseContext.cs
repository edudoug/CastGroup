using Microsoft.EntityFrameworkCore;
using TesteCastGroup.Domain.Model;

namespace TesteCastGroup.Infrastructure.Context
{
    public class DatabaseContext: DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
        public DbSet<Conta> Contas { get; set; }
    }
}
