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
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id); //Productların Id alanı primary key olacak.
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
                    Name = "20gr Külçe Altın",
                    Price = 48000,
                    Properties = "24 Ayar Saflıkta, 20 gr Külçe Altın.",
                    Url = "20gr-külce-altin",
                    ImageUrl = "1.png",
                    IsHome = false
                },
                new Product
                {
                    Id = 2,
                    Name = "50gr Külçe Altın",
                    Price = 120000,
                    Properties = "24 Ayar Saflıkta, 50 gr Külçe Altın.",
                    Url = "50gr-külce-altin",
                    ImageUrl = "2.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 3,
                    Name = "100gr Külçe Altın",
                    Price = 240000,
                    Properties = "24 Ayar Saflıkta, 100 gr Külçe Altın.",
                    Url = "100gr-külce-altin",
                    ImageUrl = "3.png",
                    IsHome = true
                },
                 new Product
                 {
                     Id = 4,
                     Name = "250gr Külçe Altın",
                     Price = 620000,
                     Properties = "24 Ayar Saflıkta, 250 gr Külçe Altın.",
                     Url = "250gr-külce-altin",
                     ImageUrl = "4.png",
                     IsHome = true
                 },
                new Product
                {
                    Id = 5,
                    Name = "Çeyrek Altın",
                    Price = 4500,
                    Properties = "24 Ayar Saflıkta, Çeyrek Altın.",
                    Url = "ceyrek-altin",
                    ImageUrl = "5.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 6,
                    Name = "Yarım Altın",
                    Price = 90000,
                    Properties = "24 Ayar Saflıkta, Yarım Altın.",
                    Url = "yarim-altin",
                    ImageUrl = "6.png",
                    IsHome = false
                },
                new Product
                {
                    Id = 7,
                    Name = "Tam Altın",
                    Price = 180000,
                    Properties = "24 Ayar Saflıkta, Tam Altın.",
                    Url = "tam-altin",
                    ImageUrl = "7.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 8,
                    Name = "100gr Külçe Gümüş",
                    Price = 45000,
                    Properties = "925 Saflıkta, 100 gr Külçe Gümüş.",
                    Url = "100gr-külce-gümüs",
                    ImageUrl = "8.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 9,
                    Name = "250gr Külçe Gümüş",
                    Price = 112500,
                    Properties = "925 Saflıkta, 250 gr Külçe Gümüş.",
                    Url = "250gr-külce-gümüs",
                    ImageUrl = "9.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 10,
                    Name = "500gr Külçe Gümüş",
                    Price = 225000,
                    Properties = "925 Saflıkta, 500 gr Külçe Gümüş.",
                    Url = "500gr-külce-gümüs",
                    ImageUrl = "10.png",
                    IsHome = true
                }
                );
        }
    }
}
