using EFDataAccessLib.DataAccess;
using WebApplication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication;
using SmartBreadcrumbs.Extensions;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PeopleContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultContext")));

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

builder.Services.AddBreadcrumbs(Assembly.GetExecutingAssembly() , options =>
{
    options.TagName = "nav";
    options.TagClasses = "";
    options.OlClasses = "breadcrumb";
    options.LiClasses = "breadcrumb-item";
    options.ActiveLiClasses = "breadcrumb-item active";
});

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseCookiePolicy();
app.UseSession();

app.MapRazorPages();

app.MapControllerRoute(
            name: "Admin",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
            name: "User",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
            name: "default",
            pattern: "{controller=App}/{action=Index}/{id?}");

app.MapControllerRoute(
            name: "Register",
            pattern: "{controller=Register}/{action=Index}/{code}");

app.MapControllerRoute(
            name: "Login",
            pattern: "{controller=Login}/{action=Index}");

app.Run();
