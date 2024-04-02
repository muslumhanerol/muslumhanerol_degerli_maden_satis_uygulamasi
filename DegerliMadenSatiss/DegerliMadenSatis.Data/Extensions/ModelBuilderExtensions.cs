using DegerliMadenSatis.Entity.Concrete;
using DegerliMadenSatis.Entity.Concrete.identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace DegerliMadenSatis.Data.Extensions
{
    public static class ModelBuilderExtensions //Rol, User bu user şu rolde demek için kullanacağız.
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            #region Rol Bilgileri

            List<Role> roles = new List<Role>
            {
                new Role{Name="SuperAdmin", Description="Süper yönetiki haklarını taşıyan rol", NormalizedName="SUPERADMIN"},
                new Role{Name="Admin", Description="Yönetiki haklarını taşıyan rol", NormalizedName="ADMIN"},
                new Role { Name = "Customer", Description = "Müşteri haklarını taşıyan rol", NormalizedName = "CUSTOMER" }
            };
            modelBuilder.Entity<Role>().HasData(roles); //Entity içerisinden role geç hasdata yı kullanarak listedeki tanımlı rolleri ver.

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
                   new User
                {
                    FirstName="Kemal",
                    LastName="Durukan",
                    UserName="kemaldurukan",
                    NormalizedUserName="KEMALDURUKAN",
                    Email="kemaldurukan@gmail.com",
                    NormalizedEmail="KEMALDURUKAN@GMAIL.COM",
                    Gender="Erkek",
                    DateOfBirth=new DateTime(1965,7,20),
                    Address="Gaziantep Caddesi Gaziantep Sokak No:27 D:27 Türkiye",
                    City="Gaziantep",
                    PhoneNumber="5556667788",
                    EmailConfirmed=true
                },
                     new User
                {
                    FirstName="Ayşen Umay",
                    LastName="Ergül",
                    UserName="aysenumay",
                    NormalizedUserName="AYSENUMAY",
                    Email="aysenumay@gmail.com",
                    NormalizedEmail="AYSENUMAY@GMAIL.COM",
                    Gender="Kadın",
                    DateOfBirth=new DateTime(1965,7,20),
                    Address="Gaziantep Caddesi Gaziantep Sokak No:27 D:27 Türkiye",
                    City="Gaziantep",
                    PhoneNumber="5556667788",
                    EmailConfirmed=true
                }
            };
            modelBuilder.Entity<User>().HasData(users);
            #endregion

            #region Şifre İşlemleri

            var passwordHasher = new PasswordHasher<User>();
            users[0].PasswordHash = passwordHasher.HashPassword(users[0], "Qwe123.");
            users[1].PasswordHash = passwordHasher.HashPassword(users[1], "Qwe123.");
            users[2].PasswordHash = passwordHasher.HashPassword(users[2], "Qwe123.");
            users[3].PasswordHash = passwordHasher.HashPassword(users[3], "Qwe123.");


            #endregion

            #region Rol Atama İşlemleri

            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                    UserId=users[0].Id,
                    RoleId=roles[0].Id //1. yöntem
                    //RoleId=roles.Where(x=>x.Name=="Admin").FirstOrDefault().Id 2.yöntem
                },
                new IdentityUserRole<string>
                {
                  UserId=users[1].Id,
                  RoleId=roles[1].Id //1. yöntem
                },                
                new IdentityUserRole<string>
                {
                  UserId=users[2].Id,
                  RoleId=roles[1].Id //1. yöntem
                }
                 ,
                new IdentityUserRole<string>
                {
                  UserId=users[3].Id,
                  RoleId=roles[2].Id //1. yöntem
                }
            };
            modelBuilder.Entity<IdentityUser<string>>().HasData(userRoles);

            #endregion

            #region Alışveriş Sepeti İşlemleri

            List<ShoppingCart> shoppingCarts = new List<ShoppingCart>
            {
                new ShoppingCart {Id=1, UserId=users[0].Id},
                new ShoppingCart {Id=2, UserId=users[1].Id},
                new ShoppingCart {Id=3, UserId=users[2].Id},
                new ShoppingCart {Id=4, UserId=users[3].Id}
            };
            modelBuilder.Entity<ShoppingCart>().HasData(shoppingCarts);

            #endregion

        }
    }
}
