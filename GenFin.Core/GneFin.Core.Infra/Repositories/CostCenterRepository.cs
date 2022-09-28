using GenFin.Core.Infra.Interfaces;

namespace GenFin.Core.Infra.Repositories
{
    public class CostCenterRepository : Repository<CostCenter, GenFinContexto>, ICostCenterRepository
    {
        public CostCenterRepository( GenFinContexto context ) : base( context )
        {
        }
    }
}