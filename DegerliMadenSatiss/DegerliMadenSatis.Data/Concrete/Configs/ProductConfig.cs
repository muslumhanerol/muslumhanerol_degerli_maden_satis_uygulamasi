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
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id); //Productların Id alanı primary key olacak.
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.Property(p=>p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p=>p.Properties).IsRequired().HasMaxLength(500);
            builder.Property(p=>p.Url).IsRequired().HasMaxLength(100);
            builder.Property(p=>p.ImageUrl).IsRequired().HasMaxLength(500);
            builder.Property(p => p.Price).IsRequired().HasColumnType("real"); //Sqlite için
            //builder.Property(p => p.CreatedDate).HasDefaultValueSql("getdate()"); //SqlServer için
            builder.Property(p => p.CreatedDate).HasDefaultValueSql("date('now')"); //Sqlite için
            builder.Property(p => p.ModifiedDate).HasDefaultValueSql("date('now')"); //Sqlite için
            builder.ToTable("Products"); //Tablo isminin belirlenmei
            builder.HasData(
                new Product
                {
                    Id = 1,
                    Name = "5 Gr Külçe Altın",
                    Price = 13500,
                    Properties = "24 Ayar 995.0 Saflıkta, 5 Gr Külçe Altın.",
                    Url = "5-gr-külce-altin",
                    ImageUrl = "1.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 2,
                    Name = "10 Gr Külçe Altın",
                    Price = 27000,
                    Properties = "24 Ayar 995.0 Saflıkta, 10 Gr Külçe Altın.",
                    Url = "10-gr-külce-altin",
                    ImageUrl = "1.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 3,
                    Name = "20 Gr Külçe Altın",
                    Price = 54000,
                    Properties = "24 Ayar 995.0 Saflıkta, 20 Gr Külçe Altın.",
                    Url = "20-gr-külce-altin",
                    ImageUrl = "2.png",
                    IsHome = false
                },
                new Product
                {
                    Id = 4,
                    Name = "50 Gr Külçe Altın",
                    Price = 135000,
                    Properties = "24 Ayar 995.0 Saflıkta, 50 Gr Külçe Altın.",
                    Url = "50-gr-külce-altin",
                    ImageUrl = "3.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 5,
                    Name = "100 Gr Külçe Altın",
                    Price = 270000,
                    Properties = "24 Ayar 995.0 Saflıkta, 100 Gr Külçe Altın.",
                    Url = "100-gr-külce-altin",
                    ImageUrl = "4.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 6,
                    Name = "250 Gr Külçe Altın",
                    Price = 680000,
                    Properties = "24 Ayar 995.0 Saflıkta, 250 Gr Külçe Altın.",
                    Url = "250-gr-külce-altin",
                    ImageUrl = "5.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 7,
                    Name = "500 Gr Külçe Altın",
                    Price = 1350000,
                    Properties = "24 Ayar 995.0 Saflıkta, 500 Gr Külçe Altın.",
                    Url = "500-gr-külce-altin",
                    ImageUrl = "6.png",
                    IsHome = false
                },
                new Product
                {
                    Id = 8,
                    Name = "1000 Gr Külçe Altın",
                    Price = 270000,
                    Properties = "24 Ayar 995.0 Saflıkta, 500 Gr Külçe Altın.",
                    Url = "1000-gr-külce-altin",
                    ImageUrl = "7.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 9,
                    Name = "Çeyrek Altın",
                    Price = 4700,
                    Properties = "22 Ayar 916.0 Saflıkta, 1.75 Gr Çeyrek Altın.",
                    Url = "ceyrek-altin",
                    ImageUrl = "8.png",
                    IsHome = false
                },
                new Product
                {
                    Id = 10,
                    Name = "Yarım",
                    Price = 1250,
                    Properties = "22 Ayar 916.0 Saflıkta, 3.50 Gr Yarım Altın.",
                    Url = "yarim-altin",
                    ImageUrl = "9.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 11,
                    Name = "Tam Altın",
                    Price = 2100,
                    Properties = "22 Ayar 916.0 Saflıkta, 7 Gr Tam Altın.",
                    Url = "tam-altin",
                    ImageUrl = "10.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 12,
                    Name = "100gr Külçe Gümüş",
                    Price = 3500,
                    Properties = "999.0 Saflıkta, 100 Gr Külçe Gümüş.",
                    Url = "100gr-külce-gümüs",
                    ImageUrl = "12.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 13,
                    Name = "250gr Külçe Gümüş",
                    Price = 8000,
                    Properties = "999.0 Saflıkta, 250 Gr Külçe Gümüş.",
                    Url = "250gr-külce-gümüs",
                    ImageUrl = "13.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 14,
                    Name = "500gr Külçe Gümüş",
                    Price = 16000,
                    Properties = "999.0 Saflıkta, 500 Gr Külçe Gümüş.",
                    Url = "500gr-külce-gümüs",
                    ImageUrl = "14.png",
                    IsHome = true
                },
                new Product
                {
                    Id = 15,
                    Name = "1000gr Külçe Gümüş",
                    Price = 32000,
                    Properties = "999.0 Saflıkta, 1000 Gr Külçe Gümüş.",
                    Url = "1000gr-külce-gümüs",
                    ImageUrl = "15.png",
                    IsHome = true
                });
        }
    }
}
