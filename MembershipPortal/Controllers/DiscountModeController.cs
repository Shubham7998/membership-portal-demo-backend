using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MembershipPortal.DTOs;
using MembershipPortal.IServices;

namespace MembershipPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountModeController : ControllerBase
    {
        private readonly IDiscountModeService _DiscountModeService;

        public DiscountModeController(IDiscountModeService DiscountModeService)
        {
            _DiscountModeService = DiscountModeService;
        }

        // GET: api/DiscountMode
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetDiscountModeDTO>>> GetDiscountModesAsyc()
        {
            var discoutDTOList = await _DiscountModeService.GetDiscountModesAsync();
            if (discoutDTOList != null)
            {
                return Ok(discoutDTOList);
            }
            return NoContent();
        }

        // GET: api/DiscountMode/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetDiscountModeDTO>> GetDiscountModeByIdAsync(long id)
        {
            var DiscountModeDTO = await _DiscountModeService.GetDiscountModeByIdAsync(id);

            if (DiscountModeDTO == null)
            {
                return NotFound(id);
            }

            return Ok(DiscountModeDTO);
        }

        // PUT: api/DiscountMode/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<GetDiscountModeDTO>> PutDiscountModeAsync(long id, UpdateDiscountModeDTO DiscountModeDTO)
        {
            if (id != DiscountModeDTO.Id)
            {
                return BadRequest("Id Mismatch");
            }

            try
            {
                return await _DiscountModeService.UpdateDiscountModeAsync(id, DiscountModeDTO);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiscountModeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

        }

        // POST: api/DiscountMode
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GetDiscountModeDTO>> PostDiscountModeAsyc(CreateDiscountModeDTO DiscountModeDTO)
        {
            var result = await _DiscountModeService.CreateDiscountModeAsync(DiscountModeDTO);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        // DELETE: api/DiscountMode/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteDiscountModeAsync(long id)
        {
            try
            {
                var DiscountModeDTO = await _DiscountModeService.GetDiscountModeByIdAsync(id);
                if (DiscountModeDTO != null)
                {
                    var result = await _DiscountModeService.DeleteDiscountModeAsync(id);
                    return Ok(result);
                }
                return Ok(false);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool DiscountModeExists(long id)
        {
            var result = _DiscountModeService.GetDiscountModeByIdAsync(id);
            if (result != null)
            {
                return true;
            }
            return false;
        }
    }
}
