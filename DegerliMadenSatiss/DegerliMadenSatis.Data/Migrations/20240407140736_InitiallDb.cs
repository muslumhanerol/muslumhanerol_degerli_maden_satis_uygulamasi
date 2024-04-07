using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DegerliMadenSatis.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitiallDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    City = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Note = table.Column<string>(type: "TEXT", nullable: true),
                    PaymentType = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderState = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "date('now')"),
                    Price = table.Column<decimal>(type: "real", nullable: false),
                    Properties = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    IsHome = table.Column<bool>(type: "INTEGER", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "date('now')"),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCarts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ProductCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItem_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItem_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    ShoppingCartId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShoppingCartItems_ShoppingCarts_ShoppingCartId",
                        column: x => x.ShoppingCartId,
                        principalTable: "ShoppingCarts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "638ec27a-6707-4b63-8cb8-7f11b259b6fd", null, "Müşteri haklarını taşıyan rol", "Customer", "CUSTOMER" },
                    { "6c539cef-1b42-4a39-9324-601ec734a71a", null, "Yönetiki haklarını taşıyan rol", "Admin", "ADMIN" },
                    { "906ecd91-be44-4027-8ac0-c8ef1d1925e0", null, "Süper yönetiki haklarını taşıyan rol", "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "29eee199-1608-4618-a182-886a17a826f2", 0, "Gaziantep Caddesi Gaziantep Sokak No:27 D:27 Türkiye", "Gaziantep", "6ae3cf8e-3081-48d5-96d2-3b77bceea1e5", new DateTime(1965, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "kemaldurukan@gmail.com", true, "Kemal", "Erkek", "Durukan", false, null, "KEMALDURUKAN@GMAIL.COM", "KEMALDURUKAN", "AQAAAAIAAYagAAAAEFxLN8i/D15Fvs4ydblu+n1AHoMEp0wQ79WeByuP6xUae8FgYCfhxz3c7NXw2DENyw==", "5556667788", false, "320c317f-347f-4cfc-a098-feb61d0d9d8c", false, "kemaldurukan" },
                    { "9aecffd8-a93e-4c40-9a5f-d76bd3987a29", 0, "Gaziantep Caddesi Gaziantep Sokak No:27 D:27 Türkiye", "Gaziantep", "faa1680b-e849-416b-8c2b-e90bad872cc9", new DateTime(1945, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "mslmhanerol@gmail.com", true, "Müslüm Han", "Erkek", "Erol", false, null, "MSLMHANEROL@GMAIL.COM", "MUSLUMHANEROL", "AQAAAAIAAYagAAAAEB9DMssAJVIf+f0eaL/cNPcZorF9JJDlSzABcOV2U6F+OR9k2QdNJf5lR43dU5Jl7A==", "5554443322", false, "2ca80b44-3b42-4cba-b6fd-d0e1ff76a1a7", false, "muslumhanerol" },
                    { "e197c489-9720-4b66-845d-8b3e6fac3945", 0, "Gaziantep Caddesi Gaziantep Sokak No:27 D:27 Türkiye", "Gaziantep", "cb4004c6-ff41-4fba-a1fb-161fe1d1eff2", new DateTime(1965, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "aysenumay@gmail.com", true, "Ayşen Umay", "Kadın", "Ergül", false, null, "AYSENUMAY@GMAIL.COM", "AYSENUMAY", "AQAAAAIAAYagAAAAELxRbkG/Gw7eFZgvl9VdXrcM8PyoQ3NPLETmTLVKVvmvf7/zRAHaRXDx2CIfeKWQUg==", "5556667788", false, "18a99bb6-f376-4e5a-9eda-de698b754f85", false, "aysenumay" },
                    { "f968a9aa-d010-467a-a096-5f5ccc6f335c", 0, "Gaziantep Caddesi Gaziantep Sokak No:27 D:27 Türkiye", "Gaziantep", "8a70818b-a6a5-415d-9b86-0cc2f0a51283", new DateTime(1965, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "enginniyazi@gmail.com", true, "Engin", "Erkek", "Niyazi", false, null, "ENGINNIYAZI@GMAIL.COM", "ENGINNIYAZI", "AQAAAAIAAYagAAAAEOrE7UpX4WZeUKR8E2OPxFkiLEDdW+cjsD5s24FBsPAfK1PKteHGfmrAOCJ6RTyrhw==", "5556667788", false, "ab71bf80-4fb0-415e-aeea-8b19327088c2", false, "enginniyazi" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "IsDeleted", "ModifiedDate", "Name", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 7, 17, 7, 36, 22, DateTimeKind.Local).AddTicks(6850), "Altın Kategorisi", true, false, new DateTime(2024, 4, 7, 17, 7, 36, 22, DateTimeKind.Local).AddTicks(6871), "Fiziki Altın", "fiziki-altin" },
                    { 2, new DateTime(2024, 4, 7, 17, 7, 36, 22, DateTimeKind.Local).AddTicks(6878), "Altın Kategorisi", true, false, new DateTime(2024, 4, 7, 17, 7, 36, 22, DateTimeKind.Local).AddTicks(6879), "Dijital Altın", "dijital-altin" },
                    { 3, new DateTime(2024, 4, 7, 17, 7, 36, 22, DateTimeKind.Local).AddTicks(6882), "Ziynet Kategorisi", true, false, new DateTime(2024, 4, 7, 17, 7, 36, 22, DateTimeKind.Local).AddTicks(6883), "Ziynet Altın", "ziynet-altin" },
                    { 4, new DateTime(2024, 4, 7, 17, 7, 36, 22, DateTimeKind.Local).AddTicks(6886), "Gümüş Kategorisi", true, false, new DateTime(2024, 4, 7, 17, 7, 36, 22, DateTimeKind.Local).AddTicks(6887), "Fiziki Gümüş", "fiziki-gümüs" },
                    { 5, new DateTime(2024, 4, 7, 17, 7, 36, 22, DateTimeKind.Local).AddTicks(6890), "Gümüş Kategorisi", true, false, new DateTime(2024, 4, 7, 17, 7, 36, 22, DateTimeKind.Local).AddTicks(6891), "Dijital Gümüş", "dijital-gümüs" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "ImageUrl", "IsActive", "IsDeleted", "IsHome", "ModifiedDate", "Name", "Price", "Properties", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 7, 17, 7, 36, 26, DateTimeKind.Local).AddTicks(1240), "1.png", true, false, true, new DateTime(2024, 4, 7, 17, 7, 36, 26, DateTimeKind.Local).AddTicks(1265), "5 Gr Külçe Altın", 13500m, "24 Ayar 995.0 Saflıkta, 5 Gr Külçe Altın.", "5-gr-külce-altin" },
                    { 2, new DateTime(2024, 4, 7, 17, 7, 36, 26, DateTimeKind.Local).AddTicks(1281), "1.png", true, false, true, new DateTime(2024, 4, 7, 17, 7, 36, 26, DateTimeKind.Local).AddTicks(1282), "10 Gr Külçe Altın", 27000m, "24 Ayar 995.0 Saflıkta, 10 Gr Külçe Altın.", "10-gr-külce-altin" },
                    { 3, new DateTime(2024, 4, 7, 17, 7, 36, 26, DateTimeKind.Local).AddTicks(1287), "2.png", true, false, false, new DateTime(2024, 4, 7, 17, 7, 36, 26, DateTimeKind.Local).AddTicks(1288), "20 Gr Külçe Altın", 54000m, "24 Ayar 995.0 Saflıkta, 20 Gr Külçe Altın.", "20-gr-külce-altin" },
                    { 4, new DateTime(2024, 4, 7, 17, 7, 36, 26, DateTimeKind.Local).AddTicks(1292), "3.png", true, false, true, new DateTime(2024, 4, 7, 17, 7, 36, 26, DateTimeKind.Local).AddTicks(1294), "50 Gr Külçe Altın", 135000m, "24 Ayar 995.0 Saflıkta, 50 Gr Külçe Altın.", "50-gr-külce-altin" },
                    { 5, new DateTime(2024, 4, 7, 17, 7, 36, 26, DateTimeKind.Local).AddTicks(1299), "4.png", true, false, true, new DateTime(2024, 4, 7, 17, 7, 36, 26, DateTimeKind.Local).AddTicks(1300), "100 Gr Külçe Altın", 270000m, "24 Ayar 995.0 Saflıkta, 100 Gr Külçe Altın.", "100-gr-külce-altin" },
                    { 6, new DateTime(2024, 4, 7, 17, 7, 36, 26, DateTimeKind.Local).AddTicks(1304), "5.png", true, false, true, new DateTime(2024, 4, 7, 17, 7, 36, 26, DateTimeKind.Local).AddTicks(1305), "250 Gr Külçe Altın", 680000m, "24 Ayar 995.0 Saflıkta, 250 Gr Külçe Altın.", "250-gr-külce-altin" },
                    { 7, new DateTime(2024, 4, 7, 17, 7, 36, 26, DateTimeKind.Local).AddTicks(1310), "6.png", true, false, false, new DateTime(2024, 4, 7, 17, 7, 36, 26, DateTimeKind.Local).AddTicks(1311), "500 Gr Külçe Altın", 1350000m, "24 Ayar 995.0 Saflıkta, 500 Gr Külçe Altın.", "500-gr-külce-altin" },
                    { 8, new DateTime(2024, 4, 7, 17, 7, 36, 26, DateTimeKind.Local).AddTicks(1315), "7.png", true, false, true, new DateTime(2024, 4, 7, 17, 7, 36, 26, DateTimeKind.Local).AddTicks(1338), "1000 Gr Külçe Altın", 270000m, "24 Ayar 995.0 Saflıkta, 500 Gr Külçe Altın.", "1000-gr-külce-altin" },
                    { 9, new DateTime(2024, 4, 7, 17, 7, 36, 26, DateTimeKind.Local).AddTicks(1372), "8.png", true, false, false, new DateTime(2024, 4, 7, 17, 7, 36, 26, DateTimeKind.Local).AddTicks(1375), "Çeyrek Altın", 4700m, "22 Ayar 916.0 Saflıkta, 1.75 Gr Çeyrek Altın.", "ceyrek-altin" },
                    { 10, new DateTime(2024, 4, 7, 17, 7, 36, 26, DateTimeKind.Local).AddTicks(1379), "9.png", true, false, true, new DateTime(2024, 4, 7, 17, 7, 36, 26, DateTimeKind.Local).AddTicks(1380), "Yarım", 1250m, "22 Ayar 916.0 Saflıkta, 3.50 Gr Yarım Altın.", "yarim-altin" },
                    { 11, new DateTime(2024, 4, 7, 17, 7, 36, 26, DateTimeKind.Local).AddTicks(1384), "10.png", true, false, true, new DateTime(2024, 4, 7, 17, 7, 36, 26, DateTimeKind.Local).AddTicks(1386), "Tam Altın", 2100m, "22 Ayar 916.0 Saflıkta, 7 Gr Tam Altın.", "tam-altin" },
                    { 12, new DateTime(2024, 4, 7, 17, 7, 36, 26, DateTimeKind.Local).AddTicks(1390), "12.png", true, false, true, new DateTime(2024, 4, 7, 17, 7, 36, 26, DateTimeKind.Local).AddTicks(1393), "100gr Külçe Gümüş", 3500m, "999.0 Saflıkta, 100 Gr Külçe Gümüş.", "100gr-külce-gümüs" },
                    { 13, new DateTime(2024, 4, 7, 17, 7, 36, 26, DateTimeKind.Local).AddTicks(1399), "13.png", true, false, true, new DateTime(2024, 4, 7, 17, 7, 36, 26, DateTimeKind.Local).AddTicks(1400), "250gr Külçe Gümüş", 8000m, "999.0 Saflıkta, 250 Gr Külçe Gümüş.", "250gr-külce-gümüs" },
                    { 14, new DateTime(2024, 4, 7, 17, 7, 36, 26, DateTimeKind.Local).AddTicks(1404), "14.png", true, false, true, new DateTime(2024, 4, 7, 17, 7, 36, 26, DateTimeKind.Local).AddTicks(1405), "500gr Külçe Gümüş", 16000m, "999.0 Saflıkta, 500 Gr Külçe Gümüş.", "500gr-külce-gümüs" },
                    { 15, new DateTime(2024, 4, 7, 17, 7, 36, 26, DateTimeKind.Local).AddTicks(1410), "15.png", true, false, true, new DateTime(2024, 4, 7, 17, 7, 36, 26, DateTimeKind.Local).AddTicks(1411), "1000gr Külçe Gümüş", 32000m, "999.0 Saflıkta, 1000 Gr Külçe Gümüş.", "1000gr-külce-gümüs" }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCarts",
                columns: new[] { "Id", "CreatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 7, 17, 7, 36, 20, DateTimeKind.Local).AddTicks(5516), "9aecffd8-a93e-4c40-9a5f-d76bd3987a29" },
                    { 2, new DateTime(2024, 4, 7, 17, 7, 36, 20, DateTimeKind.Local).AddTicks(5551), "f968a9aa-d010-467a-a096-5f5ccc6f335c" },
                    { 3, new DateTime(2024, 4, 7, 17, 7, 36, 20, DateTimeKind.Local).AddTicks(5554), "29eee199-1608-4618-a182-886a17a826f2" },
                    { 4, new DateTime(2024, 4, 7, 17, 7, 36, 20, DateTimeKind.Local).AddTicks(5557), "e197c489-9720-4b66-845d-8b3e6fac3945" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "6c539cef-1b42-4a39-9324-601ec734a71a", "29eee199-1608-4618-a182-886a17a826f2" },
                    { "906ecd91-be44-4027-8ac0-c8ef1d1925e0", "9aecffd8-a93e-4c40-9a5f-d76bd3987a29" },
                    { "638ec27a-6707-4b63-8cb8-7f11b259b6fd", "e197c489-9720-4b66-845d-8b3e6fac3945" },
                    { "6c539cef-1b42-4a39-9324-601ec734a71a", "f968a9aa-d010-467a-a096-5f5ccc6f335c" }
                });

            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 1, 4 },
                    { 2, 4 },
                    { 1, 5 },
                    { 2, 5 },
                    { 1, 6 },
                    { 2, 6 },
                    { 1, 7 },
                    { 2, 7 },
                    { 1, 8 },
                    { 2, 8 },
                    { 3, 9 },
                    { 3, 10 },
                    { 3, 11 },
                    { 4, 12 },
                    { 5, 12 },
                    { 4, 13 },
                    { 5, 13 },
                    { 4, 14 },
                    { 5, 14 },
                    { 4, 15 },
                    { 5, 15 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_OrderId",
                table: "ShoppingCartItem",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItem_ProductId",
                table: "ShoppingCartItem",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ProductId",
                table: "ShoppingCartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCartItems_ShoppingCartId",
                table: "ShoppingCartItems",
                column: "ShoppingCartId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "ShoppingCartItem");

            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");
        }
    }
}
