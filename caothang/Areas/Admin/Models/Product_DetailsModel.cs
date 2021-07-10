using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace caothang.Areas.Admin.Models
{
    public class Product_DetailsModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Model { get; set; }
        public string CPU { get; set; }
        public string GPU { get; set; }
        public string Ram { get; set; }
        public string Rom { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public ProductModel products { get; set; }
        public bool Status { get; set; }
    }
}
