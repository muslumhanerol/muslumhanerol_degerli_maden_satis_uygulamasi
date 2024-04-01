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
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
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
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Price = table.Column<decimal>(type: "real", nullable: false),
                    Properties = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    IsHome = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "date('now')"),
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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Description", "IsActive", "IsDeleted", "ModifiedDate", "Name", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 31, 3, 21, 50, 567, DateTimeKind.Local).AddTicks(8524), "Altın Kategorisi", true, false, new DateTime(2024, 3, 31, 3, 21, 50, 567, DateTimeKind.Local).AddTicks(8542), "Fiziki Altın", "fiziki-altin" },
                    { 2, new DateTime(2024, 3, 31, 3, 21, 50, 567, DateTimeKind.Local).AddTicks(8548), "Altın Kategorisi", true, false, new DateTime(2024, 3, 31, 3, 21, 50, 567, DateTimeKind.Local).AddTicks(8549), "Dijital Altın", "dijital-altin" },
                    { 3, new DateTime(2024, 3, 31, 3, 21, 50, 567, DateTimeKind.Local).AddTicks(8552), "Ziynet Kategorisi", true, false, new DateTime(2024, 3, 31, 3, 21, 50, 567, DateTimeKind.Local).AddTicks(8553), "Ziynet Altın", "ziynet-altin" },
                    { 4, new DateTime(2024, 3, 31, 3, 21, 50, 567, DateTimeKind.Local).AddTicks(8556), "Gümüş Kategorisi", true, false, new DateTime(2024, 3, 31, 3, 21, 50, 567, DateTimeKind.Local).AddTicks(8557), "Fiziki Gümüş", "fiziki-gümüs" },
                    { 5, new DateTime(2024, 3, 31, 3, 21, 50, 567, DateTimeKind.Local).AddTicks(8559), "Gümüş Kategorisi", true, false, new DateTime(2024, 3, 31, 3, 21, 50, 567, DateTimeKind.Local).AddTicks(8561), "Dijital Gümüş", "dijital-gümüs" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "ImageUrl", "IsActive", "IsDeleted", "IsHome", "ModifiedDate", "Name", "Price", "Properties", "Url" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 3, 31, 3, 21, 50, 576, DateTimeKind.Local).AddTicks(3281), "1.png", true, false, true, new DateTime(2024, 3, 31, 3, 21, 50, 576, DateTimeKind.Local).AddTicks(3304), "5 Gr Külçe Altın", 13500m, "24 Ayar 995.0 Saflıkta, 5 Gr Külçe Altın.", "5-gr-külce-altin" },
                    { 2, new DateTime(2024, 3, 31, 3, 21, 50, 576, DateTimeKind.Local).AddTicks(3315), "1.png", true, false, true, new DateTime(2024, 3, 31, 3, 21, 50, 576, DateTimeKind.Local).AddTicks(3317), "10 Gr Külçe Altın", 27000m, "24 Ayar 995.0 Saflıkta, 10 Gr Külçe Altın.", "10-gr-külce-altin" },
                    { 3, new DateTime(2024, 3, 31, 3, 21, 50, 576, DateTimeKind.Local).AddTicks(3321), "2.png", true, false, false, new DateTime(2024, 3, 31, 3, 21, 50, 576, DateTimeKind.Local).AddTicks(3322), "20 Gr Külçe Altın", 54000m, "24 Ayar 995.0 Saflıkta, 20 Gr Külçe Altın.", "20-gr-külce-altin" },
                    { 4, new DateTime(2024, 3, 31, 3, 21, 50, 576, DateTimeKind.Local).AddTicks(3325), "3.png", true, false, true, new DateTime(2024, 3, 31, 3, 21, 50, 576, DateTimeKind.Local).AddTicks(3327), "50 Gr Külçe Altın", 135000m, "24 Ayar 995.0 Saflıkta, 50 Gr Külçe Altın.", "50-gr-külce-altin" },
                    { 5, new DateTime(2024, 3, 31, 3, 21, 50, 576, DateTimeKind.Local).AddTicks(3330), "4.png", true, false, true, new DateTime(2024, 3, 31, 3, 21, 50, 576, DateTimeKind.Local).AddTicks(3331), "100 Gr Külçe Altın", 270000m, "24 Ayar 995.0 Saflıkta, 100 Gr Külçe Altın.", "100-gr-külce-altin" },
                    { 6, new DateTime(2024, 3, 31, 3, 21, 50, 576, DateTimeKind.Local).AddTicks(3335), "5.png", true, false, true, new DateTime(2024, 3, 31, 3, 21, 50, 576, DateTimeKind.Local).AddTicks(3336), "250 Gr Külçe Altın", 680000m, "24 Ayar 995.0 Saflıkta, 250 Gr Külçe Altın.", "250-gr-külce-altin" },
                    { 7, new DateTime(2024, 3, 31, 3, 21, 50, 576, DateTimeKind.Local).AddTicks(3340), "6.png", true, false, false, new DateTime(2024, 3, 31, 3, 21, 50, 576, DateTimeKind.Local).AddTicks(3341), "500 Gr Külçe Altın", 1350000m, "24 Ayar 995.0 Saflıkta, 500 Gr Külçe Altın.", "500-gr-külce-altin" },
                    { 8, new DateTime(2024, 3, 31, 3, 21, 50, 576, DateTimeKind.Local).AddTicks(3345), "7.png", true, false, true, new DateTime(2024, 3, 31, 3, 21, 50, 576, DateTimeKind.Local).AddTicks(3346), "1000 Gr Külçe Altın", 270000m, "24 Ayar 995.0 Saflıkta, 500 Gr Külçe Altın.", "1000-gr-külce-altin" },
                    { 9, new DateTime(2024, 3, 31, 3, 21, 50, 576, DateTimeKind.Local).AddTicks(3350), "8.png", true, false, false, new DateTime(2024, 3, 31, 3, 21, 50, 576, DateTimeKind.Local).AddTicks(3351), "Çeyrek Altın", 4700m, "22 Ayar 916.0 Saflıkta, 1.75 Gr Çeyrek Altın.", "ceyrek-altin" },
                    { 10, new DateTime(2024, 3, 31, 3, 21, 50, 576, DateTimeKind.Local).AddTicks(3355), "9.png", true, false, true, new DateTime(2024, 3, 31, 3, 21, 50, 576, DateTimeKind.Local).AddTicks(3356), "Yarım", 1250m, "22 Ayar 916.0 Saflıkta, 3.50 Gr Yarım Altın.", "yarim-altin" },
                    { 11, new DateTime(2024, 3, 31, 3, 21, 50, 576, DateTimeKind.Local).AddTicks(3360), "10.png", true, false, true, new DateTime(2024, 3, 31, 3, 21, 50, 576, DateTimeKind.Local).AddTicks(3361), "Tam Altın", 2100m, "22 Ayar 916.0 Saflıkta, 7 Gr Tam Altın.", "tam-altin" },
                    { 12, new DateTime(2024, 3, 31, 3, 21, 50, 576, DateTimeKind.Local).AddTicks(3364), "12.png", true, false, true, new DateTime(2024, 3, 31, 3, 21, 50, 576, DateTimeKind.Local).AddTicks(3365), "100gr Külçe Gümüş", 3500m, "999.0 Saflıkta, 100 Gr Külçe Gümüş.", "100gr-külce-gümüs" },
                    { 13, new DateTime(2024, 3, 31, 3, 21, 50, 576, DateTimeKind.Local).AddTicks(3368), "13.png", true, false, true, new DateTime(2024, 3, 31, 3, 21, 50, 576, DateTimeKind.Local).AddTicks(3369), "250gr Külçe Gümüş", 8000m, "999.0 Saflıkta, 250 Gr Külçe Gümüş.", "250gr-külce-gümüs" },
                    { 14, new DateTime(2024, 3, 31, 3, 21, 50, 576, DateTimeKind.Local).AddTicks(3377), "14.png", true, false, true, new DateTime(2024, 3, 31, 3, 21, 50, 576, DateTimeKind.Local).AddTicks(3379), "500gr Külçe Gümüş", 16000m, "999.0 Saflıkta, 500 Gr Külçe Gümüş.", "500gr-külce-gümüs" },
                    { 15, new DateTime(2024, 3, 31, 3, 21, 50, 576, DateTimeKind.Local).AddTicks(3382), "15.png", true, false, true, new DateTime(2024, 3, 31, 3, 21, 50, 576, DateTimeKind.Local).AddTicks(3383), "250gr Külçe Gümüş", 32000m, "999.0 Saflıkta, 1000 Gr Külçe Gümüş.", "1000gr-külce-gümüs" }
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
                name: "IX_ProductCategories_CategoryId",
                table: "ProductCategories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
