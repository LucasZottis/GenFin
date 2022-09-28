namespace GenFin.Core.Infra.Repositories
{
    public class RecurringTransactionRepository : Repository<RecurringTransaction, GenFinContexto>, IRecurringTransactionRepository
    {
        public RecurringTransactionRepository( GenFinContexto context ) : base( context )
        {
        }
    }
}