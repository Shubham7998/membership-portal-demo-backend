using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MembershipPortal.DTOs
{
    public  class ProductDTO
    {

        public record CreateProductDTO(
            string ProductName,
            [Required(ErrorMessage = "Price is Requried")]
            decimal Price

            );

        public record UpdateProductDTO(
            long Id,
           string ProductName,
           [Required(ErrorMessage = "Price is Requried")]
            decimal Price

           );


        public record GetProductDTO(
            long Id,
          string ProductName,
          [Required(ErrorMessage = "Price is Requried")]
            decimal Price

          );

    }
}
