using MembershipPortal.IRepositories;
using MembershipPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipPortal.Repositories
{
    public class TaxRepository : IRepository<Tax>, ITaxRepository
    {
        public Task<Tax> CreateAsync(Tax entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Tax entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tax>> GetAsyncAll()
        {
            throw new NotImplementedException();
        }

        public Task<Tax> GetAsyncById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Tax> UpdateAsync(Tax entity)
        {
            throw new NotImplementedException();
        }
    }
}
