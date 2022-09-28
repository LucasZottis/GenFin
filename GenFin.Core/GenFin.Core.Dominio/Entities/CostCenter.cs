namespace GenFin.Core.Dominio.Entities
{
    [NickName( "Centro de custo" )]
    public class CostCenter : Entity
    {
        [NickName( "Nome do centro de custo" )]
        public string Name { get; set; }

        public ICollection<BillItem> BillItems { get; set; }
        public ICollection<RecurringTransaction> RecurringTransactions { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}