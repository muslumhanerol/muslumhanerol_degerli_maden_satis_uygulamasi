using DegerliMadenSatis.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DegerliMadenSatis.Data.Config
{
    public class CategoryProduckConfig : IEntityTypeConfiguration<CategoryProduct>
    {
        public void Configure(EntityTypeBuilder<CategoryProduct> builder)
        {
            builder.HasKey(x => new  { x.CategoryId, x.ProductId });//Çok fazla kategori olabilir bir döngüye girdirilip her bir katagori için uygula dedik.
            builder.ToTable("CategoryProducks");
           
        }
    }
}
