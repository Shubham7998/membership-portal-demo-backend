using MembershipPortal.DTOs;
using MembershipPortal.IRepositories;
using MembershipPortal.IServices;
using Microsoft.EntityFrameworkCore;
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

        public async Task<GetSubscriptionDTO> CreateSubscriptionAsync(CreateSubscriptionDTO createSubscriptionDTO)
        {
            try
            {
                var subscription = await _subscriptionRepository.CreateSubscriptionAsync(createSubscriptionDTO);

                var subscriptionDTO = new GetSubscriptionDTO
                    (
                        subscription.Id, subscription.SubscriberId, subscription.ProductId, subscription.ProductName, subscription.ProductPrice,
                        subscription.DiscountId, subscription.DiscountCode, subscription.DiscountAmount, subscription.StartDate, subscription.ExpiryDate,
                        subscription.PriceAfterDiscount, subscription.TaxId, subscription.CGST, subscription.SGST, subscription.TotalTaxPercentage, subscription.TaxAmount,
                        subscription.FinalAmount
                    );
                return subscriptionDTO;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
            return null;
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

        public async Task<GetSubscriptionDTO> GetSubscriptionByIdAsync(long id)
        {
            try
            {
                var subscription = await _subscriptionRepository.GetAsyncById(id);
                
                if (subscription != null)
                {
                    var subscriptionDTO = new GetSubscriptionDTO
                    (
                        subscription.Id, subscription.SubscriberId, subscription.ProductId, subscription.ProductName, subscription.ProductPrice,
                        subscription.DiscountId, subscription.DiscountCode, subscription.DiscountAmount, subscription.StartDate, subscription.ExpiryDate,
                        subscription.PriceAfterDiscount, subscription.TaxId, subscription.CGST, subscription.SGST, subscription.TotalTaxPercentage, subscription.TaxAmount,
                        subscription.FinalAmount
                    );
                    return subscriptionDTO;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
            return null;
        }

       
       
    }
}
