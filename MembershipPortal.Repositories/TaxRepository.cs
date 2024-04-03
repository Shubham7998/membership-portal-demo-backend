using MembershipPortal.Data;
using MembershipPortal.IRepositories;
using MembershipPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipPortal.Repositories
{
    public class TaxRepository : Repository<Tax>, ITaxRepository
    {
        public TaxRepository(MembershipPortalDbContext dbContext) : base(dbContext)
        {

        }


    }
}
