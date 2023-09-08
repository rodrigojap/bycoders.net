using Microsoft.AspNetCore.Http;

namespace bycoders.cnab.application.UseCases.Contracts
{
    public interface IProcessCnabOperations
    {
        Task ProcessCnabFormFile(IFormFile CnabFormFile);
    }
}
