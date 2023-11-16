using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sinmple.Data;

var builder = WebApplication.CreateBuilder(args);

// Configuración del contexto de datos
builder.Services.AddDbContext<SinmpleContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SinmpleContext") ?? throw new InvalidOperationException("Connection string 'SinmpleContext' not found.")));

// Configuración de servicios
builder.Services.AddControllersWithViews();

// Configuración de autenticación y cookies
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Acceso/Index";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        options.AccessDeniedPath = "/Home/Privacy";
    });

var app = builder.Build();

// Configuración del pipeline de solicitud HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

// Agregar middleware de autenticación y autorización
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Acceso}/{action=Index}/{id?}");

// Iniciar la aplicación
app.Run();
