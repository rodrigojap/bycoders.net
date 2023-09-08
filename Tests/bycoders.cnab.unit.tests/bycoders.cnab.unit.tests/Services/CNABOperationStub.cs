using bycoders.cnab.domain.Entities;

namespace bycoders.cnab.unit.tests.Services
{
    public static class CNABOperationStub
    {
        public static Tuple<string, CNABOperation> GetValidCNABOperation()
        {
            var CNABOpStub = new CNABOperation()
            {
                CPF = "55641815063",
                Card = "3123****7687",
                OperationDate = new DateTime(2019, 03, 01, 14, 56, 07),
                StoreName = "LOJA DO Ó - MATRIZ",
                StoreOwner = "MARIA JOSEFINA",
                Value = 132,
                TransactionTypeId = 5
            };

            var CNABEquivalentLine = "5201903010000013200556418150633123****7687145607MARIA JOSEFINALOJA DO Ó - MATRIZ";

            return Tuple.Create(CNABEquivalentLine, CNABOpStub);
        }
    }
}
