using bycoders.cnab.application.Dtos;
using bycoders.cnab.application.UseCases.Contracts;
using bycoders.cnab.domain.Entities;
using bycoders.cnab.domain.Interfaces;

namespace bycoders.cnab.application.UseCases.Impl
{
    public class GetSummaryOperationsByStore : IGetSummaryOperationsByStore
    {
        private readonly ICNABOperationsRepository CnabRepository;

        public GetSummaryOperationsByStore(ICNABOperationsRepository cnabRepository) 
        {
            CnabRepository = cnabRepository;
        }

        public async Task<SummaryCnabOperations> GetSummary(string storeName)
        {
            var result = new SummaryCnabOperations();
            var listOfCnabOps = await CnabRepository.GetOperationsByStoreName(storeName);

            if (listOfCnabOps != null && listOfCnabOps.Any())
            {
                CalculateTotalAmount(result, listOfCnabOps);
                AutoMapOperationFields(result, listOfCnabOps);
            }

            return result;
        }

        private void CalculateTotalAmount(SummaryCnabOperations result, IList<CNABOperation> listOfCnabOps)
        {
            var sumOfInputOperations = listOfCnabOps.Where(a => a.TransactionType.Signal == '+').Sum(o => o.Value);
            var sumOfOutpuOperations = listOfCnabOps.Where(a => a.TransactionType.Signal == '-').Sum(o => o.Value);

            result.Total = sumOfInputOperations - sumOfOutpuOperations;
        }

        private void AutoMapOperationFields(SummaryCnabOperations result, IList<CNABOperation> listOfCnabOps)
        {
            foreach (var item in listOfCnabOps)
            {
                result.OperationsList.Add(new OperationList
                {
                    Card = item.Card,
                    CPF = item.CPF,
                    OperationDate = item.OperationDate,
                    OperationDescription = item.TransactionType.Description,
                    StoreName = item.StoreName,
                    StoreOwner = item.StoreOwner,
                    Value = item.Value
                });
            }
        }
    }
}
