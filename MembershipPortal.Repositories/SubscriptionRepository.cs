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
            var getSubscription = await _dbContext.Subscriptions
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
                discountAmount = product.Price * discount.DiscountAmount / 100;
            }
            else
            {
                discountAmount = discount.DiscountAmount;
            }


            var priceAfterDiscount = product.Price - discountAmount;

            var taxAmount = priceAfterDiscount * tax.TotalTax / 100;

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

             await _dbContext.Subscriptions.AddAsync(subscription);
            
            await _dbContext.SaveChangesAsync();

            return subscription;

        }



        public async Task<Subscription> UpdateSubscriptionAsync(long Id ,UpdateSubscriptionDTO updateSubscriptionDTO)
        {
            var discount = await _dbContext.Discounts.FindAsync(updateSubscriptionDTO.DiscountId);
            var oldSubscription = await _dbContext.Subscriptions.FindAsync(Id);
            var product = await _dbContext.Products.FindAsync(updateSubscriptionDTO.ProductId);
            

            decimal discountAmount = 0;
            decimal priceAfterDiscount = 0;
            decimal taxAmount = 0;
            decimal finalAmount = 0;

            if (oldSubscription != null)
            {

                if(oldSubscription.ProductId != updateSubscriptionDTO.ProductId)
                {
                    oldSubscription.ProductId = updateSubscriptionDTO.ProductId;
                    oldSubscription.ProductName = product.ProductName;
                    oldSubscription.ProductPrice = product.Price;

                    priceAfterDiscount = reCalculatingDiscount(oldSubscription, updateSubscriptionDTO, discount, product);
                    taxAmount = reCalculatingTax(oldSubscription);
                }
                else if(oldSubscription.DiscountId != updateSubscriptionDTO.DiscountId)
                {
                    priceAfterDiscount = reCalculatingDiscount(oldSubscription, updateSubscriptionDTO, discount, product);
                    taxAmount = reCalculatingTax(oldSubscription);
                }

                finalAmount = priceAfterDiscount + taxAmount;

                oldSubscription.FinalAmount = finalAmount;

                var result =  _dbContext.Subscriptions.Update(oldSubscription);
                await _dbContext.SaveChangesAsync();


                var subscription = new Subscription()
                {   
                    Id = oldSubscription.Id,
                    SubscriberId = oldSubscription.SubscriberId,
                    ProductId = oldSubscription.ProductId,
                    ProductName = oldSubscription.ProductName,
                    ProductPrice = oldSubscription.ProductPrice,
                    DiscountId = oldSubscription.DiscountId,
                    DiscountCode = oldSubscription.DiscountCode,
                    DiscountAmount = oldSubscription.DiscountAmount,
                    StartDate = oldSubscription.StartDate,
                    ExpiryDate = oldSubscription.ExpiryDate,
                    PriceAfterDiscount = oldSubscription.PriceAfterDiscount,
                    TaxId = oldSubscription.TaxId,
                    SGST = oldSubscription.SGST,
                    CGST = oldSubscription.CGST,
                    TotalTaxPercentage = oldSubscription.TotalTaxPercentage,
                    TaxAmount = oldSubscription.TaxAmount,
                    FinalAmount = oldSubscription.FinalAmount
                };
                return subscription;
            }

            return null;
        }

        private decimal reCalculatingDiscount(Subscription oldSubscription, UpdateSubscriptionDTO updateSubscriptionDTO,Discount discount, Product product)
        {
            
            decimal discountAmount = 0;
            decimal priceAfterDiscount = 0;
            oldSubscription.DiscountId = updateSubscriptionDTO.DiscountId;
            oldSubscription.DiscountCode = discount.DiscountCode;
            // oldSubscription.DiscountAmount = discount.DiscountAmount;


            if (discount.IsDiscountInPercentage)
            {
                discountAmount = product.Price * discount.DiscountAmount / 100;

            }
            else
            {
                discountAmount = discount.DiscountAmount;
            }
            if (discountAmount >=  product.Price)
            {
                oldSubscription.DiscountAmount = 0;
                oldSubscription.PriceAfterDiscount = 0;
                return oldSubscription.PriceAfterDiscount;
            }
           

            oldSubscription.DiscountAmount = discountAmount;

            priceAfterDiscount = product.Price - discountAmount;

            oldSubscription.PriceAfterDiscount = priceAfterDiscount;

            return priceAfterDiscount;
        }

        private decimal reCalculatingTax(Subscription oldSubscription)
        {
            decimal taxAmount = 0;
            taxAmount = oldSubscription.PriceAfterDiscount * oldSubscription.TotalTaxPercentage / 100;

            oldSubscription.TaxAmount = taxAmount;
            return taxAmount;

        }
    }
}
