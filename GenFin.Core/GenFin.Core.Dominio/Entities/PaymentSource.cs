namespace GenFin.Core.Dominio.Entities
{
    [NickName( "Fonte de pagamento" )]
    public class PaymentSource : PaymentMethod
    {
        public bool IncludeInBalance { get; set; }

        public ICollection<Bill> PaidBills { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}