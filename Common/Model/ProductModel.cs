
using Common.Infrastructure;
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
        public string Model { get; set; }
        public string System { get; set; }
        public string Image { get; set; }
        [NotMapped]
        [FileExtension]
        public IFormFile ImageUpload { get; set; }
        public DateTime? CreatedOn { get; set; }
        [ForeignKey("CategoryId")]
        public virtual CategoryModel category { get; set; }
        public ICollection<Order_DetailsModel> orderDetails { get; set; }
        public ICollection<CommentProduct> commentProducts { get; set; }
        public ICollection<WishListModel> wishLists { get; set; }
        public bool Status { get; set; }
    }

}
