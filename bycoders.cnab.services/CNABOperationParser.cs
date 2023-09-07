using bycoders.cnab.domain.Entities;

namespace bycoders.cnab.services
{
    public class CNABOperationParser : IOperationParser
    {
        public CNABOperation BuildCNABOperationEntity(string entry)
        {
            //process

            return new CNABOperation();
        }
    }

    public interface IOperationParser
    {
        CNABOperation BuildCNABOperationEntity(string entry);
    }
}