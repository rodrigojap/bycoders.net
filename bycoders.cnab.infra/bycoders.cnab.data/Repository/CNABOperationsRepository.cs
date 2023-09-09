using bycoders.cnab.domain.Entities;
using bycoders.cnab.domain.Interfaces;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IList<string>> GetStores()
        {            
            var query = from ops in DbContext.CNABOperations
                         group ops by ops.StoreName into groupedOps
                         select new
                         {
                             StoreName = groupedOps.Key
                         };

           return await query.Select(x => x.StoreName).ToListAsync();            
        }

        public async Task<IList<CNABOperation>> GetOperationsByStoreName(string StoreName)
        {
            return await DbContext.CNABOperations.Where(c => c.StoreName.ToUpper() == StoreName.ToUpper()).Include(a => a.TransactionType).ToListAsync();
        }
    }
}
