using Spg.SpengerDo.App.Model;
using Spg.SpengerDo.App.Services;
using Spg.SpengerDo.App.ToDo.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.SpengerDo.App.ToDo.Persistance
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly SpengerDoDBService _db;

        public CategoryRepository(SpengerDoDBService db)
        {
            _db = db;
        }

        public IQueryable<Category> GetAllOrderedByName()
        {
            return _db
                .Categories
                .OrderBy(c => c.Name);
        }

        public Category? Find(int categoryId)
        {
            return _db.Categories.Find(categoryId);
        }

        public void Create(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
        }
    }
}
