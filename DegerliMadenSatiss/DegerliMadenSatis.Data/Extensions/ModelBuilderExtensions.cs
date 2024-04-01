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
    }
    }
}
