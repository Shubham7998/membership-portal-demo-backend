using MembershipPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace MembershipPortal.Data
{
    public class MembershipPortalDbContext : DbContext
    {
        public MembershipPortalDbContext(DbContextOptions<MembershipPortalDbContext> options) : base(options)
        {
            
        }

        public DbSet<Tax> Taxes { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<DiscountMode> DiscountModes { get; set; }
    }
}
