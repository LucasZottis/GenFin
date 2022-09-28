namespace GenFin.Core.Infra.Repositories
{
    public class RecurringTransactionRepository : Repository<RecurringTransaction, GenFinContext>, IRecurringTransactionRepository
    {
        public RecurringTransactionRepository( GenFinContext context ) : base( context )
        {
        }
    }
}