using bycoders.cnab.application.UseCases.Contracts;
using bycoders.cnab.application.UseCases.Impl;
using bycoders.cnab.domain.Entities;
using bycoders.cnab.domain.Interfaces;
using bycoders.cnab.services;
using bycoders.cnab.unit.tests.Services;
using Moq;

namespace bycoders.cnab.unit.tests.Application
{
    public class ProcessCnabOperationsTest
    {
        private readonly Mock<ICNABOperationListParser> cNABOperationListParser;
        private readonly Mock<IFormFileValidator> FileValidator;
        private readonly Mock<ICNABOperationsRepository> CnabRepository;

        IProcessCnabOperations CnabOperations;

        public ProcessCnabOperationsTest()
        {
            cNABOperationListParser = new Mock<ICNABOperationListParser>();
            FileValidator = new Mock<IFormFileValidator>();
            CnabRepository = new Mock<ICNABOperationsRepository>();
            CnabOperations = new ProcessCnabOperations(cNABOperationListParser.Object, FileValidator.Object, CnabRepository.Object);
        }

        [Fact]
        public void When_FileIsValid_ShouldSaveAndCommit()
        {
            var formFile = FormFileMock.BuildFormFileMock(".txt");
            IList<CNABOperation> result = new List<CNABOperation>() { new CNABOperation { } };            
            cNABOperationListParser.Setup(m => m.ParseFileIntoCNABEntities(formFile))
                                   .Returns(Task.FromResult(result));                                                

            CnabOperations.ProcessCnabFormFile(formFile);

            FileValidator.Verify(v => v.Validate(formFile), Times.Once);
            CnabRepository.Verify(v => v.AddOperationsAsync(result), Times.Once);
            CnabRepository.Verify(v => v.SaveAsync(), Times.Once);
        }
    }
}
