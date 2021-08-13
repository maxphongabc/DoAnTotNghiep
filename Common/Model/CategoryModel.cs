
using System.Collections.Generic;

namespace Common.Model
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProductModel> products { get; set; }
        public bool Status { get; set; }
    }
}
