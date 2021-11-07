using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ViewModel
{
    public class CommentBlogViewModel
    {
        public int CommentId { get; set; }
        public int BlogsId { get; set; }
        public int UserId { get; set; }
        public string Image { get; set; }
        public string UserImage { get; set; }
        public string BlogTitle { get; set; }
        public DateTime CreateOn { get; set; }
        public string Content { get; set; }
        public string UserName { get; set; }
        public bool Status { get; set; }
    }
}
