using Common.Model;
using Common.ViewModel;
using System.Collections.Generic;

namespace Common.Service.Interface
{
    public interface IBlog
    {
        List<BlogViewModel> ListAll();
        BlogViewModel DetailsBlog(string slug);
        List<BlogViewModel> ListBlogCate(string slug);
        List<BlogModel> ListRelatedBlog(int id);
        //List<CommentBlogViewModel> ListComment(int blogsId);
    }
}
