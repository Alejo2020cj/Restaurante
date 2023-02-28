using Microsoft.EntityFrameworkCore;
using Restaurante.Datos;

var builder = WebApplication.CreateBuilder(args);
//Configuramos conexi�n a SQL SERVER
builder.Services.AddDbContext<ApplicationDbContext>(opciones =>
opciones.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSql"))
);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString
("ConexionSql")));
builder.Services.AddControllersWithViews();

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
