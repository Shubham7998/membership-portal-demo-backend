using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MembershipPortal.DTOs;
using MembershipPortal.IServices;

namespace MembershipPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        // GET: api/Discount
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetDiscountDTO>>> GetDiscountsAsyc()
        {
            try
            {
                var discoutDTOList = await _discountService.GetDiscountsAsync();
                if (discoutDTOList != null)
                {
                    return Ok(discoutDTOList);
                }
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET: api/Discount/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetDiscountDTO>> GetDiscountByIdAsync(long id)
        {
            try
            {
                var discountDTO = await _discountService.GetDiscountByIdAsync(id);

                if (discountDTO == null)
                {
                    return NotFound(id);
                }

                return Ok(discountDTO);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT: api/Discount/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<GetDiscountDTO>> PutDiscountAsync(long id, UpdateDiscountDTO discountDTO)
        {
            if (id != discountDTO.Id)
            {
                return BadRequest("Id Mismatch");
            }
            
            try
            {
                var oldDiscount = await _discountService.GetDiscountByIdAsync(id);

                if (oldDiscount == null)
                {
                    return NotFound("Data with id is not found");
                }

                var result =  await _discountService.UpdateDiscountAsync(id, discountDTO);

                return Ok(result);
            }
            catch (DbUpdateConcurrencyException)
            {
                
                    throw;
                
            }

        }

        // POST: api/Discount
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GetDiscountDTO>> PostDiscountAsync(CreateDiscountDTO discountDTO)
        {
            try
            {
                var result = await _discountService.CreateDiscountAsync(discountDTO);
                if (result == null)
                {
                    return BadRequest();
                }
                return Ok(result);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE: api/Discount/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteDiscountAsync(long id)
        {
            try
            {
                var discountDTO = await _discountService.GetDiscountByIdAsync(id);
                if (discountDTO != null)
                {
                    var result = await _discountService.DeleteDiscountAsync(id);
                    return Ok(result);
                }
                return Ok(false);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
