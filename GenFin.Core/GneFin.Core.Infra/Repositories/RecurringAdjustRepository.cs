namespace GenFin.Core.Infra.Repositories
{
    public class RecurringAdjustRepository : Repository<RecurringAdjust, GenFinContext>, IRecurringAdjustRepository
    {
        public RecurringAdjustRepository( GenFinContext context ) : base( context )
        {
        }
    }
}