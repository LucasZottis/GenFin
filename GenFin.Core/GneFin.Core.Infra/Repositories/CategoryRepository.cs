using GenFin.Core.Infra.Interfaces;

namespace GenFin.Core.Infra.Repositories
{
    public class CategoryRepository : Repository<Category, GenFinContexto>, ICategoryRepository
    {
        public CategoryRepository( GenFinContexto context ) : base( context )
        {
        }
    }
}