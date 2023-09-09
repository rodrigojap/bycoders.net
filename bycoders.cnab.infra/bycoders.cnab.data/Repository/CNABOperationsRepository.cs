using bycoders.cnab.domain.Entities;
using bycoders.cnab.domain.Interfaces;

namespace bycoders.cnab.data.Repository
{
    public class CNABOperationsRepository : ICNABOperationsRepository
    {
        private readonly ApplicationDbContext DbContext;

        public CNABOperationsRepository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public async Task SaveAsync()
        {
            await DbContext.SaveChangesAsync();
        }

        public async Task AddOperationsAsync(IList<CNABOperation> CNABOperations)
        {
            await DbContext.CNABOperations.AddRangeAsync(CNABOperations);            
        }
    }
}
