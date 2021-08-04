using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Desciption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_products_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RolesId = table.Column<int>(type: "int", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Avarta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PassWord = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GPU = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ram = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rom = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    productsId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_product_Details_products_productsId",
                        column: x => x.productsId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "invoice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    ProductModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_invoice_products_ProductModelId",
                        column: x => x.ProductModelId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_invoice_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "invoice_Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_invoice_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_invoice_Details_invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "invoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_invoice_Details_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "Name", "Status" },
                values: new object[,]
                {
                    { 1, "PlayStaion 4", true },
                    { 2, "Xbox One S", true },
                    { 3, "Nintendo Switch", true }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "Id", "Name", "Status" },
                values: new object[,]
                {
                    { 1, "Admin", true },
                    { 2, "User", true }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Desciption", "Image", "Name", "Price", "Quantity", "Status", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 7, 20, 20, 52, 59, 235, DateTimeKind.Local).AddTicks(2939), "Đẹp", "Máy PS4 Pro The Last Of Us 2 Limited Edition.jpg", "PS4 Pro The Last Of Us 2 Limited Edition", 299m, 50, true, null },
                    { 2, 1, new DateTime(2021, 7, 20, 20, 52, 59, 237, DateTimeKind.Local).AddTicks(588), "Đẹp", "Máy PS4 Slim 1TB.jpg", "PS4 Slim 1TB", 299m, 50, true, null },
                    { 3, 1, new DateTime(2021, 7, 20, 20, 52, 59, 237, DateTimeKind.Local).AddTicks(645), "Đẹp", "Máy PS4 Pro The Last Of Us 2 Limited Edition.jpg", "Sony PS4 Slim Days Of Play 2019 Limited Edition", 299m, 50, true, null },
                    { 4, 1, new DateTime(2021, 7, 20, 20, 52, 59, 237, DateTimeKind.Local).AddTicks(654), "Đẹp", "PS4 Pro 2nd hand.jpg", "PS4 Pro 2nd hand", 299m, 50, true, null },
                    { 5, 2, new DateTime(2021, 7, 20, 20, 52, 59, 237, DateTimeKind.Local).AddTicks(658), "Đẹp", "PS4 Pro 2nd hand.jpg", "Xbox Series X", 299m, 50, true, null },
                    { 6, 2, new DateTime(2021, 7, 20, 20, 52, 59, 237, DateTimeKind.Local).AddTicks(663), "Đẹp", "Xbox Series X.jpg", "Xbox Series X", 299m, 50, true, null },
                    { 7, 2, new DateTime(2021, 7, 20, 20, 52, 59, 237, DateTimeKind.Local).AddTicks(668), "Đẹp", "Xbox Series X.jpg", "Xbox Series X", 299m, 50, true, null },
                    { 8, 2, new DateTime(2021, 7, 20, 20, 52, 59, 237, DateTimeKind.Local).AddTicks(673), "Đẹp", "Xbox Series S.jpg", "Xbox Series S", 299m, 50, true, null },
                    { 9, 3, new DateTime(2021, 7, 20, 20, 52, 59, 237, DateTimeKind.Local).AddTicks(678), "Đẹp", "Máy Nintendo Switch V2 Màu Neon.jpg", "Nintendo Switch V2 Màu Neon", 299m, 50, true, null },
                    { 10, 3, new DateTime(2021, 7, 20, 20, 52, 59, 237, DateTimeKind.Local).AddTicks(683), "Đẹp", "Máy Nintendo Switch Lite - Màu Blue.jpg", "Nintendo Switch Lite - Màu Blue", 299m, 50, true, null },
                    { 11, 3, new DateTime(2021, 7, 20, 20, 52, 59, 237, DateTimeKind.Local).AddTicks(687), "Đẹp", "Máy Nintendo Switch Fortnite Special Edition.jpg", "Nintendo Switch Fortnite Special Edition", 299m, 50, true, null },
                    { 12, 3, new DateTime(2021, 7, 20, 20, 52, 59, 237, DateTimeKind.Local).AddTicks(693), "Đẹp", "Máy Nintendo Switch Animal Crossing.jpg", "Nintendo Switch Animal Crossing", 299m, 50, true, null }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "Address", "Avarta", "CreatedOn", "DateOfBirth", "Email", "FullName", "PassWord", "Phone", "RolesId", "Status", "UpdatedOn", "UserName" },
                values: new object[,]
                {
                    { 1, "115 Trần Xuân Soạn", "user-1.png", new DateTime(2021, 7, 20, 20, 52, 59, 238, DateTimeKind.Local).AddTicks(507), null, "duyvo049@gmail.com", "Võ Thành Duy", "25f9e794323b453885f5181f1b624d0b", "0393030574", 1, true, null, "thanhduy" },
                    { 2, "115 Trần Xuân Soạn", "user-2.png", new DateTime(2021, 7, 20, 20, 52, 59, 238, DateTimeKind.Local).AddTicks(2225), null, "leloc603@gmail.com", "Lê Xuân Lộc", "25f9e794323b453885f5181f1b624d0b", "0393030574", 2, true, null, "leloc" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_invoice_ProductModelId",
                table: "invoice",
                column: "ProductModelId");

            migrationBuilder.CreateIndex(
                name: "IX_invoice_UserId",
                table: "invoice",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_invoice_Details_InvoiceId",
                table: "invoice_Details",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_invoice_Details_ProductId",
                table: "invoice_Details",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_product_Details_productsId",
                table: "product_Details",
                column: "productsId");

            migrationBuilder.CreateIndex(
                name: "IX_products_CategoryId",
                table: "products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_user_RolesId",
                table: "user",
                column: "RolesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "invoice_Details");

            migrationBuilder.DropTable(
                name: "product_Details");

            migrationBuilder.DropTable(
                name: "invoice");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
