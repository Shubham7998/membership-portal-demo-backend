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
        public async Task<IEnumerable<GetProductDTO>> Get()
        {
           return await _productService.GetProductsAsync();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<GetProductDTO> Get(int id)
        {
            return await _productService.GetProductAsync(id);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<GetProductDTO> Post([FromBody] CreateProductDTO createProductDTO)
        {
            return await _productService.CreateProductAsync(createProductDTO);

        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<GetProductDTO> Put(int id, [FromBody] UpdateProductDTO updateProductDTO)
        {
            return await _productService.UpdateProductAsync(id, updateProductDTO);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            return await _productService.DeleteProductAsync(id);
        }
    }
}
