using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.Migrations
{
    public partial class initial : Migration
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
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sorting = table.Column<int>(type: "int", nullable: false),
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
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    PriceOld = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoreImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "gallery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gallery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_gallery_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<float>(type: "real", nullable: false),
                    ShipName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShipPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShipEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShipAdress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    ProductModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_order_products_ProductModelId",
                        column: x => x.ProductModelId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_order_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order_Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    orderId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_order_Details_order_orderId",
                        column: x => x.orderId,
                        principalTable: "order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_order_Details_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "Name", "Slug", "Sorting", "Status" },
                values: new object[,]
                {
                    { 1, "PlayStaion 4", null, 0, true },
                    { 2, "Xbox One S", null, 0, true },
                    { 3, "Nintendo Switch", null, 0, true }
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
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Description", "Image", "MoreImage", "Name", "Price", "PriceOld", "Quantity", "Slug", "Status", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 10, 8, 10, 32, 10, 702, DateTimeKind.Local).AddTicks(9622), "Đẹp", "Máy PS4 Pro The Last Of Us 2 Limited Edition.jpg", null, "PS4 Pro The Last Of Us 2 Limited Edition", 299, 0, 50, null, true, null },
                    { 2, 1, new DateTime(2021, 10, 8, 10, 32, 10, 706, DateTimeKind.Local).AddTicks(2527), "Đẹp", "Máy PS4 Slim 1TB.jpg", null, "PS4 Slim 1TB", 299, 0, 50, null, true, null },
                    { 3, 1, new DateTime(2021, 10, 8, 10, 32, 10, 706, DateTimeKind.Local).AddTicks(2569), "Đẹp", "Máy PS4 Pro The Last Of Us 2 Limited Edition.jpg", null, "Sony PS4 Slim Days Of Play 2019 Limited Edition", 299, 0, 50, null, true, null },
                    { 4, 1, new DateTime(2021, 10, 8, 10, 32, 10, 706, DateTimeKind.Local).AddTicks(2573), "Đẹp", "PS4 Pro 2nd hand.jpg", null, "PS4 Pro 2nd hand", 299, 0, 50, null, true, null },
                    { 5, 2, new DateTime(2021, 10, 8, 10, 32, 10, 706, DateTimeKind.Local).AddTicks(2575), "Đẹp", "PS4 Pro 2nd hand.jpg", null, "Xbox Series X", 299, 0, 50, null, true, null },
                    { 6, 2, new DateTime(2021, 10, 8, 10, 32, 10, 706, DateTimeKind.Local).AddTicks(2577), "Đẹp", "Xbox Series X.jpg", null, "Xbox Series X", 299, 0, 50, null, true, null },
                    { 7, 2, new DateTime(2021, 10, 8, 10, 32, 10, 706, DateTimeKind.Local).AddTicks(2579), "Đẹp", "Xbox Series X.jpg", null, "Xbox Series X", 299, 0, 50, null, true, null },
                    { 8, 2, new DateTime(2021, 10, 8, 10, 32, 10, 706, DateTimeKind.Local).AddTicks(2581), "Đẹp", "Xbox Series S.jpg", null, "Xbox Series S", 299, 0, 50, null, true, null },
                    { 9, 3, new DateTime(2021, 10, 8, 10, 32, 10, 706, DateTimeKind.Local).AddTicks(2583), "Đẹp", "Máy Nintendo Switch V2 Màu Neon.jpg", null, "Nintendo Switch V2 Màu Neon", 299, 0, 50, null, true, null },
                    { 10, 3, new DateTime(2021, 10, 8, 10, 32, 10, 706, DateTimeKind.Local).AddTicks(2585), "Đẹp", "Máy Nintendo Switch Lite - Màu Blue.jpg", null, "Nintendo Switch Lite - Màu Blue", 299, 0, 50, null, true, null },
                    { 11, 3, new DateTime(2021, 10, 8, 10, 32, 10, 706, DateTimeKind.Local).AddTicks(2587), "Đẹp", "Máy Nintendo Switch Fortnite Special Edition.jpg", null, "Nintendo Switch Fortnite Special Edition", 299, 0, 50, null, true, null },
                    { 12, 3, new DateTime(2021, 10, 8, 10, 32, 10, 706, DateTimeKind.Local).AddTicks(2589), "Đẹp", "Máy Nintendo Switch Animal Crossing.jpg", null, "Nintendo Switch Animal Crossing", 299, 0, 50, null, true, null }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "Address", "Avarta", "CreatedOn", "DateOfBirth", "Email", "FullName", "PassWord", "Phone", "RolesId", "Status", "UpdatedOn", "UserName" },
                values: new object[,]
                {
                    { 1, "115 Trần Xuân Soạn", "user-1.png", new DateTime(2021, 10, 8, 10, 32, 10, 706, DateTimeKind.Local).AddTicks(9167), null, "duyvo049@gmail.com", "Võ Thành Duy", "25f9e794323b453885f5181f1b624d0b", "0393030574", 1, true, null, "thanhduy" },
                    { 2, "115 Trần Xuân Soạn", "user-2.png", new DateTime(2021, 10, 8, 10, 32, 10, 707, DateTimeKind.Local).AddTicks(247), null, "leloc603@gmail.com", "Lê Xuân Lộc", "25f9e794323b453885f5181f1b624d0b", "0393030574", 2, true, null, "leloc" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_gallery_ProductId",
                table: "gallery",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_order_ProductModelId",
                table: "order",
                column: "ProductModelId");

            migrationBuilder.CreateIndex(
                name: "IX_order_UserId",
                table: "order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_order_Details_orderId",
                table: "order_Details",
                column: "orderId");

            migrationBuilder.CreateIndex(
                name: "IX_order_Details_ProductId",
                table: "order_Details",
                column: "ProductId");

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
                name: "gallery");

            migrationBuilder.DropTable(
                name: "order_Details");

            migrationBuilder.DropTable(
                name: "order");

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
