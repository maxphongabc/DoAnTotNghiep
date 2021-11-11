using System;
using System.Collections.Generic;

namespace Common.Model
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public double Total { get; set; }
        public string ShipName { get; set; }
        public string ShipPhone { get; set; }
        public string ShipEmail { get; set; }
        public string ShipAdress { get; set; }
        public string Description { get; set; }
        public ICollection<Order_DetailsModel> order_Details { get; set; }
        public ICollection <CommentProduct> commentproducts { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool Status { get; set; }
        public virtual UserModel user { get; set; }
    }
}
