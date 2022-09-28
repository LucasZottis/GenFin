namespace GenFin.Core.Infra.Repositories
{
    public class BillItemRepository : Repository<BillItem, GenFinContext>, IBillItemRepository
    {
        public BillItemRepository( GenFinContext context ) : base( context )
        {
        }
    }
}