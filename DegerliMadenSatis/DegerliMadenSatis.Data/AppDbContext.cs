using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using DegerliMadenSatis.Entity;
using Microsoft.EntityFrameworkCore;


namespace DegerliMadenSatis.Data
{
    public class AppDbContext : DbContext
    {
        //Veri tabanının kalbi katagoriler ile ürünler burada eşleniyor.
        public DbSet<Category> Categories  {get; set;}
        public DbSet<Product> Products { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)//Kategoriler ile ürünlere primary key atama işlemi
        {
            #region CatagoryProduct
            modelBuilder.Entity<CategoryProduct>().HasKey(x=> new //Çok fazla kategori olabilir bir döngüye girdirilip her bir katagori için uygula dedik.
            { x.CategoryId, x.ProductId});
            #endregion

            #region Category
            modelBuilder.Entity<Category>().HasKey(c => c.Id);//Her kategorinin Id sini primary key yap.
            modelBuilder.Entity<Category>().Property(c => c.Id).ValueGeneratedOnAdd();
            
            modelBuilder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Category>().Property(c => c.Description).HasMaxLength(500);
            modelBuilder.Entity<Category>().Property(c => c.Url).HasMaxLength(500);


            #endregion



            base.OnModelCreating(modelBuilder);
        }
    }
}
