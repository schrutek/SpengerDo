using Spg.SpengerDo.App.Account.Business;
using Spg.SpengerDo.App.Model;
using Spg.SpengerDo.App.Presentation;

namespace Spg.SpengerDo.App.ToDo.Business
{
    public class TodoLogic : ITodoLogic
    {
        private readonly ITodoRepository _todoRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserRepository _userRepository;

        public TodoLogic(
            ITodoRepository todoRepository,
            ICategoryRepository categoryRepository,
            IUserRepository userRepository)
        {
            _todoRepository = todoRepository;
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
        }

        public IQueryable<ToDoItem> GetByUser(int userId)
        {
            return _todoRepository.GetByUser(userId);
        }

        public IQueryable<ToDoItem> GetByUserAndCategory(int userId, int categoryId)
        {
            return _todoRepository.GetByUserAndCategory(userId, categoryId);
        }

        public void Create(CreateTodo newTodo)
        {
            // Init
            Category? existingCategory = _categoryRepository.Find(newTodo.CategoryId);
            User? existingUser = _userRepository.Find(newTodo.UserId);
            // Validate
            // * Category must exist
            if (existingCategory is null)
            {
                throw CreateTodoException.FromCategoryNotFound();
            }
            // * User must exist
            if (existingUser is null)
            {
                throw CreateTodoException.FromUserNotFound();
            }
            // * Not more than 5 Todo's per User and Category
            int x = _todoRepository.GetByUserAndCategory(newTodo.UserId, newTodo.CategoryId).Count();
            if (_todoRepository.GetByUserAndCategory(newTodo.UserId, newTodo.CategoryId).Count() >= 5)
            {
                throw CreateTodoException.FromToManyTodos();
            }
            // * ...

            // Act
            ToDoItem newTodoItem = new ToDoItem(newTodo.Description, DateTime.Now)
            {
                CategoryNavigation = existingCategory,
                UserNavigation = existingUser,
            };
            // Save
            _todoRepository.Create(newTodoItem);
        }
    }
}
