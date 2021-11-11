using System;

namespace Common.Model
{
    public class WishListModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public DateTime? CreateOn { get; set; }
        public virtual ProductModel Product { get; set; }
        public virtual UserModel User { get; set; }
    }
}
