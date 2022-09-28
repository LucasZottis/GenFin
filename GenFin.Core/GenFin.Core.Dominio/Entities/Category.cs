namespace GenFin.Core.Dominio.Entities
{
    [NickName( "Categoria" )]
    public class Category : Entity
    {
        [NickName( "Nome categoria" )]
        public string Name { get; set; }
        public bool ShowInCalendar { get; set; }

        public ICollection<BillItem> BillItems { get; set; }
        public ICollection<RecurringTransaction> RecurringTransactions { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}