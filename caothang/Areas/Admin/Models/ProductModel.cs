using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace caothang.Areas.Admin.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string Desciption { get; set; }
        public string Image { get; set; }
        public int Quantity { get; set; }
        public Decimal Price { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public CategoryModel category { get; set; }
        public ICollection<Product_DetailsModel> product_detail { get; set; }
        public ICollection<GalleryImageModel> GalleryImage { get; set; }
        public ICollection<InvoiceModel> invoices { get; set; }
        public bool Status { get; set; }
    }
}
