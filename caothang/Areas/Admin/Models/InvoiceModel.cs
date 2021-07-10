using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace caothang.Areas.Admin.Models
{
    public class InvoiceModel
    {
        public int Id { get; set; }
        public int Total { get; set; }
        public string Description { get; set; }
        public ICollection<Invoice_DetailsModel> invoice_Details { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool Status { get; set; }
    }
}
