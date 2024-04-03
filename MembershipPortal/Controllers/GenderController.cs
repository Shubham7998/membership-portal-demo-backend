using MembershipPortal.DTOs;
using MembershipPortal.IServices;
using MembershipPortal.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IEnumerable<GetGenderDTO>> Get()
        {
            try{
                var genders = await _genderService.GetGendersAsync();

                return genders;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            return null;
        }

        // GET api/<GenderController>/5
        [HttpGet("{id}")]
        public async Task<GetGenderDTO> Get(long id)
        {
            try
            {
                var gender = await _genderService.GetGenderAsync(id);
                return gender;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        // POST api/<GenderController>
        [HttpPost]
        public async Task<GetGenderDTO> Post([FromBody] CreateGenderDTO genderDTO)
        {
            try
            {
                var gender = await _genderService.CreateGenderAsync(genderDTO);

                return gender;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        // PUT api/<GenderController>/5
        [HttpPut("{id}")]
        public async Task<GetGenderDTO> Put(long id, UpdateGenderDTO genderDTO)
        {
            try
            {
                var genders = await _genderService.UpdateGenderAsync(id, genderDTO);

                return genders;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        // DELETE api/<GenderController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            try
            {
                var gender = await _genderService.DeleteGenderAsync(id);

                return gender;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }
    }
}
