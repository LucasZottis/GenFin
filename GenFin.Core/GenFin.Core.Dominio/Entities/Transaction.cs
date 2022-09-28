namespace GenFin.Core.Dominio.Entities
{
    public class Transaction : Entity
    {
        public int IdCostCenter { get; set; }
        public int IdCategory { get; set; }
        public int IdPaymentSource { get; set; }
        public decimal Value { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public TransactionKind Kind { get; set; }
        [NickName( "Descrição da transação" )]
        public string Description { get; set; }
        [NickName( "Estabelecimento" )]
        public string Establishment { get; set; }
        public int Installment { get; set; }
        public int TotalInstallment { get; set; }

        public PaymentSource PaymentSource { get; set; }
        public CostCenter CostCenter { get; set; }
        public Category Category { get; set; }
    }
}