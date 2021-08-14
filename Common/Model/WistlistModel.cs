using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    public class WistlistModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public ICollection<UserModel> users { get; set; }
        public ICollection<ProductModel> productss { get; set; }
    }
}
