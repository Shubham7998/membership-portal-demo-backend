using MembershipPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipPortal.IRepositories
{
    public interface ISubscriberRepository : IRepository<Subscriber>
    {
        Task<IEnumerable<Subscriber>> SearchAsyncAll(string search);
        Task<(IEnumerable<Subscriber>, int)> GetAllPaginatedSubscriberAsync(int page, int pageSize, Subscriber subscriberObj);

        Task<IEnumerable<Subscriber>> GetAllSortedSubscribers(string? sortColumn, string? sortOrder);

        Task<IEnumerable<Subscriber>> GetAllForeginSubscribers();

        Task<(IEnumerable<Subscriber>, int)> GetAllPaginatedAndSortedSubscribersAsync(int page, int pageSize, string? sortColumn, string? sortOrder, Subscriber subscriberObj);

        //Task<IEnumerable<Subscriber>> GetAsyncByIdForeginSubscribers(string? sortColumn, string? sortOrder);


    }
}
