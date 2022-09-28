namespace GenFin.Core.Infra.Repositories
{
    public class BillRepository : Repository<Bill, GenFinContexto>, IBillRepository
    {
        public BillRepository( GenFinContexto context ) : base( context )
        {
        }
    }
}