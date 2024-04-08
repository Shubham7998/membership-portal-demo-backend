using MembershipPortal.Data;
using MembershipPortal.IRepositories;
using MembershipPortal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipPortal.Repositories
{
    public class UserRepository :Repository<User>, IUserRepository
    {

        private readonly MembershipPortalDbContext _dbContext;
        public UserRepository(MembershipPortalDbContext dbContext) : base(dbContext) { 
       
            _dbContext = dbContext;
        }

       

        public async Task<IEnumerable<User>> GetUserSearchAsync(string find)
        {
            string keyword = find.ToLower();

            var filterlist = await _dbContext.Users
               .Where(m => m.FirstName.ToLower().Contains(keyword) ||
                m.LastName.ToLower().Contains(keyword) ||
                m.ContactNumber.Contains(keyword) ||
                m.Email.ToLower().Contains(keyword))
                .ToListAsync();

            return filterlist;
        }

        public async Task<IEnumerable<User>> GetUserAdvanceSearchAsync(User userobj)
        {
            var query = _dbContext.Users.AsQueryable();

            if (!string.IsNullOrWhiteSpace(userobj.FirstName))
            {
                query = query.Where(user => userobj.FirstName == user.FirstName);
            }
            if (!string.IsNullOrWhiteSpace(userobj.LastName))
            {
                query = query.Where(user => userobj.LastName == user.LastName);
            }
            if (!string.IsNullOrWhiteSpace(userobj.ContactNumber))
            {
                query = query.Where(user => userobj.ContactNumber == user.ContactNumber);
            }
            if (!string.IsNullOrWhiteSpace(userobj.Email))
            {
                query = query.Where(user => userobj.Email == user.Email);
            }

            return await query.ToListAsync();
        }
    }
}
