using Spg.SpengerDo.App.Model;
using Spg.SpengerDo.App.ToDo.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.SpengerDo.App.Presentation
{
    public interface ICategoryLogic
    {
        IQueryable<Category> GetAllOrderedByName();
        void Create(CreateCategory newCategory);
    }
}
