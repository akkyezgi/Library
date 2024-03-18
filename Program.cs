using LibraryApp.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<LibraryContext>(options => options.UseSqlServer(connectionString));

var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=home}/{action=index}/{id?}"
    );

 // app.MapDefaultControllerRoute();  -> üstteki açýk uzun hali yerine artýk bunu kullanabilirim.

app.Run();
