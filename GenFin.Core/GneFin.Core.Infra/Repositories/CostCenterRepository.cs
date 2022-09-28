using GenFin.Core.Infra.Interfaces;

namespace GenFin.Core.Infra.Repositories
{
    public class CostCenterRepository : Repository<CostCenter, GenFinContext>, ICostCenterRepository
    {
        public CostCenterRepository( GenFinContext context ) : base( context )
        {
        }
    }
}