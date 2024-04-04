using MembershipPortal.Data;
using MembershipPortal.DTOs;
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
    public class SubscriptionRepository : Repository<Subscription>, ISubscriptionRepository
    {
        private readonly MembershipPortalDbContext _dbContext;
        public SubscriptionRepository(MembershipPortalDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<GetSubscriptionDTO>> GetAllSubscriptionForeignAsync()
        {
            var getSubscription =  await _dbContext.Subscriptions
                .Include(subscriber => subscriber.SubscriberId)
                .Include(product => product.ProductId)
                .Include(discount => discount.DiscountId)
                .Include(tax => tax.TaxId)
                .ToListAsync();


            var subscriptionDTOList = getSubscription.Select(
                subscription =>
                        new GetSubscriptionDTO(subscription.Id,
                                               subscription.SubscriberId,
                                               subscription.ProductId,
                                               subscription.Product.ProductName,
                                               subscription.Product.Price,
                                               subscription.DiscountId,
                                               subscription.Discount.DiscountCode,
                                               subscription.DiscountAmount,
                                               subscription.StartDate,
                                               subscription.ExpiryDate,
                                               subscription.PriceAfterDiscount,
                                               subscription.TaxId,
                                               subscription.Tax.CGST,
                                               subscription.Tax.SGST,
                                               subscription.Tax.CGST,
                                               subscription.TaxAmount,
                                               subscription.FinalAmount));

            return subscriptionDTOList;
        }
    }
} 
