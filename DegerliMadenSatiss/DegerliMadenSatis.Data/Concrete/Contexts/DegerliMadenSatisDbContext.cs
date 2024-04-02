using Microsoft.EntityFrameworkCore;
using DegerliMadenSatis.Data.Concrete.Configs;
using DegerliMadenSatis.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DegerliMadenSatis.Entity.Concrete.identity;
using DegerliMadenSatis.Data.Extensions;

namespace DegerliMadenSatis.Data.Concrete.Contexts
{
    public class DegerliMadenSatisDbContext:IdentityDbContext<User, Role, string>
    {
        public DegerliMadenSatisDbContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> ShoppingCartItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Rol işlemlerini istesek buraya yazabilirdik, kalabalık tutmamak adına Data>Extensions>ModelBuilderExtensions içine yazdık.
            modelBuilder.SeedData();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryConfig).Assembly); 
            base.OnModelCreating(modelBuilder);
        }
    }
}
