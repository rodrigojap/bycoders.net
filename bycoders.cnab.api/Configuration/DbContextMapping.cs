using bycoders.cnab.domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace bycoders.cnab.api.Configuration
{
    public class DbContextMapping : DbContext
    {
        public DbContextMapping(DbContextOptions<DbContextMapping> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<TransactionType> TransactionTypes { get; set; }
    }
}
