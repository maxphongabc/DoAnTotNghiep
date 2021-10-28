using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Common.Model
{
    public class Order_DetailsModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int InvoiceId { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public DateTime? CreatedOn { get; set; }
        public ProductModel product { get; set; }
        public OrderModel order { get; set; }
        public bool Status { get; set; }
    }
}
