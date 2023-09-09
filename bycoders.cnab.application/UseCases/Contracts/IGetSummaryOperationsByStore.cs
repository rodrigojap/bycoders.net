using bycoders.cnab.application.Dtos;

namespace bycoders.cnab.application.UseCases.Contracts
{
    public interface IGetSummaryOperationsByStore
    {
        Task<SummaryCnabOperations> GetSummary(string storeName);
    }
}
