using bycoders.cnab.application.UseCases.Contracts;
using bycoders.cnab.data;
using bycoders.cnab.domain.Interfaces;
using bycoders.cnab.services;
using Microsoft.AspNetCore.Http;

namespace bycoders.cnab.application.UseCases.Impl
{
    public class ProcessCnabOperations : IProcessCnabOperations
    {
        private readonly ICNABOperationListParser CNABOperationListParser;
        private readonly IFormFileValidator FileValidator;
        private readonly ICNABOperationsRepository CnabRepository;

        public ProcessCnabOperations(ICNABOperationListParser cNABOperationListParser, IFormFileValidator formFileValidator, ICNABOperationsRepository cnabRepository)
        {
            CNABOperationListParser = cNABOperationListParser;
            FileValidator = formFileValidator;
            CnabRepository = cnabRepository;
        }

        public async Task ProcessCnabFormFile(IFormFile CnabFormFile)
        {
            try
            {
                FileValidator.Validate(CnabFormFile);

                var listOfCnabOperations = await CNABOperationListParser.ParseFileIntoCNABEntities(CnabFormFile);

                await CnabRepository.AddOperationsAsync(listOfCnabOperations); 
                await CnabRepository.SaveAsync(); 
            }
            catch (Exception)
            {
                throw;
            }            
        }
    }
}
