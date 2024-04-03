using MembershipPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace MembershipPortal.Data
{
    public class MembershipPortalDbContext : DbContext
    {
        public MembershipPortalDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Gender> Gender { get; set; }
        public DbSet<Subscriber> Subscriber { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Subscriber>()
        //        .HasOne(p => p.Gender)
        //        .WithMany()
        //        .HasForeignKey(p => p.GenderId)
        //        .OnDelete(DeleteBehavior.Cascade);
        //}

    }
}
