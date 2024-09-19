using Spg.SpengerDo.App.Model;

namespace Spg.SpengerDo.App.ToDo.Business
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetAllOrderedByName();
        Category Find(int categoryId);
        void Create(Category category);
    }
}