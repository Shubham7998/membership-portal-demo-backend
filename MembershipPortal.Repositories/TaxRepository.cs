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
    public class TaxRepository : Repository<Tax>, ITaxRepository
    {
        private readonly MembershipPortalDbContext _dbContext;
        public TaxRepository(MembershipPortalDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<(IEnumerable<Tax>, int)> GetAllPaginatedAndSortedTaxAsync(int page, int pageSize, string? sortColumn, string? sortOrder, Tax taxObj)
        {
            
                var query = _dbContext.Taxes.AsQueryable();

            // Filter based on search criteria

            if (!string.IsNullOrWhiteSpace(taxObj.StateName))
            {
                query = query.Where(tax => tax.StateName.Contains(taxObj.StateName));
            }


            if (taxObj.CGST > 0)
                    {
                        query = query.Where(tax => tax.CGST == taxObj.CGST);

                    }

                    if (taxObj.SGST > 0)
                    {
                        query = query.Where(tax => tax.SGST == taxObj.SGST);

                    }
                    if (taxObj.TotalTax > 0)
                    {
                        query = query.Where(tax => tax.TotalTax == taxObj.TotalTax);

                    }

            int totalCount = await query.CountAsync();

                int totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);


                query = query.Skip((page - 1) * pageSize).Take(pageSize);

                // Apply sorting if provided
                if (!string.IsNullOrWhiteSpace(sortColumn) && !string.IsNullOrWhiteSpace(sortOrder))
                {
                    switch (sortColumn.ToLower())
                    {

                    case "stateName":
                        query = sortOrder.ToLower() == "asc" ? query.OrderBy(s => s.StateName) : query.OrderByDescending(s => s.StateName);
                        break;
                    case "cgst":
                            query = sortOrder.ToLower() == "asc" ? query.OrderBy(s => s.CGST) : query.OrderByDescending(s => s.CGST);
                            break;
                        case "sgst":
                            query = sortOrder.ToLower() == "asc" ? query.OrderBy(s => s.SGST) : query.OrderByDescending(s => s.SGST);
                            break;
                        case "totaltax":
                            query = sortOrder.ToLower() == "asc" ? query.OrderBy(s => s.TotalTax) : query.OrderByDescending(s => s.TotalTax);
                            break;
                        default:
                            query = query.OrderBy(s => s.Id);
                            break;
                    }
                }

                // Execute query and return paginated and sorted results along with total count
                return (await query.ToListAsync(), totalCount);
            }

        



        public async Task<IEnumerable<Tax>> GetAllSortedTax(string? sortColumn, string? sortOrder)
        {
            IQueryable<Tax> query = _dbContext.Taxes;
            if (!string.IsNullOrWhiteSpace(sortColumn) && !string.IsNullOrWhiteSpace(sortOrder))
            {
                // Determine the sort order based on sortOrder parameter
                bool isAscending = sortOrder.ToLower() == "asc";
                switch (sortColumn.ToLower())
                {
                    case "cgst":
                        query = isAscending ? query.OrderBy(s => s.CGST) : query.OrderByDescending(s => s.CGST);
                        break;
                    case "sgst":
                        query = isAscending ? query.OrderBy(s => s.SGST) : query.OrderByDescending(s => s.SGST);
                        break;
                    case "totaltax":
                        query = isAscending ? query.OrderBy(s => s.TotalTax) : query.OrderByDescending(s => s.TotalTax);
                        break;
                    default:
                        query = query.OrderBy(s => s.Id);
                        break;
                }

            }

            return await query.ToListAsync();
        }

    }
}
