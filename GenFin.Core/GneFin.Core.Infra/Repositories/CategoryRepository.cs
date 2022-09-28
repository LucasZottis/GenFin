using GenFin.Core.Infra.Interfaces;

namespace GenFin.Core.Infra.Repositories
{
    public class CategoryRepository : Repository<Category, GenFinContext>, ICategoryRepository
    {
        public CategoryRepository( GenFinContext context ) : base( context )
        {
        }
    }
}