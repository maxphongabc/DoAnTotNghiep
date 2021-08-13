
using Common.Model;
using Microsoft.EntityFrameworkCore;

namespace Common.Data
{
    public class DPContext : DbContext
    {
        public DPContext(DbContextOptions<DPContext> options)
            : base(options)
        {
        }

        public DbSet<CategoryModel> categories { get; set; }
        public DbSet<OrderModel> order { get; set; }
        public DbSet<RolesModel> roles { get; set; }
        public DbSet<UserModel> user { get; set; }
        public DbSet<Order_DetailsModel> order_Details { get; set; }
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
