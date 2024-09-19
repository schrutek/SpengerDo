using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Spg.SpengerDo.App.Model;
using Spg.SpengerDo.App.Presentation;
using Spg.SpengerDo.Presentation.Models;

namespace Spg.SpengerDo.Presentation.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoLogic _todoLogic;
        private readonly ICategoryLogic _categoryLogic;

        public TodoController(
            ITodoLogic todoLogic, 
            ICategoryLogic categoryLogic)
        {
            _todoLogic = todoLogic;
            _categoryLogic = categoryLogic;
        }

        [HttpGet()]
        public IActionResult Index(TodoViewModel model)
        {
            SelectList categories = new SelectList(
                _categoryLogic.GetAllOrderedByName(), "Id", "Name");
            ViewBag.Categories = categories;
            int defaultCategory = int.Parse(categories.First().Value);

            IQueryable<ToDoItem> data;
            if (!model.CategoryId.HasValue)
            {
                data = _todoLogic.GetByUserAndCategory(model.UserId, defaultCategory);
            }
            else
            {
                data = _todoLogic.GetByUserAndCategory(model.UserId, model.CategoryId.Value);
            }
            return View(new TodoViewModel(defaultCategory, model.UserId, data.ToList()));
        }
    }
}
