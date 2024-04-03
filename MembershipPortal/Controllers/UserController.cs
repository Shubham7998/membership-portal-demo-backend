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
        public async Task<IEnumerable<GetUserDTO>> Get()
        {
            return await _userService.GetUsersAsync();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<GetUserDTO> Get(long id)
        {
            return await _userService.GetUserAsync(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<GetUserDTO> Post([FromBody] CreateUserDTO createUserDTO)
        {
            return await _userService.CreateUserAsync(createUserDTO);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<GetUserDTO> Put(int id, [FromBody] UpdateUserDTO updateUserDTO)
        {
            return await _userService.UpdateUserAsync(id, updateUserDTO);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _userService.DeleteUserAsync(id);
        }
    }
}
