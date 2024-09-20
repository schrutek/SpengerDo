using Microsoft.EntityFrameworkCore;
using Spg.SpengerDo.App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.SpengerDo.App.Services
{
    public class SpengerDoDBService : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public DbSet<ToDoItem> ToDoItems => Set<ToDoItem>();
        public DbSet<Category> Categories => Set<Category>();

        public SpengerDoDBService()
        { }
        public SpengerDoDBService(DbContextOptions options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
