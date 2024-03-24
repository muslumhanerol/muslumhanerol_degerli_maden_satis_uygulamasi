using Microsoft.EntityFrameworkCore;
using DegerliMadenSatis.Business.Abstract;
using DegerliMadenSatis.Data;
using DegerliMadenSatis.Data.Abstract;
using DegerliMadenSatis.Data.Concrete;
using DegerliMadenSatis.Business.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options=>options.UseSqlite("Data Source=DegerliMadenSatis.sqlite")); //Bu satýr çalýþtýðýnda ApDbContext te nesne oluþacak.

builder.Services.AddScoped<IProductService, ProductManager>();//IProductService denildiðinde ProductManager versin diye ayarladýk ve ilk ProductManager de kullandýk.
builder.Services.AddScoped<IProductRepository, ProductRepository>();


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
