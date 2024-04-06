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
    #region Parola Ayarlar�
    options.Password.RequiredLength = 8; //Parola6 karakter olmal�.
    options.Password.RequireDigit = true; //Parola  say�sal de�er i�ermeli.
    options.Password.RequireNonAlphanumeric = true; //Parola �zel karakter i�ermeli.
    options.Password.RequireUppercase = true; //Parola b�y�k harf i�ermeli.
    options.Password.RequireLowercase = true; //Parola k���k harf i�ermeli.
                                              //options.Password.RequiredUniqueChars Tekrar etmemesi istenen karakterler.
    #endregion
    #region Hesap Kilitleme Ayarlar�
    options.Lockout.MaxFailedAccessAttempts = 3; //Hattal� giri� deneme s�n�r� max 5 dedik.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(15); //Kilitli hesab�n yeni giri� yapmak i�in bekleme s�resi.
    /*options.Lockout.AllowedForNewUsers = true;*/ //Ayn� kullan�c� ad�yla yeni hesap olu�turabilme.
    #endregion
    options.User.RequireUniqueEmail = true; //Her email sadece bir kez kay�t olabilir.
    options.SignIn.RequireConfirmedEmail = false; //Sisteme kay�t olabilecek ancak giri� yapamaz.
}); //User hesap ayarlar�.

builder.Services.ConfigureApplicationCookie(options =>
{

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
