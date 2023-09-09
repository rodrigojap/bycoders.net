using bycoders.cnab.application.UseCases.Contracts;
using bycoders.cnab.data;
using bycoders.cnab.services;
using Microsoft.AspNetCore.Http;

namespace bycoders.cnab.application.UseCases.Impl
{
    public class ProcessCnabOperations : IProcessCnabOperations
    {
        private readonly ICNABOperationListParser CNABOperationListParser;
        private readonly ApplicationDbContext DbContext;

        public ProcessCnabOperations(ICNABOperationListParser cNABOperationListParser, ApplicationDbContext dbContext)
        {
            CNABOperationListParser = cNABOperationListParser;
            DbContext = dbContext;
        }

        public async Task ProcessCnabFormFile(IFormFile CnabFormFile)
        {
            try
            {
                var listOfCnabOperations = await CNABOperationListParser.ParseFileIntoCNABEntities(CnabFormFile);

                await DbContext.CNABOperations.AddRangeAsync(listOfCnabOperations);
                await DbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
