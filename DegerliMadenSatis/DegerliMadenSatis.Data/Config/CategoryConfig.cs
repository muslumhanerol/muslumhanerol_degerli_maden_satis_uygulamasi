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
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);//Her kategorinin Id sini primary key yap.
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            builder.Property(c => c.Name).IsRequired().HasMaxLength(50);
            builder.Property(c => c.Description).HasMaxLength(500);
            builder.Property(c => c.Url).HasMaxLength(500);
            builder.ToTable("Categories");
            builder.HasData(
                        new Category //Kendimiz kategori oluşturduk.
                        {
                            Id = 1,
                            Name = "Nesne Altın",
                            Description = "Altın Kategorisi",
                            Url = "nesne-altin"
                        },
                        new Category
                        {
                            Id = 2,
                            Name = "Dijital Altın",
                            Description = "Altın Kategorisi",
                            Url = "dijital-altin"
                        },
                         new Category
                         {
                             Id = 3,
                             Name = "Sarrafiye",
                             Description = "Sarrafiye Kategorisi",
                             Url = "sarrafiye-altin"
                         },
                        new Category
                        {
                            Id = 4,
                            Name = "Nesne Gümüş",
                            Description = "Gümüş Kategorisi",
                            Url = "nesne-gümüs"
                        },
                        new Category
                        {
                            Id = 5,
                            Name = "Dijital Gümüş",
                            Description = "Gümüş Kategorisi",
                            Url = "dijital-gümüs"
                        }
            );
        }
    }
}
