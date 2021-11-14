using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.Migrations
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
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Icon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "category_Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "feedbacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_feedbacks", x => x.Id);
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
                name: "TransactStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactStatuses", x => x.Id);
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
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    System = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Avarta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassWord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                name: "blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category_PostId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Brief = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_blogs_category_Posts_Category_PostId",
                        column: x => x.Category_PostId,
                        principalTable: "category_Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_blogs_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
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
                    Total = table.Column<double>(type: "float", nullable: false),
                    ShipName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShipPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShipEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShipAdress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactStatusId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ShipDateOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_order_TransactStatuses_TransactStatusId",
                        column: x => x.TransactStatusId,
                        principalTable: "TransactStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "wistlists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CreateOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_wistlists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_wistlists_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_wistlists_user_UserId",
                        column: x => x.UserId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "commentsproduct",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreateOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    productsId = table.Column<int>(type: "int", nullable: true),
                    cmtId = table.Column<int>(type: "int", nullable: true),
                    usersId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    OrderModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_commentsproduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_commentsproduct_commentsproduct_cmtId",
                        column: x => x.cmtId,
                        principalTable: "commentsproduct",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_commentsproduct_order_OrderModelId",
                        column: x => x.OrderModelId,
                        principalTable: "order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_commentsproduct_products_productsId",
                        column: x => x.productsId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_commentsproduct_user_usersId",
                        column: x => x.usersId,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "order_Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_order_Details_order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_Details_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TransactStatuses",
                columns: new[] { "Id", "Description", "Name", "Status" },
                values: new object[,]
                {
                    { 1, "Chờ Admin xác nhận đơn hàng", "Đang xác nhận", true },
                    { 2, "Admin xác nhận đơn hàng và đang giao hàng", "Đang giao hàng", true },
                    { 3, "Đơn hàng hoàn tất", "Giao hàng thành công", true },
                    { 4, "Đơn hàng đã hủy", "Hủy", true }
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "Icon", "Name", "Slug", "Status" },
                values: new object[,]
                {
                    { 1, null, "PlayStaion 4", "playstation-4", true },
                    { 2, null, "Xbox One S", "xbox-one-s", true },
                    { 3, null, "Nintendo Switch", "nintendo-switch", true }
                });

            migrationBuilder.InsertData(
                table: "category_Posts",
                columns: new[] { "Id", "Name", "Slug", "Status" },
                values: new object[,]
                {
                    { 1, "Tin mới", "tin-mới", true },
                    { 2, "Sửa chữa", "sửa-chữa", true },
                    { 3, "Hướng dẫn sử dụng Xbox", "hướng-dẫn-sử-dụng-xbox", true }
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
                columns: new[] { "Id", "CategoryId", "CreatedOn", "Description", "Image", "Model", "Name", "Price", "Quantity", "Slug", "Status", "System" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 11, 14, 19, 32, 48, 128, DateTimeKind.Local).AddTicks(907), "Đẹp", "c7b94b6a-6f03-407d-8aff-19b5da5aa199_ps4-slim-1-00-700x700.jpg", "P12498S1", "PlayStation 4 Slim 1TB", 9180000, 50, "playstation-4-slim-1tb", true, null },
                    { 2, 1, new DateTime(2021, 11, 14, 19, 32, 48, 137, DateTimeKind.Local).AddTicks(6148), "Đẹp", "6f4b42c9-2539-4b8d-a0ae-7106202ce538_ps4-pro-monster-hunter-world-41-700x700.jpg", null, "PS4 Slim 1TB", 7800000, 50, "ps4-slim-1tb", true, null },
                    { 3, 1, new DateTime(2021, 11, 14, 19, 32, 48, 137, DateTimeKind.Local).AddTicks(6226), "Đẹp", "c5996329-9c51-4d4b-ac45-1998d785181c_ps4-2015-44-700x700.jpg", null, "Sony PS4 Slim Days Of Play 2019 Limited Edition", 4800000, 50, "sony-ps4-slim-days-of-play-2019-limited-edition", true, null },
                    { 4, 1, new DateTime(2021, 11, 14, 19, 32, 48, 137, DateTimeKind.Local).AddTicks(6232), "Đẹp", "fe2663d3-e87c-4213-a998-8a362420e7a6_ps4-pro-white-cu-00-700x700.jpg", null, "PS4 Pro 2nd hand", 9300000, 50, "ps4-pro-2nd-hand", true, null },
                    { 7, 2, new DateTime(2021, 11, 14, 19, 32, 48, 137, DateTimeKind.Local).AddTicks(6235), "Đẹp", "9cbed2a6-203e-41fa-a5d5-e17377089d46_xbox-series-s-41-700x700.jpg", null, "Xbox Series X", 11800000, 50, "xbox-series-x", true, null },
                    { 8, 2, new DateTime(2021, 11, 14, 19, 32, 48, 137, DateTimeKind.Local).AddTicks(6238), "Đẹp", "852dfd15-3d2f-49bd-b34e-cae9407ea211_nintendo-switch-oled-white-joy-con-41-700x700.jpg", null, "Xbox Series S", 9800000, 50, "xbox-series-s", true, null },
                    { 9, 3, new DateTime(2021, 11, 14, 19, 32, 48, 137, DateTimeKind.Local).AddTicks(6241), "Đẹp", "5a62915a-2995-4115-854c-aed29d98c352_nintendo-switch-oled-red-blue-joy-con-41-700x700.jpg", null, "Nintendo Switch V2 Màu Neon", 9800000, 50, "nintendo-switch-v2-mau-neon", true, null },
                    { 10, 3, new DateTime(2021, 11, 14, 19, 32, 48, 137, DateTimeKind.Local).AddTicks(6244), "Đẹp", "92013fe8-793b-4f08-8bf1-bad4bb53e66e_nintendo-switch-neon-joy-con-45-700x700.jpg", null, "Nintendo Switch Lite - Màu Blue", 7080000, 50, "nintendo-switch-lite-mau-blue", true, null }
                });

            migrationBuilder.InsertData(
                table: "user",
                columns: new[] { "Id", "Address", "Avarta", "CreatedOn", "Email", "FullName", "PassWord", "Phone", "RolesId", "Status", "UserName" },
                values: new object[,]
                {
                    { 1, "115 Trần Xuân Soạn", "user-1.png", new DateTime(2021, 11, 14, 19, 32, 48, 138, DateTimeKind.Local).AddTicks(5905), "duyvo049@gmail.com", "Võ Thành Duy", "25f9e794323b453885f5181f1b624d0b", "0393030574", 1, true, "thanhduy" },
                    { 2, "115 Trần Xuân Soạn", "user-2.png", new DateTime(2021, 11, 14, 19, 32, 48, 138, DateTimeKind.Local).AddTicks(8038), "leloc603@gmail.com", "Lê Xuân Lộc", "25f9e794323b453885f5181f1b624d0b", "0393030574", 2, true, "leloc" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_blogs_Category_PostId",
                table: "blogs",
                column: "Category_PostId");

            migrationBuilder.CreateIndex(
                name: "IX_blogs_UserId",
                table: "blogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_commentsproduct_cmtId",
                table: "commentsproduct",
                column: "cmtId");

            migrationBuilder.CreateIndex(
                name: "IX_commentsproduct_OrderModelId",
                table: "commentsproduct",
                column: "OrderModelId");

            migrationBuilder.CreateIndex(
                name: "IX_commentsproduct_productsId",
                table: "commentsproduct",
                column: "productsId");

            migrationBuilder.CreateIndex(
                name: "IX_commentsproduct_usersId",
                table: "commentsproduct",
                column: "usersId");

            migrationBuilder.CreateIndex(
                name: "IX_order_TransactStatusId",
                table: "order",
                column: "TransactStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_order_UserId",
                table: "order",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_order_Details_OrderId",
                table: "order_Details",
                column: "OrderId");

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

            migrationBuilder.CreateIndex(
                name: "IX_wistlists_ProductId",
                table: "wistlists",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_wistlists_UserId",
                table: "wistlists",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "blogs");

            migrationBuilder.DropTable(
                name: "commentsproduct");

            migrationBuilder.DropTable(
                name: "feedbacks");

            migrationBuilder.DropTable(
                name: "order_Details");

            migrationBuilder.DropTable(
                name: "wistlists");

            migrationBuilder.DropTable(
                name: "category_Posts");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "TransactStatuses");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
