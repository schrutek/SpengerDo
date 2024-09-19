namespace Spg.SpengerDo.App.Model
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string EMail { get; set; } = string.Empty;
        
        public List<ToDoItem> ToDoItems { get; private set; } = new();

        protected User()
        { }
        public User(string firstName, string lastName, string eMail)
        {
            FirstName = firstName;
            LastName = lastName;
            EMail = eMail;
        }

        public User AddToDoItem(ToDoItem toDoItem)
        {
            ToDoItems.Add(toDoItem);
            return this;
        }
    }
}
