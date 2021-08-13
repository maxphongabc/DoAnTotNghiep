using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Catename { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
