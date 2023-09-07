namespace bycoders.cnab.domain.Entities
{
    public class TransactionType
    {
        public int Id { get; set; }

        public int Type { get; set; }

        public string Description { get; set; }

        public string Origin { get; set; }

        public char Signal { get; set; }

        
        public ICollection<CNABOperation> CNABOperations { get; set; }
    }
}
