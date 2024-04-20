using MembershipPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipPortal.IRepositories
{
    public interface ITaxRepository : IRepository<Tax>
    {
       

        Task<(IEnumerable<Tax>, int)> GetAllPaginatedAndSortedTaxAsync(int page, int pageSize, string? sortColumn, string? sortOrder, Tax taxObj);


    }
}
