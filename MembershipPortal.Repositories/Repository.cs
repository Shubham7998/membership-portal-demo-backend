using MembershipPortal.Data;
using MembershipPortal.IRepositories;

namespace MembershipPortal.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly MembershipPortalDbContext _dbContext;
        public Repository(MembershipPortalDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public Task<T> CreateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAsyncAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsyncById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
