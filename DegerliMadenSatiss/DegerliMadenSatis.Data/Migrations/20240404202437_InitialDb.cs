using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DegerliMadenSatis.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
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
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "IsDeleted", "ModifiedDate", "Name", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 4, 23, 24, 36, 834, DateTimeKind.Local).AddTicks(3369), "Altın Kategorisi", true, false, new DateTime(2024, 4, 4, 23, 24, 36, 834, DateTimeKind.Local).AddTicks(3389), "Fiziki Altın", "fiziki-altin" },
                    { 2, new DateTime(2024, 4, 4, 23, 24, 36, 834, DateTimeKind.Local).AddTicks(3395), "Altın Kategorisi", true, false, new DateTime(2024, 4, 4, 23, 24, 36, 834, DateTimeKind.Local).AddTicks(3396), "Dijital Altın", "dijital-altin" },
                    { 3, new DateTime(2024, 4, 4, 23, 24, 36, 834, DateTimeKind.Local).AddTicks(3399), "Ziynet Kategorisi", true, false, new DateTime(2024, 4, 4, 23, 24, 36, 834, DateTimeKind.Local).AddTicks(3403), "Ziynet Altın", "ziynet-altin" },
                    { 4, new DateTime(2024, 4, 4, 23, 24, 36, 834, DateTimeKind.Local).AddTicks(3406), "Gümüş Kategorisi", true, false, new DateTime(2024, 4, 4, 23, 24, 36, 834, DateTimeKind.Local).AddTicks(3407), "Fiziki Gümüş", "fiziki-gümüs" },
                    { 5, new DateTime(2024, 4, 4, 23, 24, 36, 834, DateTimeKind.Local).AddTicks(3410), "Gümüş Kategorisi", true, false, new DateTime(2024, 4, 4, 23, 24, 36, 834, DateTimeKind.Local).AddTicks(3411), "Dijital Gümüş", "dijital-gümüs" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "ImageUrl", "IsActive", "IsDeleted", "IsHome", "ModifiedDate", "Name", "Price", "Properties", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 4, 23, 24, 36, 837, DateTimeKind.Local).AddTicks(7386), "1.png", true, false, true, new DateTime(2024, 4, 4, 23, 24, 36, 837, DateTimeKind.Local).AddTicks(7406), "5 Gr Külçe Altın", 13500m, "24 Ayar 995.0 Saflıkta, 5 Gr Külçe Altın.", "5-gr-külce-altin" },
                    { 2, new DateTime(2024, 4, 4, 23, 24, 36, 837, DateTimeKind.Local).AddTicks(7417), "1.png", true, false, true, new DateTime(2024, 4, 4, 23, 24, 36, 837, DateTimeKind.Local).AddTicks(7419), "10 Gr Külçe Altın", 27000m, "24 Ayar 995.0 Saflıkta, 10 Gr Külçe Altın.", "10-gr-külce-altin" },
                    { 3, new DateTime(2024, 4, 4, 23, 24, 36, 837, DateTimeKind.Local).AddTicks(7424), "2.png", true, false, false, new DateTime(2024, 4, 4, 23, 24, 36, 837, DateTimeKind.Local).AddTicks(7425), "20 Gr Külçe Altın", 54000m, "24 Ayar 995.0 Saflıkta, 20 Gr Külçe Altın.", "20-gr-külce-altin" },
                    { 4, new DateTime(2024, 4, 4, 23, 24, 36, 837, DateTimeKind.Local).AddTicks(7429), "3.png", true, false, true, new DateTime(2024, 4, 4, 23, 24, 36, 837, DateTimeKind.Local).AddTicks(7430), "50 Gr Külçe Altın", 135000m, "24 Ayar 995.0 Saflıkta, 50 Gr Külçe Altın.", "50-gr-külce-altin" },
                    { 5, new DateTime(2024, 4, 4, 23, 24, 36, 837, DateTimeKind.Local).AddTicks(7433), "4.png", true, false, true, new DateTime(2024, 4, 4, 23, 24, 36, 837, DateTimeKind.Local).AddTicks(7434), "100 Gr Külçe Altın", 270000m, "24 Ayar 995.0 Saflıkta, 100 Gr Külçe Altın.", "100-gr-külce-altin" },
                    { 6, new DateTime(2024, 4, 4, 23, 24, 36, 837, DateTimeKind.Local).AddTicks(7439), "5.png", true, false, true, new DateTime(2024, 4, 4, 23, 24, 36, 837, DateTimeKind.Local).AddTicks(7440), "250 Gr Külçe Altın", 680000m, "24 Ayar 995.0 Saflıkta, 250 Gr Külçe Altın.", "250-gr-külce-altin" },
                    { 7, new DateTime(2024, 4, 4, 23, 24, 36, 837, DateTimeKind.Local).AddTicks(7444), "6.png", true, false, false, new DateTime(2024, 4, 4, 23, 24, 36, 837, DateTimeKind.Local).AddTicks(7445), "500 Gr Külçe Altın", 1350000m, "24 Ayar 995.0 Saflıkta, 500 Gr Külçe Altın.", "500-gr-külce-altin" },
                    { 8, new DateTime(2024, 4, 4, 23, 24, 36, 837, DateTimeKind.Local).AddTicks(7448), "7.png", true, false, true, new DateTime(2024, 4, 4, 23, 24, 36, 837, DateTimeKind.Local).AddTicks(7449), "1000 Gr Külçe Altın", 270000m, "24 Ayar 995.0 Saflıkta, 500 Gr Külçe Altın.", "1000-gr-külce-altin" },
                    { 9, new DateTime(2024, 4, 4, 23, 24, 36, 837, DateTimeKind.Local).AddTicks(7452), "8.png", true, false, false, new DateTime(2024, 4, 4, 23, 24, 36, 837, DateTimeKind.Local).AddTicks(7453), "Çeyrek Altın", 4700m, "22 Ayar 916.0 Saflıkta, 1.75 Gr Çeyrek Altın.", "ceyrek-altin" },
                    { 10, new DateTime(2024, 4, 4, 23, 24, 36, 837, DateTimeKind.Local).AddTicks(7457), "9.png", true, false, true, new DateTime(2024, 4, 4, 23, 24, 36, 837, DateTimeKind.Local).AddTicks(7458), "Yarım", 1250m, "22 Ayar 916.0 Saflıkta, 3.50 Gr Yarım Altın.", "yarim-altin" },
                    { 11, new DateTime(2024, 4, 4, 23, 24, 36, 837, DateTimeKind.Local).AddTicks(7461), "10.png", true, false, true, new DateTime(2024, 4, 4, 23, 24, 36, 837, DateTimeKind.Local).AddTicks(7463), "Tam Altın", 2100m, "22 Ayar 916.0 Saflıkta, 7 Gr Tam Altın.", "tam-altin" },
                    { 12, new DateTime(2024, 4, 4, 23, 24, 36, 837, DateTimeKind.Local).AddTicks(7467), "12.png", true, false, true, new DateTime(2024, 4, 4, 23, 24, 36, 837, DateTimeKind.Local).AddTicks(7468), "100gr Külçe Gümüş", 3500m, "999.0 Saflıkta, 100 Gr Külçe Gümüş.", "100gr-külce-gümüs" },
                    { 13, new DateTime(2024, 4, 4, 23, 24, 36, 837, DateTimeKind.Local).AddTicks(7472), "13.png", true, false, true, new DateTime(2024, 4, 4, 23, 24, 36, 837, DateTimeKind.Local).AddTicks(7473), "250gr Külçe Gümüş", 8000m, "999.0 Saflıkta, 250 Gr Külçe Gümüş.", "250gr-külce-gümüs" },
                    { 14, new DateTime(2024, 4, 4, 23, 24, 36, 837, DateTimeKind.Local).AddTicks(7477), "14.png", true, false, true, new DateTime(2024, 4, 4, 23, 24, 36, 837, DateTimeKind.Local).AddTicks(7478), "500gr Külçe Gümüş", 16000m, "999.0 Saflıkta, 500 Gr Külçe Gümüş.", "500gr-külce-gümüs" },
                    { 15, new DateTime(2024, 4, 4, 23, 24, 36, 837, DateTimeKind.Local).AddTicks(7482), "15.png", true, false, true, new DateTime(2024, 4, 4, 23, 24, 36, 837, DateTimeKind.Local).AddTicks(7483), "1000gr Külçe Gümüş", 32000m, "999.0 Saflıkta, 1000 Gr Külçe Gümüş.", "1000gr-külce-gümüs" }
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
