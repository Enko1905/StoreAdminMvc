using Service.Contracts;
using Service;
using StoreAdmin.Extensions;
using Microsoft.AspNetCore.Authentication.Certificate;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//builder.Services.AddScoped<IMainCategoryService,MainCategoryManager>();
builder.Services.AddScoped<IMainCategoryService, MainCategoryManager>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();


builder.Services.HttpConfigureServices(builder.Configuration);


// Usage example:

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
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();
