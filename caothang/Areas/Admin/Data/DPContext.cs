using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using caothang.Areas.Admin.Models;
using caothang.Areas.Admin.Data;
using caothang.Models;

namespace caothang.Data
{
    public class DPContext : DbContext
    {
        public DPContext(DbContextOptions<DPContext> options)
            : base(options)
        {
        }

        public DbSet<CategoryModel> categories { get; set; }
        public DbSet<GalleryImageModel> galleryImages { get; set; }
        public DbSet<InvoiceModel> invoice { get; set; }
        public DbSet<RolesModel> roles { get; set; }
        public DbSet<UserModel> user { get; set; }
        public DbSet<Invoice_DetailsModel> invoice_Details { get; set; }
        public DbSet<ProductModel> products { get; set; }
        public DbSet<Product_DetailsModel> product_Details { get; set; }
        //public DbSet<Country> Countries { get; set; }
        //public DbSet<State> States { get; set; }
        //public DbSet<City> Cities { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
