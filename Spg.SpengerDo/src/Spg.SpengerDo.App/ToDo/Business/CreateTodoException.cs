namespace Spg.SpengerDo.App.ToDo.Business
{
    public class CreateTodoException : Exception
    {
        public CreateTodoException()
            : base()
        { }
        public CreateTodoException(string message)
            : base(message)
        { }
        public CreateTodoException(string message, Exception innerException)
            : base(message, innerException)
        { }

        public static CreateTodoException FromCategoryNotFound()
        {
            return new CreateTodoException("Category not found!");
        }
        public static CreateTodoException FromUserNotFound()
        {
            return new CreateTodoException("User not found!");
        }
        public static CreateTodoException FromToManyTodos()
        {
            return new CreateTodoException("To many Todo's! Just 5 allowed");
        }
    }
}
