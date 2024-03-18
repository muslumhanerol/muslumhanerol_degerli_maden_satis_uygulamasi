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
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDdate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDelete = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDdate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDelete = table.Column<bool>(type: "INTEGER", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Properties = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsHome = table.Column<bool>(type: "INTEGER", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryProducks",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryProducks", x => new { x.CategoryId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_CategoryProducks_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryProducks_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDdate", "Description", "IsActive", "IsDelete", "ModifiedDate", "Name", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 19, 1, 8, 11, 89, DateTimeKind.Local).AddTicks(846), "Altın Kategorisi", true, false, new DateTime(2024, 3, 19, 1, 8, 11, 89, DateTimeKind.Local).AddTicks(860), "Nesne Altın", "nesne-altin" },
                    { 2, new DateTime(2024, 3, 19, 1, 8, 11, 89, DateTimeKind.Local).AddTicks(863), "Altın Kategorisi", true, false, new DateTime(2024, 3, 19, 1, 8, 11, 89, DateTimeKind.Local).AddTicks(863), "Dijital Altın", "dijital-altin" },
                    { 3, new DateTime(2024, 3, 19, 1, 8, 11, 89, DateTimeKind.Local).AddTicks(865), "Sarrafiye Kategorisi", true, false, new DateTime(2024, 3, 19, 1, 8, 11, 89, DateTimeKind.Local).AddTicks(865), "Sarrafiye", "sarrafiye-altin" },
                    { 4, new DateTime(2024, 3, 19, 1, 8, 11, 89, DateTimeKind.Local).AddTicks(870), "Gümüş Kategorisi", true, false, new DateTime(2024, 3, 19, 1, 8, 11, 89, DateTimeKind.Local).AddTicks(870), "Nesne Gümüş", "nesne-gümüs" },
                    { 5, new DateTime(2024, 3, 19, 1, 8, 11, 89, DateTimeKind.Local).AddTicks(872), "Gümüş Kategorisi", true, false, new DateTime(2024, 3, 19, 1, 8, 11, 89, DateTimeKind.Local).AddTicks(872), "Dijital Gümüş", "dijital-gümüs" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDdate", "ImageUrl", "IsActive", "IsDelete", "IsHome", "ModifiedDate", "Name", "Price", "Properties", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 19, 1, 8, 11, 89, DateTimeKind.Local).AddTicks(3073), "1.png", true, false, false, new DateTime(2024, 3, 19, 1, 8, 11, 89, DateTimeKind.Local).AddTicks(3082), "20gr Külçe", 48000m, "24 Ayar Saflıkta, 20 gr Külçe Altın.", "20gr-külce-altin" },
                    { 2, new DateTime(2024, 3, 19, 1, 8, 11, 89, DateTimeKind.Local).AddTicks(3088), "2.png", true, false, true, new DateTime(2024, 3, 19, 1, 8, 11, 89, DateTimeKind.Local).AddTicks(3088), "50gr Külçe", 120000m, "24 Ayar Saflıkta, 50 gr Külçe Altın.", "50gr-külce-altin" },
                    { 3, new DateTime(2024, 3, 19, 1, 8, 11, 89, DateTimeKind.Local).AddTicks(3091), "3.png", true, false, true, new DateTime(2024, 3, 19, 1, 8, 11, 89, DateTimeKind.Local).AddTicks(3092), "100gr Külçe", 240000m, "24 Ayar Saflıkta, 100 gr Külçe Altın.", "100gr-külce-altin" },
                    { 4, new DateTime(2024, 3, 19, 1, 8, 11, 89, DateTimeKind.Local).AddTicks(3094), "4.png", true, false, true, new DateTime(2024, 3, 19, 1, 8, 11, 89, DateTimeKind.Local).AddTicks(3094), "250gr Külçe", 620000m, "24 Ayar Saflıkta, 250 gr Külçe Altın.", "250gr-külce-altin" },
                    { 5, new DateTime(2024, 3, 19, 1, 8, 11, 89, DateTimeKind.Local).AddTicks(3096), "5.png", true, false, true, new DateTime(2024, 3, 19, 1, 8, 11, 89, DateTimeKind.Local).AddTicks(3097), "Çeyrek Altın", 4500m, "24 Ayar Saflıkta, Çeyrek Altın.", "ceyrek-altin" },
                    { 6, new DateTime(2024, 3, 19, 1, 8, 11, 89, DateTimeKind.Local).AddTicks(3099), "6.png", true, false, false, new DateTime(2024, 3, 19, 1, 8, 11, 89, DateTimeKind.Local).AddTicks(3099), "Yarim Altın", 90000m, "24 Ayar Saflıkta, Yarım Altın.", "yarim-altin" },
                    { 7, new DateTime(2024, 3, 19, 1, 8, 11, 89, DateTimeKind.Local).AddTicks(3102), "7.png", true, false, true, new DateTime(2024, 3, 19, 1, 8, 11, 89, DateTimeKind.Local).AddTicks(3102), "Tam Altın", 180000m, "24 Ayar Saflıkta, Tam Altın.", "tam-altin" },
                    { 8, new DateTime(2024, 3, 19, 1, 8, 11, 89, DateTimeKind.Local).AddTicks(3104), "8.png", true, false, true, new DateTime(2024, 3, 19, 1, 8, 11, 89, DateTimeKind.Local).AddTicks(3105), "100gr Külçe", 45000m, "925 Saflıkta, 100 gr Külçe Gümüş.", "100gr-külce-gümüs" },
                    { 9, new DateTime(2024, 3, 19, 1, 8, 11, 89, DateTimeKind.Local).AddTicks(3107), "9.png", true, false, true, new DateTime(2024, 3, 19, 1, 8, 11, 89, DateTimeKind.Local).AddTicks(3107), "250gr Külçe", 112500m, "925 Saflıkta, 250 gr Külçe Gümüş.", "250gr-külce-gümüs" },
                    { 10, new DateTime(2024, 3, 19, 1, 8, 11, 89, DateTimeKind.Local).AddTicks(3109), "10.png", true, false, true, new DateTime(2024, 3, 19, 1, 8, 11, 89, DateTimeKind.Local).AddTicks(3110), "500gr Külçe", 225000m, "925 Saflıkta, 500 gr Külçe Gümüş.", "500gr-külce-gümüs" }
                });

            migrationBuilder.InsertData(
                table: "CategoryProducks",
                columns: new[] { "CategoryId", "ProductId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 4 },
                    { 2, 1 },
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 3, 5 },
                    { 3, 6 },
                    { 3, 7 },
                    { 4, 8 },
                    { 4, 9 },
                    { 4, 10 },
                    { 5, 8 },
                    { 5, 9 },
                    { 5, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryProducks_ProductId",
                table: "CategoryProducks",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryProducks");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
