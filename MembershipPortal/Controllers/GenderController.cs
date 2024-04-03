using MembershipPortal.DTOs;
using MembershipPortal.IServices;
using MembershipPortal.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MembershipPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        private readonly IGenderService _genderService;

        public GenderController(IGenderService genderService)
        {
            _genderService = genderService;
        }


        // GET: api/<GenderController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetGenderDTO>>> Get()
        {
            try{
                var genders = await _genderService.GetGendersAsync();

                if(genders.Count() != 0)
                {
                  
                     return Ok(genders);
                }
                else
                {
                    return NotFound("The resource to be disply was not found.Table is empty.");
                }

            }
            catch(Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request." + ex.Message);

            }
        }

        // GET api/<GenderController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetGenderDTO>> Get(long id)
        {
            try
            {
                var gender = await _genderService.GetGenderAsync(id);
                if (gender != null)
                {
                    return Ok(gender);
                }
                else
                {
                    return NotFound("The resource to be updated was not found.");
                }
            }catch(Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request." + ex.Message);
            }
            return null;
        }

        // POST api/<GenderController>
        [HttpPost]
        public async Task<ActionResult<GetGenderDTO>> Post([FromBody] CreateGenderDTO genderDTO)
        {
            try
            {
                var gender = await _genderService.CreateGenderAsync(genderDTO);
                return Ok(gender);
                
            }
            catch(Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request." + ex.Message);
            }
        }

        // PUT api/<GenderController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetGenderDTO>> Put(long id, UpdateGenderDTO genderDTO)
        {
            

            try
            {
                var genders = await _genderService.UpdateGenderAsync(id, genderDTO);

                if (genders != null)
                {
                    return Ok(genders);
                }
                else
                {
                    return NotFound("The resource to be updated was not found.");
                }

            }catch(Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request." + ex.Message);
            }
        }

        // DELETE api/<GenderController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var genderDeleted = await _genderService.DeleteGenderAsync(id);

                if (genderDeleted)
                {
                    return StatusCode(200, "Gender deleted successfully");
                }
                else
                {
                    return NotFound("The resource to be deleted was not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request." +ex.Message);
            }
        }



    }
}
