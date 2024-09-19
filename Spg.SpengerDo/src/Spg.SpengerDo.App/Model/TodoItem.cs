namespace Spg.SpengerDo.App.Model
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime CreationDateTime { get; set; }

        public Category CategoryNavigation { get; private set; } = default!;
        public User UserNavigation { get; private set; } = default!;

        protected ToDoItem()
        { }
        public ToDoItem(string description, DateTime creationDateTime)
        {
            Description = description;
            CreationDateTime = creationDateTime;
        }
        public ToDoItem(string description, DateTime creationDateTime, Category categoryNavigation)
        {
            Description = description;
            CreationDateTime = creationDateTime;
            CategoryNavigation = categoryNavigation;
        }
        public ToDoItem(string description, DateTime creationDateTime, Category categoryNavigation, User userNavigation)
        {
            Description = description;
            CreationDateTime = creationDateTime;
            CategoryNavigation = categoryNavigation;
            UserNavigation = userNavigation;
        }
    }
}