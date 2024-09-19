using Spg.SpengerDo.App.Account.Persistance;
using Spg.SpengerDo.App.Services;
using Spg.SpengerDo.App.Tests.Helpers;
using Spg.SpengerDo.App.ToDo.Business;
using Spg.SpengerDo.App.ToDo.Persistance;

namespace Spg.SpengerDo.App.Tests
{
    public class TodoLogicTests
    {
        [Fact]
        public void Should_CreateTodo_Success()
        {
            using (SpengerDoDatabase db = DatabaseUtilities.CreateMemoryDb())
            {
                // Arrange
                DatabaseUtilities.SeedDatabase(db);
                TodoLogic todoLogic = new TodoLogic(
                    new TodoRepository(db),
                        new CategoryRepository(db),
                            new UserRepository(db));

                // Act
                todoLogic.Create(new CreateTodo("Todo from UnitTest created", 1, 1));

                // Assert
                Assert.Equal(15, db.ToDoItems.Count());
            }
        }

        [Fact]
        public void Should_ThrowError_WhenCategoryNotFound()
        {
            using (SpengerDoDatabase db = DatabaseUtilities.CreateMemoryDb())
            {
                // Arrange
                DatabaseUtilities.SeedDatabase(db);
                TodoLogic todoLogic = new TodoLogic(
                    new TodoRepository(db),
                        new CategoryRepository(db),
                            new UserRepository(db));

                // Act / Assert
                Exception ex = Assert.Throws<CreateTodoException>(
                    () => todoLogic.Create(new CreateTodo("Todo from UnitTest NOT created", 99999, 1)));
                Assert.Equal(CreateTodoException.FromCategoryNotFound().Message, ex.Message);
            }
        }

        [Fact]
        public void Should_ThrowError_WhenUserNotFound()
        {
            using (SpengerDoDatabase db = DatabaseUtilities.CreateMemoryDb())
            {
                // Arrange
                DatabaseUtilities.SeedDatabase(db);
                TodoLogic todoLogic = new TodoLogic(
                    new TodoRepository(db),
                        new CategoryRepository(db),
                            new UserRepository(db));

                // Act / Assert
                Exception ex = Assert.Throws<CreateTodoException>(
                    () => todoLogic.Create(new CreateTodo("Todo from UnitTest NOT created", 1, 99999)));
                Assert.Equal(CreateTodoException.FromUserNotFound().Message, ex.Message);
            }
        }

        [Fact]
        public void Should_ThrowError_WhenMoreThanFiveTodos()
        {
            using (SpengerDoDatabase db = DatabaseUtilities.CreateMemoryDb())
            {
                // Arrange
                DatabaseUtilities.SeedDatabase(db);
                TodoLogic todoLogic = new TodoLogic(
                    new TodoRepository(db),
                        new CategoryRepository(db),
                            new UserRepository(db));

                // Act / Assert
                Exception ex = Assert.Throws<CreateTodoException>(
                    () => todoLogic.Create(new CreateTodo("Todo from UnitTest NOT created", 4, 5)));
                Assert.Equal(CreateTodoException.FromToManyTodos().Message, ex.Message);
            }
        }
    }
}
