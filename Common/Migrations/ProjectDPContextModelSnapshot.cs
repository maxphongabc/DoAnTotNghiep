﻿// <auto-generated />
using System;
using Common.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Common.Migrations
{
    [DbContext(typeof(ProjectDPContext))]
    partial class ProjectDPContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Common.Model.BlogModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Brief")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Category_PostId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PostedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Slug")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Category_PostId");

                    b.HasIndex("UserId");

                    b.ToTable("blogs");
                });

            modelBuilder.Entity("Common.Model.CategoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slug")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sorting")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "PlayStaion 4",
                            Slug = "playstation-4",
                            Sorting = 0,
                            Status = true
                        },
                        new
                        {
                            Id = 2,
                            Name = "Xbox One S",
                            Slug = "xbox-one-s",
                            Sorting = 0,
                            Status = true
                        },
                        new
                        {
                            Id = 3,
                            Name = "Nintendo Switch",
                            Slug = "nintendo-switch",
                            Sorting = 0,
                            Status = true
                        });
                });

            modelBuilder.Entity("Common.Model.Category_PostModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slug")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("category_Posts");
                });

            modelBuilder.Entity("Common.Model.CommentProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdProduct")
                        .HasColumnType("int");

                    b.Property<int>("IdUser")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("commentsproduct");
                });

            modelBuilder.Entity("Common.Model.OrderModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShipAdress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShipEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShipName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShipPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<float>("Total")
                        .HasColumnType("real");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("order");
                });

            modelBuilder.Entity("Common.Model.Order_DetailsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("order_Details");
                });

            modelBuilder.Entity("Common.Model.ProductModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("ProducerId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Slug")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("System")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreatedOn = new DateTime(2021, 11, 1, 12, 39, 21, 160, DateTimeKind.Local).AddTicks(4714),
                            Description = "Đẹp",
                            Image = "c7b94b6a-6f03-407d-8aff-19b5da5aa199_ps4-slim-1-00-700x700.jpg",
                            Model = "P12498S1",
                            Name = "PlayStation 4 Slim 1TB",
                            Price = 9180000,
                            ProducerId = 0,
                            Quantity = 50,
                            Slug = "playstation-4-slim-1tb",
                            Status = true
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            CreatedOn = new DateTime(2021, 11, 1, 12, 39, 21, 161, DateTimeKind.Local).AddTicks(5923),
                            Description = "Đẹp",
                            Image = "6f4b42c9-2539-4b8d-a0ae-7106202ce538_ps4-pro-monster-hunter-world-41-700x700.jpg",
                            Name = "PS4 Slim 1TB",
                            Price = 7800000,
                            ProducerId = 0,
                            Quantity = 50,
                            Slug = "ps4-slim-1tb",
                            Status = true
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            CreatedOn = new DateTime(2021, 11, 1, 12, 39, 21, 161, DateTimeKind.Local).AddTicks(5950),
                            Description = "Đẹp",
                            Image = "c5996329-9c51-4d4b-ac45-1998d785181c_ps4-2015-44-700x700.jpg",
                            Name = "Sony PS4 Slim Days Of Play 2019 Limited Edition",
                            Price = 4800000,
                            ProducerId = 0,
                            Quantity = 50,
                            Slug = "sony-ps4-slim-days-of-play-2019-limited-edition",
                            Status = true
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 1,
                            CreatedOn = new DateTime(2021, 11, 1, 12, 39, 21, 161, DateTimeKind.Local).AddTicks(5956),
                            Description = "Đẹp",
                            Image = "fe2663d3-e87c-4213-a998-8a362420e7a6_ps4-pro-white-cu-00-700x700.jpg",
                            Name = "PS4 Pro 2nd hand",
                            Price = 9300000,
                            ProducerId = 0,
                            Quantity = 50,
                            Slug = "ps4-pro-2nd-hand",
                            Status = true
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            CreatedOn = new DateTime(2021, 11, 1, 12, 39, 21, 161, DateTimeKind.Local).AddTicks(5960),
                            Description = "Đẹp",
                            Image = "e1f498e5-8386-4221-b9ac-6f5cd7acea80_ps4-pro-god-of-war-limited-edition-44-700x700.jpg",
                            Name = "Xbox Series X",
                            Price = 8800000,
                            ProducerId = 0,
                            Quantity = 50,
                            Slug = "xbox-series-x",
                            Status = true
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 2,
                            CreatedOn = new DateTime(2021, 11, 1, 12, 39, 21, 161, DateTimeKind.Local).AddTicks(5962),
                            Description = "Đẹp",
                            Image = "6d9b947a-8d78-4a34-91a6-20c96a37395a_xbox-series-x-00-700x700.jpg",
                            Name = "Xbox Series X",
                            Price = 19300000,
                            ProducerId = 0,
                            Quantity = 50,
                            Slug = "xbox-series-x",
                            Status = true
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 2,
                            CreatedOn = new DateTime(2021, 11, 1, 12, 39, 21, 161, DateTimeKind.Local).AddTicks(5965),
                            Description = "Đẹp",
                            Image = "9cbed2a6-203e-41fa-a5d5-e17377089d46_xbox-series-s-41-700x700.jpg",
                            Name = "Xbox Series X",
                            Price = 11800000,
                            ProducerId = 0,
                            Quantity = 50,
                            Slug = "xbox-series-x",
                            Status = true
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 2,
                            CreatedOn = new DateTime(2021, 11, 1, 12, 39, 21, 161, DateTimeKind.Local).AddTicks(5968),
                            Description = "Đẹp",
                            Image = "852dfd15-3d2f-49bd-b34e-cae9407ea211_nintendo-switch-oled-white-joy-con-41-700x700.jpg",
                            Name = "Xbox Series S",
                            Price = 9800000,
                            ProducerId = 0,
                            Quantity = 50,
                            Slug = "xbox-series-s",
                            Status = true
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 3,
                            CreatedOn = new DateTime(2021, 11, 1, 12, 39, 21, 161, DateTimeKind.Local).AddTicks(5971),
                            Description = "Đẹp",
                            Image = "5a62915a-2995-4115-854c-aed29d98c352_nintendo-switch-oled-red-blue-joy-con-41-700x700.jpg",
                            Name = "Nintendo Switch V2 Màu Neon",
                            Price = 9800000,
                            ProducerId = 0,
                            Quantity = 50,
                            Slug = "nintendo-switch-v2-mau-neon",
                            Status = true
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 3,
                            CreatedOn = new DateTime(2021, 11, 1, 12, 39, 21, 161, DateTimeKind.Local).AddTicks(5973),
                            Description = "Đẹp",
                            Image = "92013fe8-793b-4f08-8bf1-bad4bb53e66e_nintendo-switch-neon-joy-con-45-700x700.jpg",
                            Name = "Nintendo Switch Lite - Màu Blue",
                            Price = 7080000,
                            ProducerId = 0,
                            Quantity = 50,
                            Slug = "nintendo-switch-lite-mau-blue",
                            Status = true
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 3,
                            CreatedOn = new DateTime(2021, 11, 1, 12, 39, 21, 161, DateTimeKind.Local).AddTicks(5977),
                            Description = "Đẹp",
                            Image = "86236c3c-1dbe-4ab2-85b0-f892a37413c0_nintendo-switch-gray-joy-con-45-700x700.jpg",
                            Name = "Nintendo Switch Fortnite Special Edition",
                            Price = 6880000,
                            ProducerId = 0,
                            Quantity = 50,
                            Slug = "nintendo-switch-fortnite-special-edition",
                            Status = true
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 3,
                            CreatedOn = new DateTime(2021, 11, 1, 12, 39, 21, 161, DateTimeKind.Local).AddTicks(5981),
                            Description = "Đẹp",
                            Image = "e660c20e-9450-472f-ae39-40284f3379ff_nintendo-switch-animal-crossing-horizon-42-700x700.jpg",
                            Name = "Nintendo Switch Animal Crossing",
                            Price = 7380000,
                            ProducerId = 0,
                            Quantity = 50,
                            Slug = "nintendo-switch-animal-crossing",
                            Status = true
                        });
                });

            modelBuilder.Entity("Common.Model.RolesModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin",
                            Status = true
                        },
                        new
                        {
                            Id = 2,
                            Name = "User",
                            Status = true
                        });
                });

            modelBuilder.Entity("Common.Model.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Avarta")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassWord")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RolesId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RolesId");

                    b.ToTable("user");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "115 Trần Xuân Soạn",
                            Avarta = "user-1.png",
                            CreatedOn = new DateTime(2021, 11, 1, 12, 39, 21, 162, DateTimeKind.Local).AddTicks(2023),
                            Email = "duyvo049@gmail.com",
                            FullName = "Võ Thành Duy",
                            PassWord = "25f9e794323b453885f5181f1b624d0b",
                            Phone = "0393030574",
                            RolesId = 1,
                            Status = true,
                            UserName = "thanhduy"
                        },
                        new
                        {
                            Id = 2,
                            Address = "115 Trần Xuân Soạn",
                            Avarta = "user-2.png",
                            CreatedOn = new DateTime(2021, 11, 1, 12, 39, 21, 162, DateTimeKind.Local).AddTicks(3713),
                            Email = "leloc603@gmail.com",
                            FullName = "Lê Xuân Lộc",
                            PassWord = "25f9e794323b453885f5181f1b624d0b",
                            Phone = "0393030574",
                            RolesId = 2,
                            Status = true,
                            UserName = "leloc"
                        });
                });

            modelBuilder.Entity("Common.Model.WishListModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("wistlists");
                });

            modelBuilder.Entity("Common.Model.BlogModel", b =>
                {
                    b.HasOne("Common.Model.Category_PostModel", "Category_Post")
                        .WithMany("blogs")
                        .HasForeignKey("Category_PostId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Common.Model.UserModel", "User")
                        .WithMany("blogs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category_Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Common.Model.CommentProduct", b =>
                {
                    b.HasOne("Common.Model.ProductModel", "Product")
                        .WithMany("commentProducts")
                        .HasForeignKey("ProductId");

                    b.HasOne("Common.Model.UserModel", "User")
                        .WithMany("commentProducts")
                        .HasForeignKey("UserId");

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Common.Model.OrderModel", b =>
                {
                    b.HasOne("Common.Model.UserModel", "user")
                        .WithMany("orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("Common.Model.Order_DetailsModel", b =>
                {
                    b.HasOne("Common.Model.OrderModel", "order")
                        .WithMany("order_Details")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Common.Model.ProductModel", "product")
                        .WithMany("orderDetails")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("order");

                    b.Navigation("product");
                });

            modelBuilder.Entity("Common.Model.ProductModel", b =>
                {
                    b.HasOne("Common.Model.CategoryModel", "category")
                        .WithMany("products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");
                });

            modelBuilder.Entity("Common.Model.UserModel", b =>
                {
                    b.HasOne("Common.Model.RolesModel", "roles")
                        .WithMany("user")
                        .HasForeignKey("RolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("roles");
                });

            modelBuilder.Entity("Common.Model.WishListModel", b =>
                {
                    b.HasOne("Common.Model.ProductModel", "Product")
                        .WithMany("wishLists")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Common.Model.UserModel", "User")
                        .WithMany("wishLists")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Common.Model.CategoryModel", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("Common.Model.Category_PostModel", b =>
                {
                    b.Navigation("blogs");
                });

            modelBuilder.Entity("Common.Model.OrderModel", b =>
                {
                    b.Navigation("order_Details");
                });

            modelBuilder.Entity("Common.Model.ProductModel", b =>
                {
                    b.Navigation("commentProducts");

                    b.Navigation("orderDetails");

                    b.Navigation("wishLists");
                });

            modelBuilder.Entity("Common.Model.RolesModel", b =>
                {
                    b.Navigation("user");
                });

            modelBuilder.Entity("Common.Model.UserModel", b =>
                {
                    b.Navigation("blogs");

                    b.Navigation("commentProducts");

                    b.Navigation("orders");

                    b.Navigation("wishLists");
                });
#pragma warning restore 612, 618
        }
    }
}
