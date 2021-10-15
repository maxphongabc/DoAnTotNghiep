
using Common.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            modelBuiler.Entity<ProductModel>().HasData(
                new ProductModel { Id = 1, Name = "PS4 Pro The Last Of Us 2 Limited Edition",Slug="ps4-pro-the-last-of-us-2-limited-edition", CategoryId = 1, Description = "Đẹp", Image = "Máy PS4 Pro The Last Of Us 2 Limited Edition.jpg", Quantity = 50, Price = 299, CreatedOn = DateTime.Now, Status = true },
                new ProductModel { Id = 2, Name = "PS4 Slim 1TB",Slug="ps4-slim-1tb", CategoryId = 1, Description = "Đẹp", Image = "Máy PS4 Slim 1TB.jpg", Quantity = 50, Price = 299, CreatedOn = DateTime.Now, Status = true },
                new ProductModel { Id = 3, Name = "Sony PS4 Slim Days Of Play 2019 Limited Edition",Slug="sony-ps4-slim-days-of-play-2019-limited-edition", CategoryId = 1, Description = "Đẹp", Image = "Máy PS4 Pro The Last Of Us 2 Limited Edition.jpg", Quantity = 50, Price = 299, CreatedOn = DateTime.Now, Status = true },
                new ProductModel { Id = 4, Name = "PS4 Pro 2nd hand",Slug="ps4-pro-2nd-hand", CategoryId = 1, Description = "Đẹp", Image = "PS4 Pro 2nd hand.jpg", Quantity = 50, Price = 299, CreatedOn = DateTime.Now, Status = true },
                new ProductModel { Id = 5, Name = "Xbox Series X",Slug="xbox-series-x", CategoryId = 2, Description = "Đẹp", Image = "PS4 Pro 2nd hand.jpg", Quantity = 50, Price = 299, CreatedOn = DateTime.Now, Status = true },
                new ProductModel { Id = 6, Name = "Xbox Series X",Slug= "xbox-series-x", CategoryId = 2, Description = "Đẹp", Image = "Xbox Series X.jpg", Quantity = 50, Price = 299, CreatedOn = DateTime.Now, Status = true },
                new ProductModel { Id = 7, Name = "Xbox Series X",Slug= "xbox-series-x", CategoryId = 2, Description = "Đẹp", Image = "Xbox Series X.jpg", Quantity = 50, Price = 299, CreatedOn = DateTime.Now, Status = true },
                new ProductModel { Id = 8, Name = "Xbox Series S", Slug = "xbox-series-s", CategoryId = 2, Description = "Đẹp", Image = "Xbox Series S.jpg", Quantity = 50, Price = 299, CreatedOn = DateTime.Now, Status = true },
                new ProductModel { Id = 9, Name = "Nintendo Switch V2 Màu Neon",Slug="nintendo-switch-v2-mau-neon", CategoryId = 3, Description = "Đẹp", Image = "Máy Nintendo Switch V2 Màu Neon.jpg", Quantity = 50, Price = 299, CreatedOn = DateTime.Now, Status = true },
                new ProductModel { Id = 10, Name = "Nintendo Switch Lite - Màu Blue",Slug="nintendo-switch-lite-mau-blue", CategoryId = 3, Description = "Đẹp", Image = "Máy Nintendo Switch Lite - Màu Blue.jpg", Quantity = 50, Price = 299, CreatedOn = DateTime.Now, Status = true },
                new ProductModel { Id = 11, Name = "Nintendo Switch Fortnite Special Edition",Slug="nintendo-switch-fortnite-special-edition", CategoryId = 3, Description = "Đẹp", Image = "Máy Nintendo Switch Fortnite Special Edition.jpg", Quantity = 50, Price = 299, CreatedOn = DateTime.Now, Status = true },
                new ProductModel { Id = 12, Name = "Nintendo Switch Animal Crossing",Slug="nintendo-switch-animal-crossing", CategoryId = 3, Description = "Đẹp", Image = "Máy Nintendo Switch Animal Crossing.jpg", Quantity = 50, Price = 299, CreatedOn = DateTime.Now, Status = true }
                );
            modelBuiler.Entity<UserModel>().HasData(
                new UserModel { Id=1,FullName="Võ Thành Duy",RolesId=1,Address="115 Trần Xuân Soạn",Phone="0393030574",Email="duyvo049@gmail.com",Avarta= "user-1.png",DateOfBirth=null, UserName="thanhduy",PassWord= "25f9e794323b453885f5181f1b624d0b",CreatedOn=DateTime.Now,Status=true },
                new UserModel { Id = 2, FullName = "Lê Xuân Lộc",RolesId=2,Address = "115 Trần Xuân Soạn", Phone = "0393030574", Email = "leloc603@gmail.com", Avarta = "user-2.png", DateOfBirth = null, UserName = "leloc", PassWord = "25f9e794323b453885f5181f1b624d0b", CreatedOn = DateTime.Now, Status = true }
                );
            
        }
    }
}
