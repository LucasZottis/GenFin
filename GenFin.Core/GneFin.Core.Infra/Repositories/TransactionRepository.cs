namespace GenFin.Core.Infra.Repositories
{
    public class TransactionRepository : Repository<Transaction, GenFinContext>, ITransactionRepository
    {
        public TransactionRepository( GenFinContext context ) : base( context )
        {
        }
    }
}