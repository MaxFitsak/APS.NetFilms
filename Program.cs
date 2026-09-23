using FilmMVC.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

var builder = WebApplication.CreateBuilder(args);

// Отримуємо рядок підключення з файлу конфігурації
var connection = builder.Configuration.GetConnectionString("DefaultConnection");

// Додаємо контекст StudentContext як сервіс у програму
builder.Services.AddDbContext<FilmContext>(options => options.UseSqlite(connection));

// Додаємо сервіси MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseStaticFiles(); // Обробляє запити до статичних файлів у папці wwwroot

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Films}/{action=Index}/{id?}");

app.Run();