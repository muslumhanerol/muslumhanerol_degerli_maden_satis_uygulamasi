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
                    OrderNumber = table.Column<string>(type: "TEXT", nullable: true),
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
                    OrderState = table.Column<int>(type: "INTEGER", nullable: false),
                    ConversationId = table.Column<string>(type: "TEXT", nullable: true),
                    PaymentId = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "OrderDetails",
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
                    table.PrimaryKey("PK_OrderDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
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
                    { "1ac549b0-b552-4a08-8c56-956f700b6b17", null, "Süper yönetiki haklarını taşıyan rol", "SuperAdmin", "SUPERADMIN" },
                    { "cdd94ac9-223e-40a2-99c2-645a7717aa5d", null, "Yönetiki haklarını taşıyan rol", "Admin", "ADMIN" },
                    { "f27981d2-3b0b-4812-95da-cd7d66a50218", null, "Müşteri haklarını taşıyan rol", "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0c961e13-38dd-464c-b422-68c1f2c7506b", 0, "Matrix Caddesi Makine Sokak No:34 D:34 Türkiye", "Zion", "15e90d12-0d82-40a1-aea5-5976c3bd9f5d", new DateTime(1965, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "trinityneo@gmail.com", true, "Trinity", "Kadın", "Neo", false, null, "TRINITYNEO@GMAIL.COM", "TIRINITYNEO", "AQAAAAIAAYagAAAAEA+hWvNNyd3KMG/nL1TLA1GvKN21SO8oqYy1M1UnaDvxNSSKbtH7nCwPJCr60XXxug==", "5556667788", false, "2af999dd-5688-4be0-be2e-c96e4423bc38", false, "trinityneo" },
                    { "627ebc04-3cbd-400f-90d7-52835474f2ea", 0, "Avrupa Caddesi Saray Sokak No:34 D:34 Türkiye", "Ukrayna", "ea6eaa4b-aea5-46b5-9808-2e302ac03803", new DateTime(1965, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "hurremsultan@gmail.com", true, "Hürrem", "Kadın", "Sultan", false, null, "HURREMSULTAN@GMAIL.COM", "HURREMSULTAN", "AQAAAAIAAYagAAAAEERs+zjlJtznJRRDtd+kDolxcCHbvyewUP95f8CSJcFP0+4bucVopRngWLhpJjo5sQ==", "5556667788", false, "fd6d7dd1-c93f-4f37-b91a-0db4e3ec5355", false, "hurremsultan" },
                    { "797cafb9-b3d4-472d-b525-f6905a3bd865", 0, "Beşiktaş Caddesi Yıldız Sokak No:34 D:34 Türkiye", "İstanbul", "df397554-b3d6-4003-b456-e98d4641ff90", new DateTime(1965, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "enginniyazi@gmail.com", true, "Engin", "Erkek", "Niyazi", false, null, "ENGINNIYAZI@GMAIL.COM", "ENGINNIYAZI", "AQAAAAIAAYagAAAAEAlSSh4JRpeV5S2O7r/uzjSp136Gd5gswExrQlevE5r1RS6DbdocZurc5xM9Ka9Odw==", "5556667788", false, "69b8986d-d392-4340-86ec-319b09a50ab5", false, "enginniyazi" },
                    { "ab11da77-6433-4d37-bb39-6f24f7bc4029", 0, "Beyoğlu Caddesi Fatih Sokak No:34 D:34 Türkiye", "İstanbul", "0a89d7b6-5abd-419f-abf1-ecf39e91646e", new DateTime(1965, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "fatihsultan@gmail.com", true, "Fatih", "Erkek", "Sultan", false, null, "FATIHSULTAN@GMAIL.COM", "FATIHSULTAN", "AQAAAAIAAYagAAAAEMrvsZ2JLQXj4O4iiI3xbD29QkTP1801+yYRlWZPnPLbFe18CLBOzpu5KvtRkAs4Mw==", "5556667788", false, "f13f43c0-fbc3-4776-983b-1f50cfb453ed", false, "fatihsultan" },
                    { "cabef934-bcca-4ef9-b3e5-241753e45fe5", 0, "Gaziantep Caddesi Gaziantep Sokak No:27 D:27 Türkiye", "Gaziantep", "1fae714e-723a-4d7b-9a50-d43085220875", new DateTime(1945, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "mslmhanerol@gmail.com", true, "Müslüm Han", "Erkek", "Erol", false, null, "MSLMHANEROL@GMAIL.COM", "MUSLUMHANEROL", "AQAAAAIAAYagAAAAEC4tJwPBReDXqFBRmmASymwEgLso+VZiNUF7VluEyZLo2XJBfV1CEwEeZq9ycr/XVw==", "5554443322", false, "c3ef19bc-b10c-42f5-8ad3-f61729ea5b5f", false, "muslumhanerol" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "IsDeleted", "ModifiedDate", "Name", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 15, 20, 15, 34, 245, DateTimeKind.Local).AddTicks(1539), "Altın Kategorisi", true, false, new DateTime(2024, 4, 15, 20, 15, 34, 245, DateTimeKind.Local).AddTicks(1562), "Fiziki Altın", "fiziki-altin" },
                    { 2, new DateTime(2024, 4, 15, 20, 15, 34, 245, DateTimeKind.Local).AddTicks(1568), "Altın Kategorisi", true, false, new DateTime(2024, 4, 15, 20, 15, 34, 245, DateTimeKind.Local).AddTicks(1569), "Dijital Altın", "dijital-altin" },
                    { 3, new DateTime(2024, 4, 15, 20, 15, 34, 245, DateTimeKind.Local).AddTicks(1572), "Ziynet Kategorisi", true, false, new DateTime(2024, 4, 15, 20, 15, 34, 245, DateTimeKind.Local).AddTicks(1574), "Ziynet Altın", "ziynet-altin" },
                    { 4, new DateTime(2024, 4, 15, 20, 15, 34, 245, DateTimeKind.Local).AddTicks(1577), "Gümüş Kategorisi", true, false, new DateTime(2024, 4, 15, 20, 15, 34, 245, DateTimeKind.Local).AddTicks(1578), "Fiziki Gümüş", "fiziki-gümüs" },
                    { 5, new DateTime(2024, 4, 15, 20, 15, 34, 245, DateTimeKind.Local).AddTicks(1581), "Gümüş Kategorisi", true, false, new DateTime(2024, 4, 15, 20, 15, 34, 245, DateTimeKind.Local).AddTicks(1582), "Dijital Gümüş", "dijital-gümüs" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "ImageUrl", "IsActive", "IsDeleted", "IsHome", "ModifiedDate", "Name", "Price", "Properties", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 15, 20, 15, 34, 248, DateTimeKind.Local).AddTicks(306), "1.png", true, false, true, new DateTime(2024, 4, 15, 20, 15, 34, 248, DateTimeKind.Local).AddTicks(330), "5 Gr Külçe Altın", 14000m, "24 Ayar 995.0 Saflıkta, 5 Gr Külçe Altın.", "5-gr-külce-altin" },
                    { 2, new DateTime(2024, 4, 15, 20, 15, 34, 248, DateTimeKind.Local).AddTicks(346), "1.png", true, false, true, new DateTime(2024, 4, 15, 20, 15, 34, 248, DateTimeKind.Local).AddTicks(347), "10 Gr Külçe Altın", 28000m, "24 Ayar 995.0 Saflıkta, 10 Gr Külçe Altın.", "10-gr-külce-altin" },
                    { 3, new DateTime(2024, 4, 15, 20, 15, 34, 248, DateTimeKind.Local).AddTicks(352), "2.png", true, false, false, new DateTime(2024, 4, 15, 20, 15, 34, 248, DateTimeKind.Local).AddTicks(354), "20 Gr Külçe Altın", 56000m, "24 Ayar 995.0 Saflıkta, 20 Gr Külçe Altın.", "20-gr-külce-altin" },
                    { 4, new DateTime(2024, 4, 15, 20, 15, 34, 248, DateTimeKind.Local).AddTicks(358), "3.png", true, false, true, new DateTime(2024, 4, 15, 20, 15, 34, 248, DateTimeKind.Local).AddTicks(360), "50 Gr Külçe Altın", 140000m, "24 Ayar 995.0 Saflıkta, 50 Gr Külçe Altın.", "50-gr-külce-altin" },
                    { 5, new DateTime(2024, 4, 15, 20, 15, 34, 248, DateTimeKind.Local).AddTicks(364), "4.png", true, false, true, new DateTime(2024, 4, 15, 20, 15, 34, 248, DateTimeKind.Local).AddTicks(366), "100 Gr Külçe Altın", 280000m, "24 Ayar 995.0 Saflıkta, 100 Gr Külçe Altın.", "100-gr-külce-altin" },
                    { 6, new DateTime(2024, 4, 15, 20, 15, 34, 248, DateTimeKind.Local).AddTicks(369), "5.png", true, false, true, new DateTime(2024, 4, 15, 20, 15, 34, 248, DateTimeKind.Local).AddTicks(370), "250 Gr Külçe Altın", 7000000m, "24 Ayar 995.0 Saflıkta, 250 Gr Külçe Altın.", "250-gr-külce-altin" },
                    { 7, new DateTime(2024, 4, 15, 20, 15, 34, 248, DateTimeKind.Local).AddTicks(374), "6.png", true, false, false, new DateTime(2024, 4, 15, 20, 15, 34, 248, DateTimeKind.Local).AddTicks(375), "500 Gr Külçe Altın", 1400000m, "24 Ayar 995.0 Saflıkta, 500 Gr Külçe Altın.", "500-gr-külce-altin" },
                    { 8, new DateTime(2024, 4, 15, 20, 15, 34, 248, DateTimeKind.Local).AddTicks(379), "7.png", true, false, true, new DateTime(2024, 4, 15, 20, 15, 34, 248, DateTimeKind.Local).AddTicks(394), "1000 Gr Külçe Altın", 2800000m, "24 Ayar 995.0 Saflıkta, 500 Gr Külçe Altın.", "1000-gr-külce-altin" },
                    { 9, new DateTime(2024, 4, 15, 20, 15, 34, 248, DateTimeKind.Local).AddTicks(423), "8.png", true, false, false, new DateTime(2024, 4, 15, 20, 15, 34, 248, DateTimeKind.Local).AddTicks(425), "Çeyrek Altın", 4750m, "22 Ayar 916.0 Saflıkta, 1.75 Gr Çeyrek Altın.", "ceyrek-altin" },
                    { 10, new DateTime(2024, 4, 15, 20, 15, 34, 248, DateTimeKind.Local).AddTicks(429), "9.png", true, false, true, new DateTime(2024, 4, 15, 20, 15, 34, 248, DateTimeKind.Local).AddTicks(430), "Yarım", 9500m, "22 Ayar 916.0 Saflıkta, 3.50 Gr Yarım Altın.", "yarim-altin" },
                    { 11, new DateTime(2024, 4, 15, 20, 15, 34, 248, DateTimeKind.Local).AddTicks(434), "10.png", true, false, true, new DateTime(2024, 4, 15, 20, 15, 34, 248, DateTimeKind.Local).AddTicks(435), "Tam Altın", 19000m, "22 Ayar 916.0 Saflıkta, 7 Gr Tam Altın.", "tam-altin" },
                    { 12, new DateTime(2024, 4, 15, 20, 15, 34, 248, DateTimeKind.Local).AddTicks(439), "12.png", true, false, true, new DateTime(2024, 4, 15, 20, 15, 34, 248, DateTimeKind.Local).AddTicks(441), "100gr Külçe Gümüş", 3850m, "999.0 Saflıkta, 100 Gr Külçe Gümüş.", "100gr-külce-gümüs" },
                    { 13, new DateTime(2024, 4, 15, 20, 15, 34, 248, DateTimeKind.Local).AddTicks(445), "13.png", true, false, true, new DateTime(2024, 4, 15, 20, 15, 34, 248, DateTimeKind.Local).AddTicks(446), "250gr Külçe Gümüş", 8750m, "999.0 Saflıkta, 250 Gr Külçe Gümüş.", "250gr-külce-gümüs" },
                    { 14, new DateTime(2024, 4, 15, 20, 15, 34, 248, DateTimeKind.Local).AddTicks(450), "14.png", true, false, true, new DateTime(2024, 4, 15, 20, 15, 34, 248, DateTimeKind.Local).AddTicks(451), "500gr Külçe Gümüş", 17500m, "999.0 Saflıkta, 500 Gr Külçe Gümüş.", "500gr-külce-gümüs" },
                    { 15, new DateTime(2024, 4, 15, 20, 15, 34, 248, DateTimeKind.Local).AddTicks(455), "15.png", true, false, true, new DateTime(2024, 4, 15, 20, 15, 34, 248, DateTimeKind.Local).AddTicks(456), "1000gr Külçe Gümüş", 34000m, "999.0 Saflıkta, 1000 Gr Külçe Gümüş.", "1000gr-külce-gümüs" }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCarts",
                columns: new[] { "Id", "CreatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 15, 20, 15, 34, 243, DateTimeKind.Local).AddTicks(5870), "cabef934-bcca-4ef9-b3e5-241753e45fe5" },
                    { 2, new DateTime(2024, 4, 15, 20, 15, 34, 243, DateTimeKind.Local).AddTicks(5915), "797cafb9-b3d4-472d-b525-f6905a3bd865" },
                    { 3, new DateTime(2024, 4, 15, 20, 15, 34, 243, DateTimeKind.Local).AddTicks(5920), "ab11da77-6433-4d37-bb39-6f24f7bc4029" },
                    { 4, new DateTime(2024, 4, 15, 20, 15, 34, 243, DateTimeKind.Local).AddTicks(5924), "627ebc04-3cbd-400f-90d7-52835474f2ea" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "cdd94ac9-223e-40a2-99c2-645a7717aa5d", "0c961e13-38dd-464c-b422-68c1f2c7506b" },
                    { "f27981d2-3b0b-4812-95da-cd7d66a50218", "627ebc04-3cbd-400f-90d7-52835474f2ea" },
                    { "cdd94ac9-223e-40a2-99c2-645a7717aa5d", "797cafb9-b3d4-472d-b525-f6905a3bd865" },
                    { "cdd94ac9-223e-40a2-99c2-645a7717aa5d", "ab11da77-6433-4d37-bb39-6f24f7bc4029" },
                    { "1ac549b0-b552-4a08-8c56-956f700b6b17", "cabef934-bcca-4ef9-b3e5-241753e45fe5" }
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
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");

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
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "ShoppingCartItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ShoppingCarts");
        }
    }
}
