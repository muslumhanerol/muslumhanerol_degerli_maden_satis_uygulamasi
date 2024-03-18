using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DegerliMadenSatis.Entity;
using Microsoft.EntityFrameworkCore;


namespace DegerliMadenSatis.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Category> Categories  {get; set;}
        public DbSet<Product> Products { get; set; }
        public DbSet<CategoryProduct> CategoryProducts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
