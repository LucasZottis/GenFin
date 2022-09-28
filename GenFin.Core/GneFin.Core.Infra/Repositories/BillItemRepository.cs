namespace GenFin.Core.Infra.Repositories
{
    public class BillItemRepository : Repository<BillItem, GenFinContexto>, IBillItemRepository
    {
        public BillItemRepository( GenFinContexto context ) : base( context )
        {
        }
    }
}