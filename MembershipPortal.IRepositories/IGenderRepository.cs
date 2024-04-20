using MembershipPortal.IRepositories;
using MembershipPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipPortal.IRepositories
{
    public interface IGenderRepository : IRepository<Gender>
    {
        
        Task<(IEnumerable<Gender>, int)> GetAllPaginatedAndSortedGenderAsync(int page, int pageSize, string? sortColumn, string? sortOrder, Gender genderObj);

    }
}
