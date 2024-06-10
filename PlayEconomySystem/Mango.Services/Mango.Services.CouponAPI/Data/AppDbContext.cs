using Mango.Services.CouponAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace Mango.Services.CouponAPI.Data
{
    public class AppDbContext  : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Coupon> Coupons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Coupon>().HasData(new Coupon()
            {
                Id=Guid.NewGuid(), 
                CouponCode = "GHU", 
                DiscountAmount = .59, 
                MinAmount = 25
            });
            modelBuilder.Entity<Coupon>().HasData(new Coupon()
            {
                Id = Guid.NewGuid(),
                CouponCode = "GNJ",
                DiscountAmount = 0.26,
                MinAmount = 54
            });
        }
    }
}
