using System.Reflection;
using TurnoProyecto.Models;
using TurnoProyecto.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(options =>{
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options => {
    options.LoginPath= "/Home";
    options.Events.OnRedirectToAccessDenied = context =>{
        context.Response.Redirect("/Home");
        return Task.CompletedTask;
    };
});
var connectionString = builder.Configuration.GetConnectionString("turnodb");
builder.Services.AddDbContext<TurnoContext>(x => x.UseSqlServer("connectionString"));
var app = builder.Build();
//builder.Services.AddScoped<filtroglobal>();


// Configure the HTTP request pipeline "TurnoContext":"Server=(localdb)\\mssqllocaldb;Database=turnoFB;Trusted_Connection=True;".
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
