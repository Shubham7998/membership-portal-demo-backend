using MembershipPortal.DTOs;
using MembershipPortal.IRepositories;
using MembershipPortal.IServices;
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

        private readonly IProductRepository productRepository;

        public ProductService (IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public Task<GetProductDTO> CreateProductAsync(CreateProductDTO createProductDTO)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProductAsync(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<GetProductDTO>> GetProductAsync()
        {
            throw new NotImplementedException();
        }

        public Task<GetProductDTO> GetProductAsync(long Id)
        {
            throw new NotImplementedException();
        }

        public Task<GetProductDTO> UpdateProductAsync(long id, UpdateProductDTO updateProductDTO)
        {
            throw new NotImplementedException();
        }
    }
}
