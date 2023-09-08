using bycoders.cnab.domain.Entities;
using Microsoft.AspNetCore.Http;

namespace bycoders.cnab.services
{
    public class CNABOperationListParser : ICNABOperationListParser
    {
        private readonly ICNABOperationParser CNABOperationParser;

        public CNABOperationListParser(ICNABOperationParser cNABOperationParser)
        {
            CNABOperationParser = cNABOperationParser;
        }

        public async Task<IList<CNABOperation>> ParseFileIntoCNABEntities(IFormFile file)
        {
            var result = new List<CNABOperation>();

            using (var reader = new StreamReader(file.OpenReadStream()))
            {
                while (reader.Peek() >= 0)
                {
                    var entryLine = await reader.ReadLineAsync() ?? "";
                    CNABOperationParser.SetNewEntry(entryLine);
                    result.Add(CNABOperationParser.BuildCNABOperationEntity());
                }
            }
            return result;
        }
    }

    public interface ICNABOperationListParser 
    {
        Task<IList<CNABOperation>> ParseFileIntoCNABEntities(IFormFile file);
    }
}
