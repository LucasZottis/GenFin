using GenFin.Core.Client.Models.CostCenter;

namespace GenFin.Core.Aplicacao.Interfaces
{
    public interface ICostCenterBusinessService : INegocio
    {
        SimplifiedCostCenter? CreateNewCostCenter( NewCostCenter costCenter );
        SimplifiedCostCenter? UpdateCostCenter( UpdatedCostCenter costCenter );
        void DisableCostCenter( int costCenterId );

        IEnumerable<SimplifiedCostCenter> GetAllCostCenters();

        internal bool IsNewCostCenterValid( NewCostCenter costCenter );
        internal bool IsUpdatedCostCenterValid( UpdatedCostCenter costCenter );
    }
}