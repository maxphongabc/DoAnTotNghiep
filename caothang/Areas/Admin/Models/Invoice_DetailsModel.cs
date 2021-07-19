using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace caothang.Areas.Admin.Models
{
    public class Invoice_DetailsModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int InvoiceId { get; set; }
        public int Quantity { get; set; }
        public Decimal Price { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public ProductModel product { get; set; }
        public InvoiceModel invoice { get; set; }
        public bool Status { get; set; }
    }
}
