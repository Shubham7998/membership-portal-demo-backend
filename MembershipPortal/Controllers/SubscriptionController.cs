using MembershipPortal.API.ErrorHandling;
using MembershipPortal.DTOs;
using MembershipPortal.IServices;
using MembershipPortal.Models;
using MembershipPortal.Services;
using Microsoft.AspNetCore.Mvc;
using static MembershipPortal.DTOs.UserDTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MembershipPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;
        private readonly string tableName = "Subscription";
        public SubscriptionController(ISubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }


        // GET: api/<SubscriptionController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetSubscriptionDTO>>> Get()
        {
            try
            {
                var getSubscriptionDTOList = await _subscriptionService.GetAllSubscriptionForeignAsync();

                if(getSubscriptionDTOList.Count() != 0)
                {
                    return Ok(getSubscriptionDTOList);

                }
                return NotFound(MyException.DataNotFound(tableName));
            }
            catch (Exception ex)
            {

                return StatusCode(500, MyException.DataProcessingError(ex.Message));
            }
        }

        // GET api/<SubscriptionController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetSubscriptionDTO>> Get(long id)
        {
            try
            {
                var result = await _subscriptionService.GetSubscriptionByIdAsync(id);
               
                return Ok(result);
                if(result != null) {
                    return Ok(result);
                }
                //return NotFound(MyException.DataWithIdNotPresent(id, tableName));
            }
            catch (Exception ex)
            {

                return StatusCode(500, MyException.DataProcessingError(ex.Message));
            }
        }

        // POST api/<SubscriptionController>
        [HttpPost]
        public async Task<ActionResult<GetSubscriptionDTO>> Post([FromBody] CreateSubscriptionDTO subscriptionDTO)
        {
            try
            {
                var result = await _subscriptionService.CreateSubscriptionAsync(subscriptionDTO);
                if (result != null)
                {
                    return Ok(result);
                }
                return BadRequest("Failed To create entry to the database table");
            }
            catch (Exception ex)
            {

                return StatusCode(500, MyException.DataProcessingError(ex.Message));
            }
        }

        // PUT api/<SubscriptionController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetSubscriptionDTO>> Put(long id, [FromBody] UpdateSubscriptionDTO updateSubscriptionDTO)
        {
            try
            {
                var result = await _subscriptionService.UpdateSubscriptionAsync(id, updateSubscriptionDTO);
                if (result != null)
                {
                    return Ok(result);
                }
                return NotFound(MyException.DataWithIdNotPresent(id, tableName));
            }

            catch (Exception ex)
            {

                return StatusCode(500, MyException.DataProcessingError(ex.Message));
            }

        }

        // DELETE api/<SubscriptionController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            try
            {
                var result = await _subscriptionService.GetSubscriptionByIdAsync(id);
                if (result != null)
                {
                    var subscription = await _subscriptionService.DeleteSubscriptionByIdAsync(id);
                    return StatusCode(200, MyException.DataDeletedSuccessfully(tableName));
                }
                return NotFound(MyException.DataWithIdNotPresent(id, tableName));


            }
            catch (Exception ex)
            {

                return StatusCode(500, MyException.DataProcessingError(ex.Message));
            }

        }

        [HttpPost("paginatedsorting")]
        public async Task<ActionResult<Paginated<GetSubscriptionDTO>>> GetSortedPaginatedData(int page, int pageSize, string? sortColumn, string? sortOrder, GetSubscriptionDTO subscriptionDTO)
        {
            try
            {
                
                var paginatedSubscriptionDTOAndTotalPages = await _subscriptionService.GetAllPaginatedAndSortedSubscriptionAsync(page, pageSize, sortColumn, sortOrder, new Subscription()
                {

                    Id = subscriptionDTO.Id,
                    SubscriberId = subscriptionDTO.SubscriberId,
                    ProductId = subscriptionDTO.ProductId,
                    ProductName = subscriptionDTO.ProductName,
                    ProductPrice = subscriptionDTO.ProductPrice,
                    DiscountId = subscriptionDTO.DiscountId,
                    DiscountCode = subscriptionDTO.DiscountCode,
                    DiscountAmount = subscriptionDTO.DiscountAmount,
                    StartDate = String.IsNullOrEmpty(subscriptionDTO.StartDate.ToString()) ? DateOnly.MinValue : (DateOnly)subscriptionDTO.StartDate,
                    ExpiryDate = String.IsNullOrEmpty(subscriptionDTO.ExpiryDate.ToString()) ? DateOnly.MinValue : (DateOnly)subscriptionDTO.ExpiryDate,
                    PriceAfterDiscount = subscriptionDTO.PriceAfterDiscount,
                    TaxId = subscriptionDTO.TaxId,
                    CGST = subscriptionDTO.CGST,
                    SGST = subscriptionDTO.SGST,
                    TotalTaxPercentage = subscriptionDTO.TotalTaxPercentage,
                    TaxAmount = subscriptionDTO.TaxAmount,
                    FinalAmount = subscriptionDTO.FinalAmount

                });

                var result = new Paginated<GetSubscriptionDTO>
                {
                    dataArray = paginatedSubscriptionDTOAndTotalPages.Item1,
                    totalPages = paginatedSubscriptionDTOAndTotalPages.Item2
                };


                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(500, MyException.DataProcessingError(ex.Message));
            }
        }



    }
}
