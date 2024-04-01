using DegerliMadenSatis.Business.Abstract;
using DegerliMadenSatis.Business.Concrete;
using DegerliMadenSatis.Data.Abstract;
using DegerliMadenSatis.Data.Concrete.Contexts;
using DegerliMadenSatis.Data.Concrete.Repositories;
using DegerliMadenSatis.Shared.Helpers.Abstract;
using DegerliMadenSatis.Shared.Helpers.Concrete;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DegerliMadenSatisDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection"))
);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IProductService, ProductManager>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<IImageHelper, ImageHelper>();

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

app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}"
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
