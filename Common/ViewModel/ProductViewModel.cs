using System;

namespace Common.ViewModel
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public int WishListId { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public DateTime? CreateOn { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string Model { get; set; }
        public string System { get; set; }
        public string Image { get; set; }
        public string NameCate { get; set; }
        public string SlugCate { get; set; }
        public bool Status { get; set; }
    }
}
