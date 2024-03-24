using Microsoft.EntityFrameworkCore;
using DegerliMadenSatis.Business.Abstract;
using DegerliMadenSatis.Data;
using DegerliMadenSatis.Data.Abstract;
using DegerliMadenSatis.Data.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options=>options.UseSqlite("Data Source=DegerliMadenSatis.sqlite")); //Bu satýr çalýþtýðýnda ApDbContext te nesne oluþacak.

builder.Services.AddScoped<IProductService, ProductManager>();//!!Hata VAR
builder.Services.AddScoped<IProductRepository, ProductRepository>(); //IProductRepository denildiðinde ProductRepository versin diye ayarladýk.


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
