using Azure.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using WebApp.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddAzureKeyVault(
        new Uri($"{builder.Configuration["KeyVaultUri"]}"),
        new DefaultAzureCredential()
    );

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration["Sql"]));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(x =>
{
    x.IdleTimeout = TimeSpan.FromDays(30);
    x.Cookie.IsEssential = true;
    x.Cookie.HttpOnly = true;
});

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

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
