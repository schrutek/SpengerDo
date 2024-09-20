using Microsoft.EntityFrameworkCore;
using Spg.SpengerDo.App.Model;
using Spg.SpengerDo.App.Services;
using Spg.SpengerDo.App.ToDo.Business;

namespace Spg.SpengerDo.App.ToDo.Persistance
{
    public class TodoRepository : ITodoRepository
    {
        private readonly SpengerDoDBService _db;

        public TodoRepository(SpengerDoDBService db)
        {
            _db = db;
        }

        public IQueryable<ToDoItem> GetByUser(int userId)
        {
            return _db
                .ToDoItems
                .Include(t => t.CategoryNavigation)
                .Where(t => t.UserNavigation.Id == userId);
        }

        public IQueryable<ToDoItem> GetByUserAndCategory(int userId, int categoryId)
        {
            return _db
                .ToDoItems
                .Include(t => t.CategoryNavigation)
                .Where(t => t.UserNavigation.Id == userId
                    && t.CategoryNavigation.Id == categoryId);
        }

        public void Create(ToDoItem todoItem)
        {
            _db.ToDoItems.Add(todoItem);
            _db.SaveChanges();
        }
    }
}
