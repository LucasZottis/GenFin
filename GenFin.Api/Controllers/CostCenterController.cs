using GenFin.Core.Client.Models.CostCenter;

namespace GenFin.Api.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class CostCenterController : Controller
    {
        private readonly ICostCenterBusinessService _costCenterBusinessService;

        public CostCenterController( NLog.ILogger logger, ICostCenterBusinessService costCenterBusinessService ) 
            : base( logger, costCenterBusinessService )
        {
        }

        [HttpPost( "CreateNewCostCenter" )]
        public ActionResult<SimplifiedCostCenter> CreateNewCostCenter( NewCostCenter costCenter )
        {
            try
            {
                return ValidateReturn( _costCenterBusinessService.CreateNewCostCenter( costCenter ) );
            }
            catch ( Exception ex )
            {
                return InternalServerError( ex );
            }
        }

        [HttpPost( "UpdateCostCenter" )]
        public ActionResult<SimplifiedCostCenter> UpdateCostCenter( UpdatedCostCenter costCenter )
        {
            try
            {
                return ValidateReturn( _costCenterBusinessService.UpdateCostCenter( costCenter ) );
            }
            catch ( Exception ex )
            {
                return InternalServerError( ex );
            }
        }

        [HttpPost( "GetAllCostCenters" )]
        public ActionResult<IEnumerable<SimplifiedCostCenter>> GetAllCostCenters()
        {
            try
            {
                return ValidateReturn( _costCenterBusinessService.GetAllCostCenters() );
            }
            catch ( Exception ex )
            {
                return InternalServerError( ex );
            }
        }

        [HttpPost( "DeleteCostCenter" )]
        public ActionResult DeleteCostCenter( int categoryId )
        {
            try
            {
                return ValidateReturn( () => _costCenterBusinessService.DeleteCostCenter( categoryId ) );
            }
            catch ( Exception ex )
            {
                return InternalServerError( ex );
            }
        }
    }
}