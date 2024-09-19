namespace Spg.SpengerDo.App.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<ToDoItem> ToDoItems { get; private set; } = new();

        protected Category()
        { }
        public Category(string name)
        {
            Name = name;
        }

        public Category AddToDoItem(ToDoItem toDoItem)
        {
            ToDoItems.Add(toDoItem);
            return this;
        }
    }
}
