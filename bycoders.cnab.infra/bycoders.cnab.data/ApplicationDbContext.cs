using bycoders.cnab.domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace bycoders.cnab.data
{
    public class ApplicationDbContext : DbContext
    {        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {
            Database.EnsureCreated();
        }
        
        public void PopulateDb()
        {
            if (TransactionTypes.Any()) return;

            TransactionTypes.AddRange(new List<TransactionType>
                {
                    new TransactionType { Description = "Débito", Origin = "Entrada", Signal = '+', Type = 1 },
                    new TransactionType { Description = "Boleto", Origin = "Saída", Signal = '-', Type = 2 },
                    new TransactionType { Description = "Financiamento", Origin = "Saída", Signal = '-', Type = 3 },
                    new TransactionType { Description = "Crédito", Origin = "Entrada", Signal = '+', Type = 4 },
                    new TransactionType { Description = "Recebimento Empréstimo", Origin = "Entrada", Signal = '+', Type = 5 },
                    new TransactionType { Description = "Vendas", Origin = "Entrada", Signal = '+', Type = 6 },
                    new TransactionType { Description = "Recebimento TED", Origin = "Entrada", Signal = '+', Type = 7 },
                    new TransactionType { Description = "Recebimento DOC", Origin = "Entrada", Signal = '+', Type = 8 },
                    new TransactionType { Description = "Aluguel", Origin = "Saída", Signal = '-', Type = 9 }
                });

            SaveChanges();
        }

        public DbSet<TransactionType> TransactionTypes { get; set; }
        public DbSet<CNABOperation> CNABOperations { get; set; }
    }
}
