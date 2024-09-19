using Microsoft.EntityFrameworkCore;
using Spg.SpengerDo.App.Account.Business;
using Spg.SpengerDo.App.Account.Persistance;
using Spg.SpengerDo.App.Presentation;
using Spg.SpengerDo.App.Services;
using Spg.SpengerDo.App.ToDo.Business;
using Spg.SpengerDo.App.ToDo.Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//
// Configure DB Context
string? connectionString = builder.Configuration.GetConnectionString("SqLite");
builder.Services.AddDbContext<SpengerDoDatabase>(o => o.UseSqlite(connectionString));
//
// Configure Services and Repositories
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<ILoginLogic, LoginLogic>();
builder.Services.AddScoped<ITodoLogic, TodoLogic>();
builder.Services.AddScoped<ICategoryLogic, CategoryLogic>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
