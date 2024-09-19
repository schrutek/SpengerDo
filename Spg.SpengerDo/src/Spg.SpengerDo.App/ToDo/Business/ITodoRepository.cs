using Spg.SpengerDo.App.Model;

namespace Spg.SpengerDo.App.ToDo.Business
{
    public interface ITodoRepository
    {
        IQueryable<ToDoItem> GetByUser(int userId);
        IQueryable<ToDoItem> GetByUserAndCategory(int userId, int categoryId);

        void Create(ToDoItem todoItem);
    }
}
