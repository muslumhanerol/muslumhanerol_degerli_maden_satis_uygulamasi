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
    options.Password.RequiredLength = 6; //Parola 6 karakter olmal�.
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
    options.LoginPath = "/Account/Login"; //Giri� yap�laca��nda gidece�i adres.
    options.LogoutPath = "/"; //��k�� yap�laca��nda gidece�i adres.
    options.AccessDeniedPath = "/Account/AccessDenied"; //Kimliklendirme herkes keryere eri�emez.
    /*options.ExpireTimeSpan = TimeSpan.FromSeconds(45);*/ // kullan�c� i�lem yapmazsa 45 sn i�inde logout olacak.
    options.ExpireTimeSpan = TimeSpan.FromDays(1); // kullan�c� i�lem yapmazsa 1 g�n i�inde logout olacak.
    options.SlidingExpiration = true; //False olurse istek yap�lsa dahi logout olunur.
    options.Cookie = new CookieBuilder
    {
        Name = "DegerliMadenSatis.Security.Cookie",
        HttpOnly = true, //Site g�venlik �nlemi.
        SameSite = SameSiteMode.Strict //Site g�venlik �nlemi.
    };
}); 
    

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IShoppingCartService, ShoppingCartManager>();
builder.Services.AddScoped<IShoppingCartItemService, ShoppingCartItemManager>();
builder.Services.AddScoped<IOrderService, OrderManager>();



builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();
builder.Services.AddScoped<IShoppingCartItemRepository, ShoppingCartItemRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();




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
