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
                .Include(subscriber => subscriber.Subscriber)
                .Include(product => product.Product)
                .Include(discount => discount.Discount)
                .Include(tax => tax.Tax)
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
                                               subscription.Tax.TotalTax,
                                               subscription.TaxAmount,
                                               subscription.FinalAmount));

            return subscriptionDTOList;
        }

        public async Task<Subscription> CreateSubscriptionAsync(CreateSubscriptionDTO createSubscriptionDTO)
        {

            var product = await _dbContext.Products.FindAsync(createSubscriptionDTO.ProductId);
            var discount = await _dbContext.Discounts.FindAsync(createSubscriptionDTO.DiscountId);
            var tax = await _dbContext.Taxes.FindAsync(createSubscriptionDTO.TaxId);

            decimal discountAmount = 0;

            if (discount.IsDiscountInPercentage)
            {
                discountAmount = product.Price * discount.DiscountAmount/100;
            }
            else
            {
                discountAmount = discount.DiscountAmount;
            }


            var priceAfterDiscount = product.Price - discountAmount;

            var taxAmount = priceAfterDiscount * tax.TotalTax/100;

            var finalAmount = priceAfterDiscount + taxAmount;

            var subscription = new Subscription()
            {
                SubscriberId = createSubscriptionDTO.SubscriberId,
                ProductId = createSubscriptionDTO.ProductId,
                ProductName = product.ProductName,
                ProductPrice = product.Price,
                DiscountId = createSubscriptionDTO.DiscountId,
                DiscountCode = discount.DiscountCode,
                DiscountAmount = discountAmount,
                StartDate = createSubscriptionDTO.StartDate,
                ExpiryDate = createSubscriptionDTO.ExpiryDate,
                PriceAfterDiscount = priceAfterDiscount,
                TaxId = createSubscriptionDTO.TaxId,
                SGST = tax.SGST,
                CGST = tax.CGST,
                TotalTaxPercentage = tax.TotalTax,
                TaxAmount = taxAmount,
                FinalAmount = finalAmount
            };

            await _dbContext.AddAsync(subscription);
            await _dbContext.SaveChangesAsync();
            
            return subscription;
           
        }

    }
} 
