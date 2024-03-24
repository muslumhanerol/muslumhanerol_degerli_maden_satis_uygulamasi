using Microsoft.EntityFrameworkCore;
using DegerliMadenSatis.Business.Abstract;
using DegerliMadenSatis.Data;
using DegerliMadenSatis.Data.Abstract;
using DegerliMadenSatis.Data.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options=>options.UseSqlite("Data Source=DegerliMadenSatis.sqlite")); //Bu sat�r �al��t���nda ApDbContext te nesne olu�acak.

builder.Services.AddScoped<IProductService, ProductManager>();//!!Hata VAR
builder.Services.AddScoped<IProductRepository, ProductRepository>(); //IProductRepository denildi�inde ProductRepository versin diye ayarlad�k.


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
