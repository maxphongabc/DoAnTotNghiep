using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Model
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public float Total { get; set; }
        public string ShipName { get; set; }
        public string ShipPhone { get; set; }
        public string ShipEmail { get; set; }
        public string ShipAdress { get; set; }
        public string Description { get; set; }
        public ICollection<Order_DetailsModel> order_Details { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool Status { get; set; }
        public virtual UserModel user { get; set; }
    }
}
