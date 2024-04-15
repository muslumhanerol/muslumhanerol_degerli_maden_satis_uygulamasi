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
                    { "4ea9ddb3-2d04-4fba-bb1e-8f1126670ff7", null, "Yönetiki haklarını taşıyan rol", "Admin", "ADMIN" },
                    { "b0bdfef0-fd00-4f68-a44a-4c3afb5a7ea8", null, "Müşteri haklarını taşıyan rol", "Customer", "CUSTOMER" },
                    { "e4e7c8bd-9fe2-49ca-a5aa-d285da379844", null, "Süper yönetiki haklarını taşıyan rol", "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "Gender", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1c10e730-1401-48cb-8146-5a06943c6ca4", 0, "Gaziantep Caddesi Gaziantep Sokak No:27 D:27 Türkiye", "Gaziantep", "597ffe7b-919c-41f6-af7d-4f8fc8b5da1d", new DateTime(1965, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "aysenumay@gmail.com", true, "Ayşen Umay", "Kadın", "Ergül", false, null, "AYSENUMAY@GMAIL.COM", "AYSENUMAY", "AQAAAAIAAYagAAAAENqhST694kGZBvc9xQVDLwcuK/jli75U9Dn5sej2R5n+xQO1Z+jGW0KzGOM9R0Waog==", "5556667788", false, "bbc9cdd0-0d0d-4eec-8122-16cec7191973", false, "aysenumay" },
                    { "b0279cd1-7ddb-4ce0-acc2-4ec4db9c317d", 0, "Gaziantep Caddesi Gaziantep Sokak No:27 D:27 Türkiye", "Gaziantep", "1f89f2f5-dc25-40e3-be2f-9231ca5935cf", new DateTime(1965, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "kemaldurukan@gmail.com", true, "Kemal", "Erkek", "Durukan", false, null, "KEMALDURUKAN@GMAIL.COM", "KEMALDURUKAN", "AQAAAAIAAYagAAAAEPIT6mjcBt5xDLQo5VRiTf207i6ipLjK0C4+TjxoN/B3XaT1cA3TF+qh/D0NpqRqQQ==", "5556667788", false, "705d33b0-c3e3-41bd-a1dd-3b22fc0e7974", false, "kemaldurukan" },
                    { "ddf64ab8-e830-42c1-a048-4b3d33afaae3", 0, "Gaziantep Caddesi Gaziantep Sokak No:27 D:27 Türkiye", "Gaziantep", "a2e8636e-399f-4ca1-92f9-6bc3f04ab5dc", new DateTime(1945, 1, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "mslmhanerol@gmail.com", true, "Müslüm Han", "Erkek", "Erol", false, null, "MSLMHANEROL@GMAIL.COM", "MUSLUMHANEROL", "AQAAAAIAAYagAAAAEDm7Cryr5jdBM2OkWcIguWdp0RDTChdnzsuNMKILbY2Wb3S0qYH/zOd3SxwmnmNONA==", "5554443322", false, "902c6265-f78b-4d57-9dab-f629bacab736", false, "muslumhanerol" },
                    { "e4e3921b-4696-441c-8c13-b25d93cfb032", 0, "Gaziantep Caddesi Gaziantep Sokak No:27 D:27 Türkiye", "Gaziantep", "af729af5-6fde-49fb-97c3-cd17e4948e6e", new DateTime(1965, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "enginniyazi@gmail.com", true, "Engin", "Erkek", "Niyazi", false, null, "ENGINNIYAZI@GMAIL.COM", "ENGINNIYAZI", "AQAAAAIAAYagAAAAEGBO052SmoAtO3r9F0Oq0OmahOhYSVgGB2o8vj4IY9Eoe3jkzcwbhRuB7/6BZhNqmg==", "5556667788", false, "7daf650b-6478-4681-b566-891eeba5b0fb", false, "enginniyazi" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "IsDeleted", "ModifiedDate", "Name", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 15, 16, 12, 37, 324, DateTimeKind.Local).AddTicks(7794), "Altın Kategorisi", true, false, new DateTime(2024, 4, 15, 16, 12, 37, 324, DateTimeKind.Local).AddTicks(7813), "Fiziki Altın", "fiziki-altin" },
                    { 2, new DateTime(2024, 4, 15, 16, 12, 37, 324, DateTimeKind.Local).AddTicks(7823), "Altın Kategorisi", true, false, new DateTime(2024, 4, 15, 16, 12, 37, 324, DateTimeKind.Local).AddTicks(7824), "Dijital Altın", "dijital-altin" },
                    { 3, new DateTime(2024, 4, 15, 16, 12, 37, 324, DateTimeKind.Local).AddTicks(7827), "Ziynet Kategorisi", true, false, new DateTime(2024, 4, 15, 16, 12, 37, 324, DateTimeKind.Local).AddTicks(7827), "Ziynet Altın", "ziynet-altin" },
                    { 4, new DateTime(2024, 4, 15, 16, 12, 37, 324, DateTimeKind.Local).AddTicks(7830), "Gümüş Kategorisi", true, false, new DateTime(2024, 4, 15, 16, 12, 37, 324, DateTimeKind.Local).AddTicks(7831), "Fiziki Gümüş", "fiziki-gümüs" },
                    { 5, new DateTime(2024, 4, 15, 16, 12, 37, 324, DateTimeKind.Local).AddTicks(7833), "Gümüş Kategorisi", true, false, new DateTime(2024, 4, 15, 16, 12, 37, 324, DateTimeKind.Local).AddTicks(7834), "Dijital Gümüş", "dijital-gümüs" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "ImageUrl", "IsActive", "IsDeleted", "IsHome", "ModifiedDate", "Name", "Price", "Properties", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 15, 16, 12, 37, 326, DateTimeKind.Local).AddTicks(4036), "1.png", true, false, true, new DateTime(2024, 4, 15, 16, 12, 37, 326, DateTimeKind.Local).AddTicks(4056), "5 Gr Külçe Altın", 14000m, "24 Ayar 995.0 Saflıkta, 5 Gr Külçe Altın.", "5-gr-külce-altin" },
                    { 2, new DateTime(2024, 4, 15, 16, 12, 37, 326, DateTimeKind.Local).AddTicks(4067), "1.png", true, false, true, new DateTime(2024, 4, 15, 16, 12, 37, 326, DateTimeKind.Local).AddTicks(4068), "10 Gr Külçe Altın", 28000m, "24 Ayar 995.0 Saflıkta, 10 Gr Külçe Altın.", "10-gr-külce-altin" },
                    { 3, new DateTime(2024, 4, 15, 16, 12, 37, 326, DateTimeKind.Local).AddTicks(4071), "2.png", true, false, false, new DateTime(2024, 4, 15, 16, 12, 37, 326, DateTimeKind.Local).AddTicks(4072), "20 Gr Külçe Altın", 56000m, "24 Ayar 995.0 Saflıkta, 20 Gr Külçe Altın.", "20-gr-külce-altin" },
                    { 4, new DateTime(2024, 4, 15, 16, 12, 37, 326, DateTimeKind.Local).AddTicks(4077), "3.png", true, false, true, new DateTime(2024, 4, 15, 16, 12, 37, 326, DateTimeKind.Local).AddTicks(4078), "50 Gr Külçe Altın", 140000m, "24 Ayar 995.0 Saflıkta, 50 Gr Külçe Altın.", "50-gr-külce-altin" },
                    { 5, new DateTime(2024, 4, 15, 16, 12, 37, 326, DateTimeKind.Local).AddTicks(4082), "4.png", true, false, true, new DateTime(2024, 4, 15, 16, 12, 37, 326, DateTimeKind.Local).AddTicks(4083), "100 Gr Külçe Altın", 280000m, "24 Ayar 995.0 Saflıkta, 100 Gr Külçe Altın.", "100-gr-külce-altin" },
                    { 6, new DateTime(2024, 4, 15, 16, 12, 37, 326, DateTimeKind.Local).AddTicks(4085), "5.png", true, false, true, new DateTime(2024, 4, 15, 16, 12, 37, 326, DateTimeKind.Local).AddTicks(4086), "250 Gr Külçe Altın", 7000000m, "24 Ayar 995.0 Saflıkta, 250 Gr Külçe Altın.", "250-gr-külce-altin" },
                    { 7, new DateTime(2024, 4, 15, 16, 12, 37, 326, DateTimeKind.Local).AddTicks(4088), "6.png", true, false, false, new DateTime(2024, 4, 15, 16, 12, 37, 326, DateTimeKind.Local).AddTicks(4089), "500 Gr Külçe Altın", 1400000m, "24 Ayar 995.0 Saflıkta, 500 Gr Külçe Altın.", "500-gr-külce-altin" },
                    { 8, new DateTime(2024, 4, 15, 16, 12, 37, 326, DateTimeKind.Local).AddTicks(4092), "7.png", true, false, true, new DateTime(2024, 4, 15, 16, 12, 37, 326, DateTimeKind.Local).AddTicks(4105), "1000 Gr Külçe Altın", 2800000m, "24 Ayar 995.0 Saflıkta, 500 Gr Külçe Altın.", "1000-gr-külce-altin" },
                    { 9, new DateTime(2024, 4, 15, 16, 12, 37, 326, DateTimeKind.Local).AddTicks(4128), "8.png", true, false, false, new DateTime(2024, 4, 15, 16, 12, 37, 326, DateTimeKind.Local).AddTicks(4129), "Çeyrek Altın", 4750m, "22 Ayar 916.0 Saflıkta, 1.75 Gr Çeyrek Altın.", "ceyrek-altin" },
                    { 10, new DateTime(2024, 4, 15, 16, 12, 37, 326, DateTimeKind.Local).AddTicks(4132), "9.png", true, false, true, new DateTime(2024, 4, 15, 16, 12, 37, 326, DateTimeKind.Local).AddTicks(4133), "Yarım", 9500m, "22 Ayar 916.0 Saflıkta, 3.50 Gr Yarım Altın.", "yarim-altin" },
                    { 11, new DateTime(2024, 4, 15, 16, 12, 37, 326, DateTimeKind.Local).AddTicks(4136), "10.png", true, false, true, new DateTime(2024, 4, 15, 16, 12, 37, 326, DateTimeKind.Local).AddTicks(4136), "Tam Altın", 19000m, "22 Ayar 916.0 Saflıkta, 7 Gr Tam Altın.", "tam-altin" },
                    { 12, new DateTime(2024, 4, 15, 16, 12, 37, 326, DateTimeKind.Local).AddTicks(4139), "12.png", true, false, true, new DateTime(2024, 4, 15, 16, 12, 37, 326, DateTimeKind.Local).AddTicks(4139), "100gr Külçe Gümüş", 3850m, "999.0 Saflıkta, 100 Gr Külçe Gümüş.", "100gr-külce-gümüs" },
                    { 13, new DateTime(2024, 4, 15, 16, 12, 37, 326, DateTimeKind.Local).AddTicks(4142), "13.png", true, false, true, new DateTime(2024, 4, 15, 16, 12, 37, 326, DateTimeKind.Local).AddTicks(4143), "250gr Külçe Gümüş", 8750m, "999.0 Saflıkta, 250 Gr Külçe Gümüş.", "250gr-külce-gümüs" },
                    { 14, new DateTime(2024, 4, 15, 16, 12, 37, 326, DateTimeKind.Local).AddTicks(4145), "14.png", true, false, true, new DateTime(2024, 4, 15, 16, 12, 37, 326, DateTimeKind.Local).AddTicks(4146), "500gr Külçe Gümüş", 17500m, "999.0 Saflıkta, 500 Gr Külçe Gümüş.", "500gr-külce-gümüs" },
                    { 15, new DateTime(2024, 4, 15, 16, 12, 37, 326, DateTimeKind.Local).AddTicks(4150), "15.png", true, false, true, new DateTime(2024, 4, 15, 16, 12, 37, 326, DateTimeKind.Local).AddTicks(4151), "1000gr Külçe Gümüş", 34000m, "999.0 Saflıkta, 1000 Gr Külçe Gümüş.", "1000gr-külce-gümüs" }
                });

            migrationBuilder.InsertData(
                table: "ShoppingCarts",
                columns: new[] { "Id", "CreatedDate", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 15, 16, 12, 37, 323, DateTimeKind.Local).AddTicks(6850), "ddf64ab8-e830-42c1-a048-4b3d33afaae3" },
                    { 2, new DateTime(2024, 4, 15, 16, 12, 37, 323, DateTimeKind.Local).AddTicks(6879), "e4e3921b-4696-441c-8c13-b25d93cfb032" },
                    { 3, new DateTime(2024, 4, 15, 16, 12, 37, 323, DateTimeKind.Local).AddTicks(6883), "b0279cd1-7ddb-4ce0-acc2-4ec4db9c317d" },
                    { 4, new DateTime(2024, 4, 15, 16, 12, 37, 323, DateTimeKind.Local).AddTicks(6885), "1c10e730-1401-48cb-8146-5a06943c6ca4" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "b0bdfef0-fd00-4f68-a44a-4c3afb5a7ea8", "1c10e730-1401-48cb-8146-5a06943c6ca4" },
                    { "4ea9ddb3-2d04-4fba-bb1e-8f1126670ff7", "b0279cd1-7ddb-4ce0-acc2-4ec4db9c317d" },
                    { "e4e7c8bd-9fe2-49ca-a5aa-d285da379844", "ddf64ab8-e830-42c1-a048-4b3d33afaae3" },
                    { "4ea9ddb3-2d04-4fba-bb1e-8f1126670ff7", "e4e3921b-4696-441c-8c13-b25d93cfb032" }
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
