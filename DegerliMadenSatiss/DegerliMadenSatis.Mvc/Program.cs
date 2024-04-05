using DegerliMadenSatis.Business.Abstract;
using DegerliMadenSatis.Business.Concrete;
using DegerliMadenSatis.Data.Abstract;
using DegerliMadenSatis.Data.Concrete.Contexts;
using DegerliMadenSatis.Data.Concrete.Repositories;
using DegerliMadenSatis.Entity.Concrete.identity;
using DegerliMadenSatis.Shared.Helpers.Abstract;
using DegerliMadenSatis.Shared.Helpers.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DegerliMadenSatisDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection"))
);

builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<DegerliMadenSatisDbContext>()
    .AddDefaultTokenProviders();


builder.Services.Configure<IdentityOptions>(options =>
{
    #region Parola Ayarlarý
    options.Password.RequiredLength = 8; //Parola6 karakter olmalý.
    options.Password.RequireDigit = true; //Parola  sayýsal deðer içermeli.
    options.Password.RequireNonAlphanumeric = true; //Parola özel karakter içermeli.
    options.Password.RequireUppercase = true; //Parola büyük harf içermeli.
    options.Password.RequireLowercase = true; //Parola küçük harf içermeli.
                                              //options.Password.RequiredUniqueChars Tekrar etmemesi istenen karakterler.
    #endregion
    #region Hesap Kilitleme Ayarlarý

    #endregion
});

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
