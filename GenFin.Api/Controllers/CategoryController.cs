using GenFin.Core.Client.Models.Category;

namespace GenFin.Api.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryBusinessService _categoryBusinessService;

        public CategoryController( NLog.ILogger logger, ICategoryBusinessService categoryBusinessService )
            : base( logger, categoryBusinessService )
        {
            _categoryBusinessService = categoryBusinessService;
        }

        [HttpPost( "CreateNewCategory" )]
        public ActionResult<SimplifiedCategory> CreateNewCategory( NewCategory category )
        {
            try
            {
                return ValidateReturn( _categoryBusinessService.CreateNewCategory( category ) );
            }
            catch ( Exception ex )
            {
                return InternalServerError( ex );
            }
        }

        [HttpPost( "UpdateCategory" )]
        public ActionResult<SimplifiedCategory> UpdateCategory( UpdatedCategory category )
        {
            try
            {
                return ValidateReturn( _categoryBusinessService.UpdateCategory( category ) );
            }
            catch ( Exception ex )
            {
                return InternalServerError( ex );
            }
        }

        [HttpPost( "GetAllCategories" )]
        public ActionResult<IEnumerable<SimplifiedCategory>> GetAllCategories()
        {
            try
            {
                return ValidateReturn( _categoryBusinessService.GetAllCategories() );
            }
            catch ( Exception ex )
            {
                return InternalServerError( ex );
            }
        }

        [HttpPost( "DeleteCategory" )]
        public ActionResult DeleteCategory( int categoryId )
        {
            try
            {
                return ValidateReturn( () => _categoryBusinessService.DeleteCategory( categoryId ) );
            }
            catch ( Exception ex )
            {
                return InternalServerError( ex );
            }
        }
    }
}