using Common.Model;

namespace Project.Models
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public string Slug { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public float Total { get { return Quantity * Price; } }
        public string Image { get; set; }

        public CartItem()
        {
        }

        public CartItem(ProductModel product)
        {
            ProductId = product.Id;
            ProductName = product.Name;
            Price = product.Price;
            Quantity = 1;
            Image = product.Image;
        }
    }
}
