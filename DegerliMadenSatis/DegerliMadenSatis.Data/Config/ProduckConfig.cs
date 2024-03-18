using DegerliMadenSatis.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegerliMadenSatis.Data.Config
{
    public class ProduckConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id); //Produckların Id alanı primary key olacak.
            builder.Property(p => p.Id).ValueGeneratedOnAdd();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Properties).IsRequired().HasMaxLength(1000);
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.ImageUrl).IsRequired();
            builder.ToTable("Products"); //Tablo isminin belirlenmei
            builder.HasData(
                new Product
                {
                    Id = 1,
                    Name ="10gr Külçe",
                    Price =24000,
                    Properties="24 Ayar saflıkta, 10 gr Külçe altın.",
                    Url= "10gr-külce",
                    ImageUrl= "1.png",
                    IsHome=true 
                },
                new Product
                {
                    Id = 2,
                    Name = "20gr Külçe",
                    Price = 48000,
                    Properties = "24 Ayar saflıkta, 20 gr Külçe altın.",
                    Url = "20gr-külce",
                    ImageUrl = "2.png",
                    IsHome = false
                },
                new Product
                {
                    Id = 4,
                    Name = "30gr Külçe",
                    Price = 24000,
                    Properties = "24 Ayar saflıkta, 30 gr Külçe altın.",
                    Url = "30gr-külce",
                    ImageUrl = "4.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 1,
                    Name = "10gr Külçe",
                    Price = 24000,
                    Properties = "24 Ayar saflıkta, 10 gr Külçe altın.",
                    Url = "10gr-külce",
                    ImageUrl = "1.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 1,
                    Name = "10gr Külçe",
                    Price = 24000,
                    Properties = "24 Ayar saflıkta, 10 gr Külçe altın.",
                    Url = "10gr-külce",
                    ImageUrl = "1.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 1,
                    Name = "10gr Külçe",
                    Price = 24000,
                    Properties = "24 Ayar saflıkta, 10 gr Külçe altın.",
                    Url = "10gr-külce",
                    ImageUrl = "1.png",
                    IsHome = true
                }

                );
        }
    }
}
