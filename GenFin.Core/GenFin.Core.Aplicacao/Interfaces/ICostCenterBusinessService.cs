using GenFin.Core.Client.Models.CostCenter;

namespace GenFin.Core.Aplicacao.Interfaces
{
    public interface ICostCenterBusinessService : INegocio
    {
        SimplifiedCostCenter? CreateNewCostCenter( NewCostCenter costCenter );
        SimplifiedCostCenter? UpdateCostCenter( UpdatedCostCenter costCenter );
        void DeleteCostCenter( int costCenterId );

        IEnumerable<SimplifiedCostCenter> GetAllCostCenters();

        internal bool ValidateNewCostCenter( NewCostCenter costCenter );
        internal bool ValidateUpdatedCostCenter( UpdatedCostCenter costCenter );
    }
}