using MembershipPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace MembershipPortal.Data
{
    public class MembershipPortalDbContext : DbContext
    {
        public MembershipPortalDbContext(DbContextOptions<MembershipPortalDbContext> options) : base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<DiscountMode> DiscountModes { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
    }
}
