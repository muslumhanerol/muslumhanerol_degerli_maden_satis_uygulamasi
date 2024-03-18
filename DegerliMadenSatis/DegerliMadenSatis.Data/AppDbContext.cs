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
            modelBuilder.ApplyConfiguration(new CategoryConfig());

           
                      



            base.OnModelCreating(modelBuilder);
        }
    }
}
