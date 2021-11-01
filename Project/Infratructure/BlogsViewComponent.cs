using Common.Data;
using Common.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Infratructure
{
    public class BlogsViewComponent : ViewComponent
    {
        private readonly ProjectDPContext context;
        public BlogsViewComponent(ProjectDPContext context)
        {
            this.context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cate_post = await GetBlogsAsync();
            return View(cate_post);
        }
        private Task<List<Category_PostModel>> GetBlogsAsync()
        {
            return context.category_Posts.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
