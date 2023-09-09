using bycoders.cnab.application.UseCases.Contracts;
using bycoders.cnab.application.UseCases.Impl;
using bycoders.cnab.domain.Entities;
using bycoders.cnab.domain.Interfaces;
using Moq;

namespace bycoders.cnab.unit.tests.Application
{
    public class GetSummaryOperationsByStoreTest
    {
        private IGetSummaryOperationsByStore GetSummary;
        private readonly Mock<ICNABOperationsRepository> CnabRepository;

        public GetSummaryOperationsByStoreTest()
        {
            CnabRepository = new Mock<ICNABOperationsRepository>();
            GetSummary = new GetSummaryOperationsByStore(CnabRepository.Object);
        }
        
        [Fact]
        public async void When_StoreHasOperations_ShouldCalculateOperations() 
        {
            //Arrange
            var storeName = "MY_STORE";
            double expected_result = 25;
            IList<CNABOperation> mockResults = new List<CNABOperation>()
            { 
                new CNABOperation(){ Value = 20, StoreName = storeName, TransactionType = new TransactionType{ Signal = '+'  } },
                new CNABOperation(){ Value = 15, StoreName = storeName, TransactionType = new TransactionType{ Signal = '+'  } },
                new CNABOperation(){ Value = 10, StoreName = storeName, TransactionType = new TransactionType{ Signal = '-'  } },
            };

            CnabRepository.Setup(m => m.GetOperationsByStoreName(storeName))
                          .Returns(Task.FromResult(mockResults));

            //Act
            var result = await GetSummary.GetSummary(storeName);
            
            //Assert
            Assert.Equal(expected_result, result.Total);
        }
    }
}
