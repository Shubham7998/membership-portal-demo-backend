using MembershipPortal.IServices;
using Microsoft.AspNetCore.Mvc;
using static MembershipPortal.DTOs.UserDTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MembershipPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;


        public UserController (IUserService userService)
        {
            _userService = userService;
        }
        // GET: api/<UserController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetUserDTO>>> Get()
        {

            try
            {
                var user = await _userService.GetUsersAsync();
                if(user == null)
                {
                    return StatusCode(204, $"Table is Empty");

                }
                else
                {
                    return Ok(user);
                }
              
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving User infos: {ex.Message}");
               
            }
           
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetUserDTO>> Get(long id)
        {
            try
            {
                var user = await _userService.GetUserAsync(id);
                if (user == null)
                {
                    return StatusCode(204, $"Id not present in the table");
                }
                return Ok(user);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving User info Id: {ex.Message}");

               
            }
            //return await _userService.GetUserAsync(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<GetUserDTO>> Post([FromBody] CreateUserDTO createUserDTO)
        {
            try
            {
                var createUser = await _userService.CreateUserAsync(createUserDTO);
                return Ok(createUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while creating user info: {ex.Message}");

                
            }
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetUserDTO>> Put(long id, [FromBody] UpdateUserDTO updateUserDTO)
        {
            if(id!= updateUserDTO.Id)
            {
                return BadRequest("ID in the URL does not match ID in the request body.");

            }
            try
            {
                var user = await _userService.UpdateUserAsync(id, updateUserDTO);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while updating user info: {ex.Message}");
                
            }
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            try
            {
                var isDeleted = await _userService.DeleteUserAsync(id);
                return Ok(isDeleted);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting user info: {ex.Message}");

             
            }
        }
    }
}
