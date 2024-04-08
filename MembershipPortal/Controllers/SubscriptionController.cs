﻿using MembershipPortal.DTOs;
using MembershipPortal.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MembershipPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionService _subscriptionService;

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

                
                return Ok(getSubscriptionDTOList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<SubscriptionController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetSubscriptionDTO>> Get(long id)
        {
            try
            {
                var result = await _subscriptionService.GetSubscriptionByIdAsync(id);
                if(result != null) {
                    return Ok(result);
                }
                return BadRequest($"Data with {id} is not present in our table");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
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

                return BadRequest(ex.Message);
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
                return BadRequest("Failed To Update entry to the database table");
            }
            
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // DELETE api/<SubscriptionController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            try
            {
                var result = await _subscriptionService.DeleteSubscriptionByIdAsync(id);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
               
            }
            
        }
    }
}