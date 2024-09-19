using Spg.SpengerDo.App.Services;
using Spg.SpengerDo.App.Tests.Helpers;

namespace Spg.SpengerDo.App.Tests
{
    public class DatabaseTests
    {
        [Fact]
        public void Should_CreateAndSeedDatabase()
        {
            using (SpengerDoDatabase db = DatabaseUtilities.CreateDb())
            {
                // Arrange
                DatabaseUtilities.SeedDatabase(db);

                // Act

                // Assert
                Assert.Equal(7, db.Users.Count());
                Assert.Equal(4, db.Categories.Count());
                Assert.Equal(14, db.ToDoItems.Count());
            }
        }
    }
}