using bycoders.cnab.domain.Entities;
using bycoders.cnab.extensions;

namespace bycoders.cnab.services
{
    public class CNABOperationParser : ICNABOperationParser
    {        
        private string CnabLine { get; set; } = string.Empty;                
        private CNABOperation CnabOperationEntity { get; set; } = new CNABOperation();
        const int CNABLineSize = 80;

        public CNABOperationParser()
        {
            InitializeCnabOperationEntity();
        }

        public void SetNewEntry(string newEntryLine)
        {
            CnabLine = newEntryLine;
            InitializeCnabOperationEntity();
        }

        public CNABOperation BuildCNABOperationEntity()
        {            
            ValidateNullEmptyCnabLine();
            ValidateCnabLineSize();

            var SpanCnabLine = CnabLine.AsSpan();
            
            FillOperationType(SpanCnabLine);
            FillOperationDate(SpanCnabLine);
            FillOperationValue(SpanCnabLine);
            FillOperationCPF(SpanCnabLine);
            FillOperationCreditCard(SpanCnabLine);            
            FillOperationStoreOwner(SpanCnabLine);
            FillOperationStoreName(SpanCnabLine);

            return CnabOperationEntity;
        }
       
        private void ValidateNullEmptyCnabLine()
        {
            if (string.IsNullOrEmpty(CnabLine)) throw new ArgumentException("Arquivo inválido! A linha se encontra vazia!");
        }

        private void ValidateCnabLineSize()
        {
            if (CnabLine.Length != CNABLineSize) throw new ArgumentException($"Arquivo inválido! O tamanho experado é {CNABLineSize}, o tamanho recebido foi ${CnabLine.Length}!");
        }        

        private void InitializeCnabOperationEntity()
        {
            CnabOperationEntity = new CNABOperation();
        }

        private void FillOperationType(ReadOnlySpan<char> spanCnabLine)
        {
            CnabOperationEntity.TransactionTypeId = spanCnabLine.IntegerSlice(0, 1);
        }

        private void FillOperationStoreName(ReadOnlySpan<char> spanCnabLine)
        {
            CnabOperationEntity.StoreName = spanCnabLine.StringSlice(62, 18);
        }

        private void FillOperationStoreOwner(ReadOnlySpan<char> spanCnabLine)
        {
            CnabOperationEntity.StoreOwner = spanCnabLine.StringSlice(48, 14);
        }        

        private void FillOperationCreditCard(ReadOnlySpan<char> spanCnabLine)
        {
            CnabOperationEntity.Card = spanCnabLine.StringSlice(30, 12);
        }

        private void FillOperationCPF(ReadOnlySpan<char> spanCnabLine)
        {
            CnabOperationEntity.CPF = spanCnabLine.StringSlice(19, 11);
        }

        private void FillOperationValue(ReadOnlySpan<char> spanCnabLine)
        {
            CnabOperationEntity.Value = spanCnabLine.DoubleSlice(9, 10) / 100;
        }

        private void FillOperationDate(ReadOnlySpan<char> spanCnabLine)
        {
            var yearSlice = spanCnabLine.IntegerSlice(1, 4);
            var monhtSlice = spanCnabLine.IntegerSlice(5, 2);
            var day = spanCnabLine.IntegerSlice(7, 2);

            var hoursSlice = spanCnabLine.IntegerSlice(42, 2);
            var minutesSlice = spanCnabLine.IntegerSlice(44, 2);
            var secondsSlice = spanCnabLine.IntegerSlice(46, 2);

            CnabOperationEntity.OperationDate = new DateTime(yearSlice, monhtSlice, day, hoursSlice, minutesSlice, secondsSlice, DateTimeKind.Utc);                
        }
    }

    public interface ICNABOperationParser
    {
        CNABOperation BuildCNABOperationEntity();

        void SetNewEntry(string newEntryLine);
    }
}