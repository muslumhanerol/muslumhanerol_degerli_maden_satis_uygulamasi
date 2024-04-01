using DegerliMadenSatis.Entity.Concrete.identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DegerliMadenSatis.Data.Extensions
{
    public static class ModelBuilderExtensions //Rol, User bu user şu rolde demek için kullanacağız.
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            #region Rol Bilgileri

            List<Role> role = new List<Role>
            {
                new Role{Name="Admin", Description="Yönetiki haklarını taşıyan rol", NormalizedName="ADMIN"},
                new Role { Name = "Customer", Description = "Müşteri haklarını taşıyan rol", NormalizedName = "CUSTOMER" }
            };
            modelBuilder.Entity<Role>().HasData(role); //Entity içerisinden role geç hasdata yı kullanarak listedeki tanımlı rolleri ver.

            #endregion

            #region Kullanıcı Bilgileri
            List<User> users = new List<User>
            {
                new User //Örnek datamız.
                {
                    FirstName="Müslüm Han",
                    LastName="Erol",
                    UserName="muslumhanerol",
                    NormalizedUserName="MUSLUMHANEROL",
                    Email="mslmhanerol@gmail.com",
                    NormalizedEmail="MSLMHANEROL@GMAIL.COM",
                    Gender="Erkek",
                    DateOfBirth=new DateTime(1945,1,11),
                    Address="Gaziantep Caddesi Gaziantep Sokak No:27 D:27 Türkiye",
                    City="Gaziantep",
                    PhoneNumber="5554443322",
                    EmailConfirmed=true
                },
                 new User 
                {
                    FirstName="Engin",
                    LastName="Niyazi",
                    UserName="enginniyazi",
                    NormalizedUserName="ENGINNIYAZI",
                    Email="enginniyazi@gmail.com",
                    NormalizedEmail="ENGINNIYAZI@GMAIL.COM",
                    Gender="Erkek",
                    DateOfBirth=new DateTime(1965,7,20),
                    Address="Gaziantep Caddesi Gaziantep Sokak No:27 D:27 Türkiye",
                    City="Gaziantep",
                    PhoneNumber="5556667788",
                    EmailConfirmed=true
                },
            };
            #endregion
        }
    }
}
