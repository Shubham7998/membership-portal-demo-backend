﻿using MembershipPortal.DTOs;
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
        public async Task<ActionResult<IEnumerable<GetSubscriberDTO>>> Get()
        {
            try
            {
                var subscriberDto = await _subscriberService.GetSubscribersAsync();

                if (subscriberDto.Count() != 0)
                {

                    return Ok(subscriberDto);
                }
                else
                {
                    return NotFound("The resource to be display was not found.Table is empty.");
                }
            }catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request." + ex.Message);

            }
        }

        // GET api/<SubscriberController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetSubscriberDTO>> Get(long id)
        {
            try
            {
                var subscriberDto = await _subscriberService.GetSubscriberAsync(id);
                if(subscriberDto != null)
                {
                    return subscriberDto;

                }
                else
                {
                    return NotFound("The resource to be display was not found.");
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request." + ex.Message);
            }
        }

        // POST api/<SubscriberController>
        [HttpPost]
        public async Task<ActionResult<GetSubscriberDTO>> Post([FromBody] CreateSubscriberDTO subscriberDTO)
        {
            try
            {
                var subscriberDto = await _subscriberService.CreateSubscriberAsync(subscriberDTO);

                return Ok(subscriberDto);
            }catch(Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request." + ex.Message);
            }

        }

        // PUT api/<SubscriberController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetSubscriberDTO>> Put(long id,[FromBody] UpdateSubscriberDTO subscriberDTO)
        {
            try
            {
                var subscriberDto = await _subscriberService.UpdateSubscriberAsync(id, subscriberDTO);

                if (subscriberDto != null)
                {
                    return Ok(subscriberDto);
                }
                else
                {
                    return NotFound("The resource to be update was not found.");
                }
            }
            catch( Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request." + ex.Message);
            }
        }

        // DELETE api/<SubscriberController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                var subscriberDto = await _subscriberService.DeleteSubscriberAsync(id);

                if (subscriberDto)
                {
                    return StatusCode(200, "Subscriber deleted successfully");
                }
                else
                {
                    return NotFound("The resource to be deleted was not found.");
                }
            }
            catch(Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request." + ex.Message);
            }
        }
    }
}