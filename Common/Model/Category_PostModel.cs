using System.Collections.Generic;

namespace Common.Model
{
    public class Category_PostModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public bool Status { get; set; }
        public ICollection<BlogModel> blogs { get; set; }
    }
}
