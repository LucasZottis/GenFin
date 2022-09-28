namespace GenFin.Core.Infra.Repositories
{
    public class BillRepository : Repository<Bill, GenFinContext>, IBillRepository
    {
        public BillRepository( GenFinContext context ) : base( context )
        {
        }
    }
}