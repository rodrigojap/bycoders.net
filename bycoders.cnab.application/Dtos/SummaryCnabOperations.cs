namespace bycoders.cnab.application.Dtos
{
    public class SummaryCnabOperations
    {
        public double Total { get; set; }

        public IList<OperationList> OperationsList { get; set; } = new List<OperationList>();
    }

    public class OperationList
    {
        public DateTime OperationDate { get; set; }

        public double Value { get; set; }

        public string CPF { get; set; }

        public string Card { get; set; }

        public string StoreOwner { get; set; }

        public string StoreName { get; set; }
        public string OperationDescription { get; set; }
    }
}
