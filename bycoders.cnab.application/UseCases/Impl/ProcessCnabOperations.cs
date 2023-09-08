using bycoders.cnab.application.UseCases.Contracts;
using bycoders.cnab.services;
using Microsoft.AspNetCore.Http;

namespace bycoders.cnab.application.UseCases.Impl
{
    public class ProcessCnabOperations : IProcessCnabOperations
    {
        private readonly ICNABOperationListParser CNABOperationListParser;

        public ProcessCnabOperations(ICNABOperationListParser cNABOperationListParser)
        {
            CNABOperationListParser = cNABOperationListParser;
        }

        public async Task ProcessCnabFormFile(IFormFile CnabFormFile)
        {
            try
            {
                //get list of entityes
                var listOfCnabOperations = await CNABOperationListParser.ParseFileIntoCNABEntities(CnabFormFile);

                //call save

                //commit
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
