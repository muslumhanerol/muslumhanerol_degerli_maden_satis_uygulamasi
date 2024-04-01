using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DegerliMadenSatis.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegerliMadenSatis.Data.Concrete.Configs
{
    public class ProductCategoryConfig : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(x => new { x.ProductId, x.CategoryId }); //Çok fazla kategori olabilir bir döngüye girdirilip her bir katagori için uygula dedik.
            builder.ToTable("ProductCategories");
            builder.HasData( //Çoka çok ilişki kuruldu SeedDatat=Verilerin ilk oluşturulma aşaması.
                new ProductCategory { ProductId = 1, CategoryId = 1 },
                new ProductCategory { ProductId = 1, CategoryId = 2 },

                new ProductCategory { ProductId = 2, CategoryId = 1 },
                new ProductCategory { ProductId = 2, CategoryId = 2 },

                new ProductCategory { ProductId = 3, CategoryId = 1 },
                new ProductCategory { ProductId = 3, CategoryId = 2 },

                new ProductCategory { ProductId = 4, CategoryId = 1 },
                new ProductCategory { ProductId = 4, CategoryId = 2 },

                new ProductCategory { ProductId = 5, CategoryId = 1 },
                new ProductCategory { ProductId = 5, CategoryId = 2 },

                new ProductCategory { ProductId = 6, CategoryId = 1 },
                new ProductCategory { ProductId = 6, CategoryId = 2 },

                new ProductCategory { ProductId = 7, CategoryId = 1 },
                new ProductCategory { ProductId = 7, CategoryId = 2 },

                new ProductCategory { ProductId = 8, CategoryId = 1 },
                new ProductCategory { ProductId = 8, CategoryId = 2 },

                new ProductCategory { ProductId = 9, CategoryId = 3 },

                new ProductCategory { ProductId = 10, CategoryId = 3 },

                new ProductCategory { ProductId = 11, CategoryId = 3 },

                new ProductCategory { ProductId = 12, CategoryId = 4 },
                new ProductCategory { ProductId = 12, CategoryId = 5 },

                new ProductCategory { ProductId = 13, CategoryId = 4 },
                new ProductCategory { ProductId = 13, CategoryId = 5 },

                new ProductCategory { ProductId = 14, CategoryId = 4 },
                new ProductCategory { ProductId = 14, CategoryId = 5 },

                new ProductCategory { ProductId = 15, CategoryId = 4 },
                new ProductCategory { ProductId = 15, CategoryId = 5 });

        }
    }
}
