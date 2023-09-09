using bycoders.cnab.application.UseCases.Contracts;
using bycoders.cnab.data;
using bycoders.cnab.services;
using Microsoft.AspNetCore.Http;

namespace bycoders.cnab.application.UseCases.Impl
{
    public class ProcessCnabOperations : IProcessCnabOperations
    {
        private readonly ICNABOperationListParser CNABOperationListParser;
        private readonly IFormFileValidator FileValidator;
        private readonly ApplicationDbContext DbContext;

        public ProcessCnabOperations(ICNABOperationListParser cNABOperationListParser, IFormFileValidator formFileValidator, ApplicationDbContext dbContext)
        {
            CNABOperationListParser = cNABOperationListParser;
            FileValidator = formFileValidator;
            DbContext = dbContext;
        }

        public async Task ProcessCnabFormFile(IFormFile CnabFormFile)
        {
            try
            {
                FileValidator.Validate(CnabFormFile);

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
