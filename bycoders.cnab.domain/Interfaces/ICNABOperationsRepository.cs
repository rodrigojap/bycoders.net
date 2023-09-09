using bycoders.cnab.domain.Entities;

namespace bycoders.cnab.domain.Interfaces
{
    public interface ICNABOperationsRepository
    {
        Task AddOperationsAsync(IList<CNABOperation> CNABOperations);
        Task SaveAsync();
    }
}
