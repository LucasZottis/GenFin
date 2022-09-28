namespace GenFin.Core.Infra.Repositories
{
    public class TransactionRepository : Repository<Transaction, GenFinContexto>, ITransactionRepository
    {
        public TransactionRepository( GenFinContexto context ) : base( context )
        {
        }
    }
}