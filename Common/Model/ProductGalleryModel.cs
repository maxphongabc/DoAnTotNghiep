using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class ProductGalleryModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Url { get; set; }
        public ProductModel product { get; set; }
    }
}
