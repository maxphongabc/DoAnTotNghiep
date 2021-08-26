
using Common.Infrastructure;
using Common.VIewModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Model
{ 
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int CategoryId { get; set; }
        public string Description { get; set; }  
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int PriceOld { get; set; }
        public string Image { get; set; }
        [NotMapped]
        [FileExtension]
        public IFormFile ImageUpload { get; set; }       
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public CategoryModel category { get; set; }
        public ICollection<OrderModel> orders { get; set; }
        public ICollection<ProductGalleryModel> productGalleries { get; set; }
        public bool Status { get; set; }
    }

}
