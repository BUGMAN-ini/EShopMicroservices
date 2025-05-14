using Discount.Grpc.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data
{
    public class DiscountContext(DbContextOptions<DiscountContext> options) : DbContext(options)
    {
        public DbSet<Coupon> Coupons { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coupon>().HasData
            (
                new Coupon
                {
                    Id = 1,
                    ProductName = "IPhone X",
                    Description = "IPhone Discount",
                    Amount = 150
                },
                new Coupon
                {
                    Id = 2,
                    ProductName = "Samsung S10",
                    Description = "Samsung Discount",
                    Amount = 100
                },
                new Coupon
                {
                    Id = 3,
                    ProductName = "Xiaomi Mi 10",
                    Description = "Xiaomi Discount",
                    Amount = 50
                }
            );
        }
    }
}
