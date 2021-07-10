using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace caothang.Areas.Admin.Models
{
    public class GalleryImageModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Image { get; set; }
        public ProductModel products { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool Status { get; set; }
    }
}
