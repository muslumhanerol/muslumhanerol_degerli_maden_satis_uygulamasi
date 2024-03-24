using Microsoft.EntityFrameworkCore;
using DegerliMadenSatis.Business.Abstract;
using DegerliMadenSatis.Data;
using DegerliMadenSatis.Data.Abstract;
using DegerliMadenSatis.Data.Concrete;
using DegerliMadenSatis.Business.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options=>options.UseSqlite("Data Source=DegerliMadenSatis.sqlite")); //Bu sat�r �al��t���nda ApDbContext te nesne olu�acak.

builder.Services.AddScoped<IProductService, ProductManager>();//IProductService denildi�inde ProductManager versin diye ayarlad�k ve ilk ProductManager de kulland�k.
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
