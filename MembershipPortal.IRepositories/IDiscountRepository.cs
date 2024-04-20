using MembershipPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipPortal.IRepositories
{
    public interface IDiscountRepository : IRepository<Discount>
    {
        Task<IEnumerable<Discount>> GetAllSortedDiscount(string? sortColumn, string? sortOrder);

        Task<(IEnumerable<Discount>, int)> GetAllPaginatedDiscountAsync(int page, int pageSize, Discount discount);

        Task<(IEnumerable<Discount>, int)> GetAllPaginatedAndSortedDiscountsAsync(int page, int pageSize, string? sortColumn, string? sortOrder, Discount discountObj);

    }
}
