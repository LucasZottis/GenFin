namespace GenFin.Core.Dominio.Entities
{
    public class RecurringTransaction : Entity
    {
        public int IdPaymentMethod { get; set; }
        public int IdCostCenter { get; set; }
        public int IdCategory { get; set; }
        public DateTime DateStart { get; set; }
        public decimal Value { get; set; }
        public PaymentStatus Status { get; set; }
        public TransactionKind Kind { get; set; }
        [NickName( "Descrição da transação" )]
        public string Description { get; set; }
        [NickName( "Estabelecimento" )]
        public string Establishment { get; set; }
        public int Frequency { get; set; }

        public PaymentMethod PaymentMethod { get; set; }
        public CostCenter CostCenter { get; set; }
        public Category Category { get; set; }

        public ICollection<RecurringAdjust> Adjusts { get; set; }
    }
}