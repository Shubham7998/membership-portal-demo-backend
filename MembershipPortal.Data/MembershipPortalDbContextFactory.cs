using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipPortal.Data
{
    public class MembershipPortalDbContextFactory : IDesignTimeDbContextFactory<MembershipPortalDbContext>
    {
        public MembershipPortalDbContext CreateDbContext(string[] args)
        {

            var optionsBuilder = new DbContextOptionsBuilder<MembershipPortalDbContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-JIABSKC\\SQLEXPRESS;Initial Catalog=MembershipPortalDB;User ID=sa;Password=user123;Encrypt=True;Trust Server Certificate=True");

            return new MembershipPortalDbContext(optionsBuilder.Options);
        }

    }



}
