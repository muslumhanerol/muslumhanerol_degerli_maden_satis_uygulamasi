using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using DegerliMadenSatis.Data.Config;
using DegerliMadenSatis.Entity;
using Microsoft.EntityFrameworkCore;


namespace DegerliMadenSatis.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options): base(options) //Bu satır consracter. Class tan yeni bir nesne oluşturulduğunda çalışır.
        {

        }

        //Veri tabanının kalbi katagoriler ile ürünler burada eşleniyor.
        public DbSet<Category> Categories  {get; set;}
        public DbSet<Product> Products { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }
      
        protected override void OnModelCreating(ModelBuilder modelBuilder)//Kategoriler ile ürünlere primary key atama işlemi
        {
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new ProduckConfig());
            modelBuilder.ApplyConfiguration(new CategoryProduckConfig()); 
            base.OnModelCreating(modelBuilder);
        }
    }
}
