using MembershipPortal.DTOs;
using MembershipPortal.IRepositories;
using MembershipPortal.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipPortal.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ISubscriptionRepository _subscriptionRepository;

        public SubscriptionService(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<IEnumerable<GetSubscriptionDTO>> GetAllSubscriptionForeignAsync()
        {
            try
            {
                var getSubscriptionDTOList = await _subscriptionRepository.GetAllSubscriptionForeignAsync();

                if(getSubscriptionDTOList != null)
                {
                    return getSubscriptionDTOList;
                }
                
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }
    }
}
