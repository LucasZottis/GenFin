using GenFin.Core.Client.Models.Category;

namespace GenFin.Core.Aplicacao.Interfaces
{
    public interface ICategoryBusinessService : INegocio
    {
        SimplifiedCategory? CreateNewCategory( NewCategory category );
        SimplifiedCategory? UpdateCategory( UpdatedCategory category );
        void DisableCategory( int categoryId );

        IEnumerable<SimplifiedCategory> GetAllCategories();

        internal bool IsNewCategoryValid( NewCategory category );
        internal bool IsUpdatedCategoryValid( NewCategory category );
    }
}