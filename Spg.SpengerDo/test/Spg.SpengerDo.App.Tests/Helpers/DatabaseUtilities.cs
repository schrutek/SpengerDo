using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Spg.SpengerDo.App.Model;
using Spg.SpengerDo.App.Services;

namespace Spg.SpengerDo.App.Tests.Helpers
{
    public static class DatabaseUtilities
    {
        public static SpengerDoDatabase CreateDb()
        {
            DbContextOptions options = new DbContextOptionsBuilder()
                .UseSqlite("Data Source = .\\..\\..\\..\\..\\..\\SpengerDo.db")
                .Options;

            SpengerDoDatabase db = new SpengerDoDatabase(options);
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            return db;
        }

        public static SpengerDoDatabase CreateMemoryDb()
        {
            SqliteConnection connection = new SqliteConnection("Data Source=:memory:");
            connection.Open();

            DbContextOptions options = new DbContextOptionsBuilder()
                .UseSqlite(connection)
                .Options;

            SpengerDoDatabase db = new SpengerDoDatabase(options);
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            return db;
        }

        public static void SeedDatabase(SpengerDoDatabase db)
        {
            List<Category> categories = GetSeedingCategories();
            db.Categories.AddRange(categories);
            db.SaveChanges();

            List<User> users = GetSeedingUsers(categories);
            db.Users.AddRange(users);
            db.SaveChanges();
        }

        public static List<User> GetSeedingUsers(List<Category> categories)
        {
            return new List<User>()
            {
                new User(
                    "Hans",
                    "Reinsch",
                    "hans@reinsch.at"
                )
                    .AddToDoItem(new ToDoItem("Mails durchsehen und beantworten", new DateTime(2024, 09, 11)) 
                        { CategoryNavigation = categories.ElementAt(0) })
                    .AddToDoItem(new ToDoItem("Wöchentlichen Einkaufszettel erstellen", new DateTime(2024, 09, 08)) 
                        { CategoryNavigation = categories.ElementAt(0) })
                    .AddToDoItem(new ToDoItem("30 Minuten Sport oder Yoga machen", new DateTime(2024, 09, 03)) 
                        { CategoryNavigation = categories.ElementAt(0) })
                    .AddToDoItem(new ToDoItem("Arbeitsprojekte aktualisieren oder überprüfen", new DateTime(2024, 08, 28)) 
                        { CategoryNavigation = categories.ElementAt(1) })
                    .AddToDoItem(new ToDoItem("15 Minuten Meditieren oder Achtsamkeitsübung", new DateTime(2024, 08, 22)) 
                        { CategoryNavigation = categories.ElementAt(1) }),
                new User(
                    "Anna",
                    "Theke",
                    "anna-theke@gmail.com"
                )
                    .AddToDoItem(new ToDoItem("Termine für nächste Woche planen", new DateTime(2024, 08, 21)) 
                        { CategoryNavigation = categories.ElementAt(1) }),
                new User(
                    "Axel",
                    "Schweiß",
                    "schweiß_axel@gmail.com"
                )
                    .AddToDoItem(new ToDoItem("Zimmer aufräumen und durchlüften", new DateTime(2024, 08, 19)) 
                        { CategoryNavigation = categories.ElementAt(2) }),
                new User(
                    "Toni",
                    "Fit",
                    "hans@reinsch@gmx.at"
                )
                    .AddToDoItem(new ToDoItem("Wasserflasche auffüllen und hydratisiert bleiben", new DateTime(2024, 06, 26)) 
                        { CategoryNavigation = categories.ElementAt(2) }),
                new User(
                    "Anna",
                    "Nass",
                    "annnass@gmail.com"
                )
                    .AddToDoItem(new ToDoItem("Kurz mit einem Freund oder Familienmitglied telefonieren", new DateTime(2024, 06, 02)) 
                        { CategoryNavigation = categories.ElementAt(2) })
                    .AddToDoItem(new ToDoItem("Etwas Neues lernen (ein Artikel oder Video)", new DateTime(2024, 05, 19)) 
                        { CategoryNavigation = categories.ElementAt(3) })
                    .AddToDoItem(new ToDoItem("5 Minuten lang Dehnübungen machen", new DateTime(2024, 05, 12)) 
                        { CategoryNavigation = categories.ElementAt(3) })
                    .AddToDoItem(new ToDoItem("Eine To-Do-Liste für den nächsten Tag erstellen1", new DateTime(2024, 05, 05)) 
                        { CategoryNavigation = categories.ElementAt(3) })
                    .AddToDoItem(new ToDoItem("Eine To-Do-Liste für den nächsten Tag erstellen2", new DateTime(2024, 05, 02)) 
                        { CategoryNavigation = categories.ElementAt(3) })
                    .AddToDoItem(new ToDoItem("Eine To-Do-Liste für den nächsten Tag erstellen3", new DateTime(2024, 04, 18)) 
                        { CategoryNavigation = categories.ElementAt(3) }),
                new User(
                    "Max",
                    "Dünnsch",
                    "max.duensch@gmx.at"
                ),
                new User(
                    "Uri",
                    "Nierer",
                    "urinierer@gmx.at"
                ),
            };
        }

        public static List<Category> GetSeedingCategories()
        {
            return new List<Category>()
            {
                new Category("Einkaufen"),
                new Category("Aufräumen"),
                new Category("Autopflege"),
                new Category("Job"),
            };
        }
    }
}
