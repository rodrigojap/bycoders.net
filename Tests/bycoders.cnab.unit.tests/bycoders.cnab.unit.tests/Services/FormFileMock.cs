using Microsoft.AspNetCore.Http;
using Moq;

namespace bycoders.cnab.unit.tests.Services
{
    internal static class FormFileMock
    {
        internal static IFormFile BuildFormFileMock(string FileType)
        {            
            var fileMock = new Mock<IFormFile>();
            fileMock.Setup(_ => _.FileName).Returns(FileType);

            return fileMock.Object;
        }
    }
}
