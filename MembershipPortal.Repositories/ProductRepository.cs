using MembershipPortal.Data;
using MembershipPortal.DTOs;
using MembershipPortal.IRepositories;
using MembershipPortal.Models;
using Microsoft.EntityFrameworkCore;

namespace MembershipPortal.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {


        private readonly MembershipPortalDbContext _dbContext;
        public ProductRepository(MembershipPortalDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<IEnumerable<Product>> GetProductSearchAsync(string find)
        {
            string keyword = find.ToLower();

            var filterlist = await _dbContext.Products
               .Where(m => m.ProductName.ToLower().Contains(keyword) ||
                m.Price.ToString().Contains(keyword))
                .ToListAsync();

            return filterlist;
        }


        public async Task<IEnumerable<Product>> GetProductAdvanceSearchAsync(Product productobj)
        {
            var query = _dbContext.Products.AsQueryable();



            if (!string.IsNullOrWhiteSpace(productobj.ProductName))
            {
                query = query.Where(product => productobj.ProductName == product.ProductName);
            }
            if (productobj.Price > 0)
            {
                query = query.Where(product => product.Price == productobj.Price);
            }

            return await query.ToListAsync();

        }

        public async Task<(IEnumerable<Product>, int)> GetAllPaginatedAndSortedProductAsync(int page, int pageSize, string? sortColumn, string? sortOrder, Product productObj)
        {
            
                var query = _dbContext.Products.AsQueryable();

                // Filter based on search criteria
                if (!string.IsNullOrWhiteSpace(productObj.ProductName))
                {
                    query = query.Where(product => product.ProductName.Contains(productObj.ProductName));
                }
                if (productObj.Price > 0)
                {
                    query = query.Where(product => product.Price.Equals(productObj.Price));
                }
                
                int totalCount = await query.CountAsync();

                int totalPages = (int)Math.Ceiling((decimal)totalCount / pageSize);


                query = query.Skip((page - 1) * pageSize).Take(pageSize);

                // Apply sorting if provided
                if (!string.IsNullOrWhiteSpace(sortColumn) && !string.IsNullOrWhiteSpace(sortOrder))
                {
                    switch (sortColumn.ToLower())
                    {
                        case "productname":
                            query = sortOrder.ToLower() == "asc" ? query.OrderBy(s => s.ProductName) : query.OrderByDescending(s => s.ProductName);
                            break;

                    case "price":
                        query = sortOrder.ToLower() == "asc" ? query.OrderBy(s => s.Price) : query.OrderByDescending(s => s.Price);
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
