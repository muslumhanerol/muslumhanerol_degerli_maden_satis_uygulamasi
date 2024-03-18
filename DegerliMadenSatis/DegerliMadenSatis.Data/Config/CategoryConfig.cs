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
                            Name = "10gr Külçe",
                            Description = "Altın",
                            Url = "10gr-külce"
                        },
                        new Category
                        {
                            Id = 2,
                            Name = "20gr Külçe",
                            Description = "Altın",
                            Url = "20gr-külce"
                        },
                        new Category
                        {
                            Id = 3,
                            Name = "10gr Külçe",
                            Description = "Gümüş",
                            Url = "10gr-külce"
                        },
                        new Category
                        {
                            Id = 4,
                            Name = "20gr Külçe",
                            Description = "Gümüş",
                            Url = "20gr-külce"
                        }
            );
        }
    }
}
