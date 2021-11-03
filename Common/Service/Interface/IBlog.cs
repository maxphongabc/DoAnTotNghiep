using Common.Model;
using Common.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Service.Interface
{
    public interface IBlog
    {
        List<BlogViewModel> ListAll();
        BlogViewModel DetailsBlog(string slug);
        List<BlogViewModel> ListBlogCate(string slug);
        List<BlogModel> ListRelatedBlog(int id);
    }
}
