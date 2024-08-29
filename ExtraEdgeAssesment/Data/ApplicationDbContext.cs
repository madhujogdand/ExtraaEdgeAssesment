using ExtraaEdgeAssesment.Models;
using Microsoft.EntityFrameworkCore;

namespace ExtraaEdgeAssesment.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Mobile> Mobiles { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<MobilePriceHistory> MobilePriceHistories { get; set; }
    }
}
