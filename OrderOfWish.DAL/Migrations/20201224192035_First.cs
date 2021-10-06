using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace OrderOfWish.DAL.Migrations
{
    public partial class First : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brand",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    BrandName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brand", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    GenreName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    CompanyName = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    City = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    Country = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    Address = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    PhoneNumber = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: true),
                    Email = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    Email = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    FirstName = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    LastName = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false),
                    PhoneNumber = table.Column<string>(type: "character varying(18)", maxLength: 18, nullable: false),
                    Address = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    ActivationCode = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    ProductName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ProductImgURL = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Price = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    Stock = table.Column<short>(type: "smallint", nullable: false),
                    Continued = table.Column<bool>(type: "boolean", nullable: false),
                    BrandID = table.Column<int>(type: "integer", nullable: false),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    GenreID = table.Column<int>(type: "integer", nullable: false),
                    SupplierID = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Product_Brand_BrandID",
                        column: x => x.BrandID,
                        principalTable: "Brand",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Genre_GenreID",
                        column: x => x.GenreID,
                        principalTable: "Genre",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Product_Supplier_SupplierID",
                        column: x => x.SupplierID,
                        principalTable: "Supplier",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityAlwaysColumn),
                    OrderDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ShipAddress = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    UserID = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Order_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order Detail",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "integer", nullable: false),
                    ProductID = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "numeric(10,2)", precision: 10, scale: 2, nullable: false),
                    Stock = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<short>(type: "smallint", nullable: false),
                    Discount = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order Detail", x => new { x.ProductID, x.OrderID });
                    table.ForeignKey(
                        name: "FK_Order Detail_Order_OrderID",
                        column: x => x.OrderID,
                        principalTable: "Order",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order Detail_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brand",
                columns: new[] { "ID", "BrandName", "CreatedDate", "Description", "IsActive" },
                values: new object[,]
                {
                    { 1, "Adidas", new DateTime(2020, 12, 24, 22, 20, 34, 291, DateTimeKind.Local).AddTicks(7793), null, true },
                    { 2, "Nike", new DateTime(2020, 12, 24, 22, 20, 34, 297, DateTimeKind.Local).AddTicks(5832), null, true },
                    { 3, "U.S Polo", new DateTime(2020, 12, 24, 22, 20, 34, 297, DateTimeKind.Local).AddTicks(6041), null, true },
                    { 4, "The North Face", new DateTime(2020, 12, 24, 22, 20, 34, 297, DateTimeKind.Local).AddTicks(6052), null, true },
                    { 5, "Columbia", new DateTime(2020, 12, 24, 22, 20, 34, 297, DateTimeKind.Local).AddTicks(6061), null, true }
                });

            migrationBuilder.InsertData(
                table: "Supplier",
                columns: new[] { "ID", "Address", "City", "CompanyName", "Country", "CreatedDate", "Email", "IsActive", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Behind the Oregon Cemetery", "Oregon,USA", "US.ForU", null, new DateTime(2020, 12, 24, 22, 20, 34, 340, DateTimeKind.Local).AddTicks(3377), "usforu@oregon.com", true, "12345678890" },
                    { 2, "Behind the California Cemetery", "California,USA", "ForLoveAndPeace", null, new DateTime(2020, 12, 24, 22, 20, 34, 340, DateTimeKind.Local).AddTicks(6994), "peaceangel@for.com", true, "0987654321" },
                    { 3, "Just Cemetery", "Anywhere in USA", "dunnowhatUwant", null, new DateTime(2020, 12, 24, 22, 20, 34, 340, DateTimeKind.Local).AddTicks(7085), "imjustdiedbro@our.com", true, "1238763458" },
                    { 4, "im a visiter too mate", "what u want from me?", "Oh Really?", null, new DateTime(2020, 12, 24, 22, 20, 34, 340, DateTimeKind.Local).AddTicks(7092), "jesuschrist@man.wow", true, "23456787609" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "ID", "ActivationCode", "Address", "BirthDate", "CreatedDate", "Email", "FirstName", "Gender", "IsActive", "LastName", "Password", "PhoneNumber", "Role" },
                values: new object[,]
                {
                    { 1, new Guid("9c9fce08-e92b-408a-8fe3-d1a93d90df95"), "Kadıköy", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 24, 22, 20, 34, 336, DateTimeKind.Local).AddTicks(8146), "burak.tosun53.bt@gmail.com", "Burak", 1, true, "Tosun", "1907", "05344155423", 2 },
                    { 2, new Guid("c7ddaf56-c242-414a-9482-8649b68e8be3"), "Beykoz", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 24, 22, 20, 34, 337, DateTimeKind.Local).AddTicks(5893), "eser.kukul@remax.com", "Eser", 1, true, "Kukul", "1905", "05424352345", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_UserID",
                table: "Order",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Order Detail_OrderID",
                table: "Order Detail",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_BrandID",
                table: "Product",
                column: "BrandID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_GenreID",
                table: "Product",
                column: "GenreID");

            migrationBuilder.CreateIndex(
                name: "IX_Product_SupplierID",
                table: "Product",
                column: "SupplierID");

            migrationBuilder.CreateIndex(
                name: "IX_User_Email",
                table: "User",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order Detail");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Brand");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "Supplier");
        }
    }
}
