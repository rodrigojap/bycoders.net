namespace bycoders.cnab.domain.Entities
{
    public class CNABOperation
    {
        public int Id { get; set; }        

        public DateTime OperationDate { get; set; }

        public double Value { get; set; }

        public string CPF { get; set; }

        public string Card { get; set; }

        public string StoreOwner { get; set; }

        public string StoreName { get; set; }


        public int TransactionTypeId { get; set; }
        public TransactionType TransactionType { get; set; }
    }
}
