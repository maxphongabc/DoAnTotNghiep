
using Common.Model;
using Microsoft.EntityFrameworkCore;

namespace Common.Data
{
    public class ProjectDPContext : DbContext
    {
        public ProjectDPContext(DbContextOptions<ProjectDPContext> options)
            : base(options)
        {
        }

        public DbSet<CategoryModel> categories { get; set; }
        public DbSet<OrderModel> order { get; set; }
        public DbSet<RolesModel> roles { get; set; }
        public DbSet<UserModel> user { get; set; }
        public DbSet<Order_DetailsModel> order_Details { get; set; }
        public DbSet<ProductModel> products { get; set; }
        public DbSet<CommentProduct> commentsproduct { get; set; }
        public DbSet<BlogModel> blogs { get; set; }
        public DbSet<Category_PostModel> category_Posts { get; set; }
        public DbSet<WishListModel> wistlists { get; set; }
        public DbSet<FeedBackModel> feedbacks { get; set; }
        public DbSet<TransactStatus> TransactStatuses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}
