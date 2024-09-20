using Spg.SpengerDo.App.Account.Persistance;
using Spg.SpengerDo.App.Services;
using Spg.SpengerDo.App.Tests.Helpers;
using Spg.SpengerDo.App.ToDo.Business;
using Spg.SpengerDo.App.ToDo.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.SpengerDo.App.Tests
{
    public class CategoryLogicTests
    {
        [Fact]
        public void Should_CreateCategory_Success()
        {
            using (SpengerDoDBService db = DatabaseUtilities.CreateMemoryDb())
            {
                // Arrange
                DatabaseUtilities.SeedDatabase(db);
                CategoryLogic categoryLogic = new CategoryLogic(new CategoryRepository(db));

                // Act
                categoryLogic.Create(new CreateCategory("Test Category"));

                // Assert
                Assert.Equal(5, db.Categories.Count());
                Assert.Equal("Test Category", db.Categories.ElementAt(4).Name);
            }
        }
    }
}
