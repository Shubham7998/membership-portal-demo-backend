using MembershipPortal.IServices;
using Microsoft.AspNetCore.Mvc;
using static MembershipPortal.DTOs.ProductDTO;
using static MembershipPortal.DTOs.UserDTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MembershipPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductController (IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetProductDTO>>> Get()
        {
           try
            {
                var product = await _productService.GetProductsAsync();

                if(product == null) {

                    return StatusCode(200, $"Table is Empty"+(product));

                }
                return Ok(product);
            }
            catch (Exception ex) {
                return StatusCode(500, $"An error occurred while retrieving user info: {ex.Message}");
            }
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GetProductDTO>> Get(long id)
        {


            try
            {
                var product = await _productService.GetProductAsync(id);
                if (product == null)
                {
                    return StatusCode(500, "An error occurred while fetching the user info");

                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving user info: {ex.Message}");

                throw;
            }
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<GetProductDTO> Post([FromBody] CreateProductDTO createProductDTO)
        {
            return await _productService.CreateProductAsync(createProductDTO);

        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<GetProductDTO>> Put(long id, [FromBody] UpdateProductDTO updateProductDTO)
        {

            if (id != updateProductDTO.Id)
            {
                return BadRequest("ID in the URL does not match ID in the request body.");
            }
            try
            {

                var createuser = await _productService.UpdateProductAsync(id, updateProductDTO);
                return Ok(createuser);
            }
            catch (Exception ex) 
            {
              return StatusCode(500, $"An error occurred while updating  user info: {ex.Message}");

                throw;
            } }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(long id)
        {
            try
            {
                var isDeleted = await _productService.DeleteProductAsync(id);
                return Ok(isDeleted);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting user info: {ex.Message}");

                throw;
            }
        }
    }
}
