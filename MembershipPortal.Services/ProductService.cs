using MembershipPortal.DTOs;
using MembershipPortal.IRepositories;
using MembershipPortal.IServices;
using MembershipPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MembershipPortal.DTOs.ProductDTO;

namespace MembershipPortal.Services
{
    public  class ProductService : IProductService
    {

        private readonly IProductRepository _productRepository;

        public ProductService (IProductRepository productRepository)
        {
           _productRepository = productRepository;
        }

        public async Task<GetProductDTO> CreateProductAsync(CreateProductDTO createProductDTO)
        {
            try

            {
                var product = await _productRepository.CreateAsync(new Product()
                {
                    ProductName = createProductDTO.ProductName,
                    Price = createProductDTO.Price,

                });
                return new GetProductDTO(
                    product.Id,
                    product.ProductName,
                    product.Price
                    );
            }
            catch (Exception ex)
            {
                //Console.WriteLine($"Error occurred in CreateProductAsync: {ex.Message}");
                throw; ;
            }


        }

        public async Task<bool> DeleteProductAsync(long Id)
        {
            try
            {
                var product = await _productRepository.GetAsyncById(Id);
                if (product != null)
                {

                    await _productRepository.DeleteAsync(product);
                    return true;
                }
            }
            catch (Exception ex)
            {
               // Console.WriteLine($"Error occurred in DeleteProductAsync: {ex.Message}");
                throw;
            }
            return false;
        }

        public async Task<IEnumerable<GetProductDTO>> GetProductsAsync()
        {
            try
            {
                var products = await _productRepository.GetAsyncAll();

                var productDTO = products.Select(product => new GetProductDTO(

                    product.Id,
                    product.ProductName,
                    product.Price
                    ));
                return productDTO;
            }
            catch (Exception ex)
            {

                //Console.WriteLine($"Error occurred in GetProductsAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<GetProductDTO> GetProductAsync(long Id)
        {
            try
            {
                var product = await _productRepository.GetAsyncById(Id);

                return new GetProductDTO(

                        product.Id,
                        product.ProductName,
                        product.Price
                        );
            }
            catch (Exception ex)
            {
                // Console.WriteLine($"Error occurred in GetProductAsync: {ex.Message}");
                throw;
                
            }
           
        }


        public async Task<GetProductDTO> UpdateProductAsync(long id, UpdateProductDTO updateProductDTO)
        {
            try
            {
                var oldProduct = await _productRepository.GetAsyncById(id);
                if (oldProduct != null)
                {
                    oldProduct.ProductName = updateProductDTO.ProductName;
                    oldProduct.Price = updateProductDTO.Price;

                    return new GetProductDTO(

                           oldProduct.Id,
                           oldProduct.ProductName,
                           oldProduct.Price
                           );
                }
                return null;
            }
            catch (Exception ex)
            {

                //Console.WriteLine($"Error occurred in UpdateProductAsync: {ex.Message}");
                throw;

            }
        }
    }
}
