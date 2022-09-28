namespace GenFin.Core.Dominio.Entities
{
    [NickName( "Fatura" )]
    public class Bill : Entity
    {
        public int IdCreditCard { get; set; }
        public int IdPaymentSource { get; set; }
        public DateTime BillDueDate { get; set; }
        public decimal PaidValue { get; set; }
        public PaymentStatus PaymentStatus { get; set; }

        public CreditCard CreditCard { get; set; }
        public PaymentSource PaymentSource { get; set; }

        public ICollection<BillItem> BillItems { get; set; }
    }
}