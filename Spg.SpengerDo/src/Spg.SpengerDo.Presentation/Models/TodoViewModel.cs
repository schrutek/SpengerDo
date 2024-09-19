using Spg.SpengerDo.App.Model;

namespace Spg.SpengerDo.Presentation.Models
{
    public record TodoViewModel(int? CategoryId, int UserId, List<ToDoItem> Todos);
}
