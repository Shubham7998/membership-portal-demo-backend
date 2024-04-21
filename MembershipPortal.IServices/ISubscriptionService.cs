using MembershipPortal.DTOs;
using MembershipPortal.IRepositories;
using MembershipPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipPortal.IServices
{
    public interface ISubscriptionService
    {
        public Task<IEnumerable<GetSubscriptionDTO>> GetAllSubscriptionForeignAsync();
        public Task<GetSubscriptionDTO> GetSubscriptionByIdAsync(long id);
        public Task<bool> DeleteSubscriptionByIdAsync(long id);
        public Task<GetSubscriptionDTO> CreateSubscriptionAsync(CreateSubscriptionDTO createSubscriptionDTO);

        public Task<GetSubscriptionDTO> UpdateSubscriptionAsync(long Id, UpdateSubscriptionDTO updateSubscriptionDTO);

         Task<(IEnumerable<GetSubscriptionDTO>, int)> GetAllPaginatedAndSortedSubscriptionAsync(int page, int pageSize, string? sortColumn, string? sortOrder, Subscription subscriptionObj);


    }
}
