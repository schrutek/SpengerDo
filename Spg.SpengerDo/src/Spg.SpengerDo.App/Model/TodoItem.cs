namespace Spg.SpengerDo.App.Model
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime CreationDateTime { get; set; }

        public Category CategoryNavigation { get; set; } = default!;
        public User UserNavigation { get; set; } = default!;

        protected ToDoItem()
        { }
        public ToDoItem(string description, DateTime creationDateTime)
        {
            Description = description;
            CreationDateTime = creationDateTime;
        }
    }
}