using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Common.Migrations
{
    public partial class addcolumn_cmb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentBlogModel_blogs_blogsId",
                table: "CommentBlogModel");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentBlogModel_user_usersId",
                table: "CommentBlogModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentBlogModel",
                table: "CommentBlogModel");

            migrationBuilder.RenameTable(
                name: "CommentBlogModel",
                newName: "commentBlogs");

            migrationBuilder.RenameIndex(
                name: "IX_CommentBlogModel_usersId",
                table: "commentBlogs",
                newName: "IX_commentBlogs_usersId");

            migrationBuilder.RenameIndex(
                name: "IX_CommentBlogModel_blogsId",
                table: "commentBlogs",
                newName: "IX_commentBlogs_blogsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_commentBlogs",
                table: "commentBlogs",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 11, 48, 34, 304, DateTimeKind.Local).AddTicks(2520));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 11, 48, 34, 306, DateTimeKind.Local).AddTicks(4415));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 11, 48, 34, 306, DateTimeKind.Local).AddTicks(4503));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 11, 48, 34, 306, DateTimeKind.Local).AddTicks(4511));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 11, 48, 34, 306, DateTimeKind.Local).AddTicks(4513));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 11, 48, 34, 306, DateTimeKind.Local).AddTicks(4518));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 11, 48, 34, 306, DateTimeKind.Local).AddTicks(4523));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 11, 48, 34, 306, DateTimeKind.Local).AddTicks(4525));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 11, 48, 34, 306, DateTimeKind.Local).AddTicks(4529));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 11, 48, 34, 306, DateTimeKind.Local).AddTicks(4533));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 11, 48, 34, 306, DateTimeKind.Local).AddTicks(4537));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 11, 48, 34, 306, DateTimeKind.Local).AddTicks(4542));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 11, 48, 34, 307, DateTimeKind.Local).AddTicks(6915));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 11, 48, 34, 307, DateTimeKind.Local).AddTicks(9017));

            migrationBuilder.AddForeignKey(
                name: "FK_commentBlogs_blogs_blogsId",
                table: "commentBlogs",
                column: "blogsId",
                principalTable: "blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_commentBlogs_user_usersId",
                table: "commentBlogs",
                column: "usersId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_commentBlogs_blogs_blogsId",
                table: "commentBlogs");

            migrationBuilder.DropForeignKey(
                name: "FK_commentBlogs_user_usersId",
                table: "commentBlogs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_commentBlogs",
                table: "commentBlogs");

            migrationBuilder.RenameTable(
                name: "commentBlogs",
                newName: "CommentBlogModel");

            migrationBuilder.RenameIndex(
                name: "IX_commentBlogs_usersId",
                table: "CommentBlogModel",
                newName: "IX_CommentBlogModel_usersId");

            migrationBuilder.RenameIndex(
                name: "IX_commentBlogs_blogsId",
                table: "CommentBlogModel",
                newName: "IX_CommentBlogModel_blogsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentBlogModel",
                table: "CommentBlogModel",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 11, 31, 18, 317, DateTimeKind.Local).AddTicks(4315));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 11, 31, 18, 319, DateTimeKind.Local).AddTicks(2066));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 11, 31, 18, 319, DateTimeKind.Local).AddTicks(2132));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 11, 31, 18, 319, DateTimeKind.Local).AddTicks(2136));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 11, 31, 18, 319, DateTimeKind.Local).AddTicks(2172));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 11, 31, 18, 319, DateTimeKind.Local).AddTicks(2175));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 11, 31, 18, 319, DateTimeKind.Local).AddTicks(2178));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 11, 31, 18, 319, DateTimeKind.Local).AddTicks(2180));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 11, 31, 18, 319, DateTimeKind.Local).AddTicks(2183));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 11, 31, 18, 319, DateTimeKind.Local).AddTicks(2377));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 11, 31, 18, 319, DateTimeKind.Local).AddTicks(2402));

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 11, 31, 18, 319, DateTimeKind.Local).AddTicks(2408));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 11, 31, 18, 320, DateTimeKind.Local).AddTicks(4157));

            migrationBuilder.UpdateData(
                table: "user",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 11, 6, 11, 31, 18, 320, DateTimeKind.Local).AddTicks(6336));

            migrationBuilder.AddForeignKey(
                name: "FK_CommentBlogModel_blogs_blogsId",
                table: "CommentBlogModel",
                column: "blogsId",
                principalTable: "blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentBlogModel_user_usersId",
                table: "CommentBlogModel",
                column: "usersId",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
