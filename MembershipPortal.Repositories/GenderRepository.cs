using MembershipPortal.Data;
using MembershipPortal.Models;
using MembershipPortal.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipPortal.IRepositories
{
    public class GenderRepository :  Repository<Gender>, IGenderRepository
    {
        public GenderRepository(MembershipPortalDbContext dbContext) : base(dbContext)
        {
        }
    }
}
