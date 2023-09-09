using bycoders.cnab.services;

namespace bycoders.cnab.unit.tests.Services
{
    public class CNABOperationParserTest
    {

        ICNABOperationParser _parser;

        public CNABOperationParserTest()
        {
            _parser = new CNABOperationParser();
        }

        [Fact]
        public void When_EntryIsEmpty_ShouldThrownArgumentException() 
        {
            //Arrange
            var invalid_entry = "";                        
            var expected_message = "Arquivo inválido! A linha se encontra vazia!";

            //Act
            var result = Assert.Throws<ArgumentException>(() => _parser.BuildCNABOperationEntity(invalid_entry));
            
            //Assert
            Assert.Equal(expected_message, result.Message); 
        }

        [Fact]
        public void When_EntryHasIncorrectLenght_ShouldThrownArgumentException()
        {
            //Arrange
            var invalid_entry = "111111111";            
            const int CNABLineSize = 80;
            var expected_message = $"Arquivo inválido! O tamanho experado é {CNABLineSize}, o tamanho recebido foi ${invalid_entry.Length}!";

            //Act
            var result = Assert.Throws<ArgumentException>(() => _parser.BuildCNABOperationEntity(invalid_entry));

            //Assert
            Assert.Equal(expected_message, result.Message);
        }

        [Fact]
        public void When_EntryIsValid_ShouldCreateOperationEntity()
        {
            //Arrange            
            var (valid_entry, expected_valid_CNABOperationEntity) = CNABOperationStub.GetValidCNABOperation();                        

            //Act
            var result = _parser.BuildCNABOperationEntity(valid_entry);

            //Assert
            Assert.Equivalent(expected_valid_CNABOperationEntity, result);
        }
    }
}
