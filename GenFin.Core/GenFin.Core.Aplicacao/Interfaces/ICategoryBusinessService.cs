using GenFin.Core.Client.Models.Category;

namespace GenFin.Core.Aplicacao.Interfaces
{
    public interface ICategoryBusinessService : INegocio
    {
        SimplifiedCategory? CreateNewCategory( NewCategory category );
        SimplifiedCategory? UpdateCategory( UpdatedCategory category );
        void DeleteCategory( int categoryId );

        IEnumerable<SimplifiedCategory> GetAllCategories();

        internal bool ValidateNewCategory( NewCategory category );
        internal bool ValidateUpdatedCategory( NewCategory category );
    }
}