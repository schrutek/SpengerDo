using Spg.SpengerDo.App.Model;
using Spg.SpengerDo.App.Presentation;

namespace Spg.SpengerDo.App.ToDo.Business
{
    public class CategoryLogic : ICategoryLogic
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryLogic(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IQueryable<Category> GetAllOrderedByName()
        {
            return _categoryRepository.GetAllOrderedByName();
        }

        public void Create(CreateCategory newCategory)
        {
            // Init
            // Validate
            // Act
            Category category = new Category(newCategory.Name);
            // Save
            _categoryRepository.Create(category);
        }
    }
}
