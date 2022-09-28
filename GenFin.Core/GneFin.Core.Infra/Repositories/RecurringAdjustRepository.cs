namespace GenFin.Core.Infra.Repositories
{
    public class RecurringAdjustRepository : Repository<RecurringAdjust, GenFinContexto>, IRecurringAdjustRepository
    {
        public RecurringAdjustRepository( GenFinContexto context ) : base( context )
        {
        }
    }
}