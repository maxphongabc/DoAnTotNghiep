using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Models
{
    public class BlogViewModel
    {
        public int BlogId { get; set; }
        public string Slug { get; set; }
        public string SlugCate { get; set; }
        public string Title { get; set; }
        public string Brief { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public string UserImage { get; set; }
        public DateTime PostedDate { get; set; }
        public string Cate_post { get; set; }
        public string UserName { get; set; }
        public bool Status { get; set; }
    }
}
