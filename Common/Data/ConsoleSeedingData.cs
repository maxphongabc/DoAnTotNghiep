﻿using Common.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace Common.Data
{
    public static class ConsoleSeedingData
    {

        public static void Seed(this ModelBuilder modelBuiler)
        {
            modelBuiler.Entity<RolesModel>().HasData(
                new RolesModel { Id = 1, Name = "Admin", Status = true },
                new RolesModel { Id = 2, Name = "User", Status = true }
                );
            modelBuiler.Entity<CategoryModel>().HasData(
                new CategoryModel { Id=1,Name="PlayStaion 4",Slug="playstation-4",Status=true},
                new CategoryModel { Id=2,Name="Xbox One S",Slug="xbox-one-s",Status=true},
                new CategoryModel { Id=3,Name="Nintendo Switch",Slug="nintendo-switch",Status=true}
                );
            modelBuiler.Entity<Category_PostModel>().HasData(
             new CategoryModel { Id = 1, Name = "Tin mới", Slug = "tin-mới", Status = true },
             new CategoryModel { Id = 2, Name = "Sửa chữa", Slug = "sửa-chữa", Status = true },
             new CategoryModel { Id = 3, Name = "Hướng dẫn sử dụng Xbox", Slug = "hướng-dẫn-sử-dụng-xbox", Status = true }
             );
            modelBuiler.Entity<ProductModel>().HasData(
                new ProductModel { Id = 1, Name = "PlayStation 4 Slim 1TB", Slug = "playstation-4-slim-1tb", CategoryId = 1, Description = "Đẹp", Image = "c7b94b6a-6f03-407d-8aff-19b5da5aa199_ps4-slim-1-00-700x700.jpg",Model= "P12498S1", Quantity = 50, Price = 9180000, CreatedOn = DateTime.Now, Status = true },
                new ProductModel { Id = 2, Name = "PS4 Slim 1TB", Slug = "ps4-slim-1tb", CategoryId = 1, Description = "Đẹp", Image = "6f4b42c9-2539-4b8d-a0ae-7106202ce538_ps4-pro-monster-hunter-world-41-700x700.jpg", Quantity = 50, Price = 7800000, CreatedOn = DateTime.Now, Status = true },
                new ProductModel { Id = 3, Name = "Sony PS4 Slim Days Of Play 2019 Limited Edition", Slug = "sony-ps4-slim-days-of-play-2019-limited-edition", CategoryId = 1, Description = "Đẹp", Image = "c5996329-9c51-4d4b-ac45-1998d785181c_ps4-2015-44-700x700.jpg", Quantity = 50, Price = 4800000, CreatedOn = DateTime.Now, Status = true },
                new ProductModel { Id = 4, Name = "PS4 Pro 2nd hand", Slug = "ps4-pro-2nd-hand", CategoryId = 1, Description = "Đẹp", Image = "fe2663d3-e87c-4213-a998-8a362420e7a6_ps4-pro-white-cu-00-700x700.jpg", Quantity = 50, Price = 9300000, CreatedOn = DateTime.Now, Status = true },
                new ProductModel { Id = 5, Name = "Xbox Series X", Slug = "xbox-series-x", CategoryId = 2, Description = "Đẹp", Image = "e1f498e5-8386-4221-b9ac-6f5cd7acea80_ps4-pro-god-of-war-limited-edition-44-700x700.jpg", Quantity = 50, Price = 8800000, CreatedOn = DateTime.Now, Status = true },
                new ProductModel { Id = 6, Name = "Xbox Series X", Slug = "xbox-series-x", CategoryId = 2, Description = "Đẹp", Image = "6d9b947a-8d78-4a34-91a6-20c96a37395a_xbox-series-x-00-700x700.jpg", Quantity = 50, Price = 19300000, CreatedOn = DateTime.Now, Status = true },
                new ProductModel { Id = 7, Name = "Xbox Series X", Slug = "xbox-series-x", CategoryId = 2, Description = "Đẹp", Image = "9cbed2a6-203e-41fa-a5d5-e17377089d46_xbox-series-s-41-700x700.jpg", Quantity = 50, Price = 11800000, CreatedOn = DateTime.Now, Status = true },
                new ProductModel { Id = 8, Name = "Xbox Series S", Slug = "xbox-series-s", CategoryId = 2, Description = "Đẹp", Image = "852dfd15-3d2f-49bd-b34e-cae9407ea211_nintendo-switch-oled-white-joy-con-41-700x700.jpg", Quantity = 50, Price = 9800000, CreatedOn = DateTime.Now, Status = true },
                new ProductModel { Id = 9, Name = "Nintendo Switch V2 Màu Neon", Slug = "nintendo-switch-v2-mau-neon", CategoryId = 3, Description = "Đẹp", Image = "5a62915a-2995-4115-854c-aed29d98c352_nintendo-switch-oled-red-blue-joy-con-41-700x700.jpg", Quantity = 50, Price = 9800000, CreatedOn = DateTime.Now, Status = true },
                new ProductModel { Id = 10, Name = "Nintendo Switch Lite - Màu Blue", Slug = "nintendo-switch-lite-mau-blue", CategoryId = 3, Description = "Đẹp", Image = "92013fe8-793b-4f08-8bf1-bad4bb53e66e_nintendo-switch-neon-joy-con-45-700x700.jpg", Quantity = 50, Price = 7080000, CreatedOn = DateTime.Now, Status = true },
                new ProductModel { Id = 11, Name = "Nintendo Switch Fortnite Special Edition", Slug = "nintendo-switch-fortnite-special-edition", CategoryId = 3, Description = "Đẹp", Image = "86236c3c-1dbe-4ab2-85b0-f892a37413c0_nintendo-switch-gray-joy-con-45-700x700.jpg", Quantity = 50, Price = 6880000, CreatedOn = DateTime.Now, Status = true },
                new ProductModel { Id = 12, Name = "Nintendo Switch Animal Crossing", Slug = "nintendo-switch-animal-crossing", CategoryId = 3, Description = "Đẹp", Image = "e660c20e-9450-472f-ae39-40284f3379ff_nintendo-switch-animal-crossing-horizon-42-700x700.jpg", Quantity = 50, Price = 7380000, CreatedOn = DateTime.Now, Status = true }
                );
            modelBuiler.Entity<UserModel>().HasData(
                new UserModel { Id=1,FullName="Võ Thành Duy",RolesId=1,Address="115 Trần Xuân Soạn",Phone="0393030574",Email="duyvo049@gmail.com",Avarta= "user-1.png",DateOfBirth=null, UserName="thanhduy",PassWord= "25f9e794323b453885f5181f1b624d0b",CreatedOn=DateTime.Now,Status=true },
                new UserModel { Id = 2, FullName = "Lê Xuân Lộc",RolesId=2,Address = "115 Trần Xuân Soạn", Phone = "0393030574", Email = "leloc603@gmail.com", Avarta = "user-2.png", DateOfBirth = null, UserName = "leloc", PassWord = "25f9e794323b453885f5181f1b624d0b", CreatedOn = DateTime.Now, Status = true }
                );
            
        }
    }
}
