using bycoders.cnab.services;

namespace bycoders.cnab.unit.tests.Services
{
    public class FormFileValidatorTest
    {
        IFormFileValidator fileValidator;

        public FormFileValidatorTest() 
        {
            fileValidator = new FormFileValidator(); ;
        }

        [Fact]
        public void When_FileTypeIsInvalid_ShouldThrowArgumentException()
        {
            var invalid_file_type = ".pdf";            
            var expected_message = $"Não é aceito o formato {invalid_file_type}. Envie um arquivo '.txt'";

            var result = Assert.Throws<ArgumentException>(() => fileValidator.Validate(FormFileMock.BuildFormFileMock(invalid_file_type)));

            Assert.Equal(expected_message, result.Message);
        }
    }
}
