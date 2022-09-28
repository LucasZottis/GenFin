namespace GenFin.Core.Dominio.Entities
{
    [NickName("Forma de pagamento")]
    public class PaymentMethod : Entity
    {
        [NickName( "Nome da forma de pagamento" )]
        public string Name { get; set; }

        public ICollection<RecurringTransaction> RecurringTransactions { get; set; }
    }
}