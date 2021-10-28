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
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly ProjectDPContext context;
        public CategoriesViewComponent (ProjectDPContext context)
        {
            this.context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await GetCategoriesAsync();
            return View(categories);
        }

        private Task<List<CategoryModel>> GetCategoriesAsync()
        {
            return context.categories.OrderBy(x => x.Sorting).ToListAsync();
        }
    }
}
