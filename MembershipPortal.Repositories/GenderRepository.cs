using MembershipPortal.Data;
using MembershipPortal.Models;
using MembershipPortal.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NuGet.Common.NuGetEventSource;

namespace MembershipPortal.IRepositories
{
    public class GenderRepository :  Repository<Gender>, IGenderRepository
    {
        private readonly MembershipPortalDbContext _dbContext;

        public GenderRepository(MembershipPortalDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

      

        public async Task<(IEnumerable<Gender>, int)> GetAllPaginatedAndSortedGenderAsync(int page, int pageSize, string? sortColumn, string? sortOrder, Gender genderObj)
        {
            var query = _dbContext.Genders.AsQueryable();

            // Filter based on search criteria
            if (!string.IsNullOrWhiteSpace(genderObj.GenderName))
            {
                query = query.Where(gender => gender.GenderName.Contains(genderObj.GenderName));
            }
            int totalCount = await query.CountAsync();

            int totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);


            query = query.Skip((page - 1) * pageSize).Take(pageSize);

            // Apply sorting if provided
            if (!string.IsNullOrWhiteSpace(sortColumn) && !string.IsNullOrWhiteSpace(sortOrder))
            {
                switch (sortColumn.ToLower())
                {
                    case "gendername":
                        query = sortOrder.ToLower() == "asc" ? query.OrderBy(s => s.GenderName) : query.OrderByDescending(s => s.GenderName);
                        break;

                    default:
                        query = query.OrderBy(s => s.Id);
                        break;
                }
            }

            // Execute query and return paginated and sorted results along with total count
            return (await query.ToListAsync(), totalCount);
        }

       
    }
}
