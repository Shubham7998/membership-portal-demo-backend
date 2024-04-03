using MembershipPortal.DTOs;
using MembershipPortal.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MembershipPortal.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class SubscriberController : ControllerBase
    {
        private readonly ISubscriberService _subscriberService;

        public SubscriberController(ISubscriberService subscriberService)
        {
            _subscriberService = subscriberService;
        }


        // GET: api/<SubscriberController>
        [HttpGet]
        public async Task<IEnumerable<GetSubscriberDTO>> Get()
        {
            try
            {
                var subscriberDto = await _subscriberService.GetSubscribersAsync();

                return subscriberDto;
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        // GET api/<SubscriberController>/5
        [HttpGet("{id}")]
        public async Task<GetSubscriberDTO> Get(long id)
        {
            try
            {
                var subscriberDto = await _subscriberService.GetSubscriberAsync(id);

                return subscriberDto;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        // POST api/<SubscriberController>
        [HttpPost]
        public async Task<GetSubscriberDTO> Post([FromBody] CreateSubscriberDTO subscriberDTO)
        {
            try
            {
                var subscriberDto = await _subscriberService.CreateSubscriberAsync(subscriberDTO);

                return subscriberDto;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;

        }

        // PUT api/<SubscriberController>/5
        [HttpPut("{id}")]
        public async Task<GetSubscriberDTO> Put(long id,[FromBody] UpdateSubscriberDTO subscriberDTO)
        {
            try
            {
                var subscriberDto = await _subscriberService.UpdateSubscriberAsync(id, subscriberDTO);

                return subscriberDto;
            }catch( Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }

        // DELETE api/<SubscriberController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(long id)
        {
            try
            {
                var subscriberDto = await _subscriberService.DeleteSubscriberAsync(id);

                return subscriberDto;
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }
    }
}
